namespace MT.Shop.Domain.Helper.Types;

public abstract class PagedResultBase
{
    protected PagedResultBase()
    {
    }

    protected PagedResultBase(int currentPage, int resultsPerPage,
        int totalPages, long totalResults)
    {
        CurrentPage = currentPage > totalPages ? totalPages : currentPage;
        ResultsPerPage = resultsPerPage;
        TotalPages = totalPages;
        TotalResults = totalResults;
    }

    public int CurrentPage { get; protected set; }
    public int ResultsPerPage { get; protected set; }
    public int TotalPages { get; protected set; }
    public long TotalResults { get; protected set; }
}