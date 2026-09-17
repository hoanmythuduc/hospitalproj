using Microsoft.EntityFrameworkCore;
using THUCTAP.ViewModels;

namespace THUCTAP.Extensions
{
    public static class QueryableExtensions
    {
        
        public static async Task<PagedResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, int pageIndex, int pageSize)
        {
          
            var totalRecords = await query.CountAsync();

            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 10 : pageSize;

            var items = await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<T>
            {
                items = items,
                totalRecords = totalRecords,
                pageIndex = pageIndex,
                pageSize = pageSize
            };
        }
    }
}