using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Extensions;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;

namespace THUCTAP.Repos
{
    public class CustomerCategoryRepository : ICustomerCategoryRepository
    {
        private readonly AppDbContext _context;

        public CustomerCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<CustomerCategoryResponseDto>>GetAllAsync(CustomerCategoryFilterRequest filter)
        {
            var query = _context.CustomerCategory.AsQueryable();

            if (filter != null && !string.IsNullOrWhiteSpace(filter.groupName))
                query = query.Where(x => x.groupName.Contains(filter.groupName));
            if (filter.id > 0)query = query.Where(x => x.id == filter.id);

            var pagedRawData = await query
                .AsNoTracking()
                .OrderByDescending(x => x.id)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawData.Map(x => x.ToCustomerCategoryResponse());
        }

        public async Task<CustomerCategory?>GetByIdAsync(int id)
        {
            return await _context.CustomerCategory.FindAsync(id);
        }

        public async Task CreateAsync(CustomerCategory entity)
        {
            _context.CustomerCategory.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomerCategory entity)
        {
            _context.CustomerCategory.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CustomerCategory entity)
        {
            _context.CustomerCategory.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}