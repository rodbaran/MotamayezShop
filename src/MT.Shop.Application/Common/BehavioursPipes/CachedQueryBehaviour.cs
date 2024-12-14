using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using MT.Shop.Application.Contracts;
using System.Text;
using System.Text.Json;

namespace MT.Shop.Application.Common.BehavioursPipes;

public class CachedQueryBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICacheQuery, IRequest<TResponse>
{
    private readonly IDistributedCache _cache;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ILogger<CachedQueryBehaviour<TRequest, TResponse>> _logger;

    public CachedQueryBehaviour(
        IDistributedCache cache,
        IHttpContextAccessor httpContextAccessor,
        ILogger<CachedQueryBehaviour<TRequest, TResponse>> logger)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    private async Task CreateNewCacheAsync(string key, byte[] serializedData, TimeSpan expiration, CancellationToken cancellationToken)
    {
        try
        {
            await _cache.SetAsync(key, serializedData, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            }, cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while saving data to the cache with key {Key}", key);
        }
    }

    private static TimeSpan GetCacheExpiration(ICacheQuery request)
    {
        return TimeSpan.FromHours(request.HoursSaveData > 0 ? request.HoursSaveData : 1); // Ensure at least 1 hour.
    }

    private string GenerateCacheKey(HttpRequest request)
    {
        var path = request.Path.ToString();
        var queryParams = string.Join("|", request.Query.OrderBy(x => x.Key)
            .Select(x => $"{x.Key}-{x.Value}"));

        // Use a hash for better key management in distributed cache.
        var rawKey = $"{path}|{queryParams}";
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawKey));
        return Convert.ToBase64String(hashBytes);
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_httpContextAccessor.HttpContext == null)
            throw new InvalidOperationException("HttpContext is not available");

        var key = GenerateCacheKey(_httpContextAccessor.HttpContext.Request);

        try
        {
            var cachedData = await _cache.GetAsync(key, cancellationToken);
            if (cachedData != null)
            {
                _logger.LogInformation("Cache hit for key {Key}", key);
                return JsonSerializer.Deserialize<TResponse>(cachedData);
            }

            _logger.LogInformation("Cache miss for key {Key}. Fetching new data.", key);
            var response = await next();
            var serializedData = JsonSerializer.SerializeToUtf8Bytes(response);
            await CreateNewCacheAsync(key, serializedData, GetCacheExpiration(request), cancellationToken);
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred during caching process for key {Key}", key);
            return await next();
        }
    }
}
