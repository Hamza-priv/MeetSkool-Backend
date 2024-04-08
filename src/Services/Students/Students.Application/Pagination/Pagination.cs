using Microsoft.EntityFrameworkCore;

namespace Students.Application.Pagination;

public class Pagination<T>
{
    private Pagination(IReadOnlyList<T> items, int totalCount, int page, int pageSize)
    {
        Items = items;
        TotalCount = totalCount;
        Page = page;
        PageSize = pageSize;
    }
    public IReadOnlyList<T> Items { get; set; }
    private int TotalCount { get; set; }
    private int Page { get; set; }
    private int PageSize { get; set; }
    public bool HasNextPage => Page * PageSize < TotalCount;
    public bool HasPreviousPage => Page > 1;

    public static async Task<Pagination<T>> GetPaginatedList(IQueryable<T> query, int page, int pageSize)
    {
        try
        {
            var totalCount = await query.CountAsync();
            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new Pagination<T>(items, totalCount, page, pageSize);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}