using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace MT.Shop.Application.Common.BehavioursPipes;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;
    private readonly Stopwatch _timer;
    private const int DefaultThresholdMilliseconds = 500; // حداقل زمان برای هشدار

    public PerformanceBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
        _timer = new Stopwatch();
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        _timer.Start();

        try
        {
            // فراخوانی هندلر بعدی
            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            // اگر زمان اجرای درخواست طولانی‌تر از مقدار تعریف شده باشد، لاگ اخطار ثبت شود.
            if (elapsedMilliseconds > DefaultThresholdMilliseconds)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogWarning(
                    "Long Running Request: {RequestName} ({ElapsedMilliseconds} ms) {@Request}",
                    requestName, elapsedMilliseconds, request);
            }

            return response;
        }
        finally
        {
            _timer.Reset();
        }
    }
}





