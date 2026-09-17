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
    public class CustomerMasterRepository : ICustomerMasterRepository
    {
        private readonly AppDbContext _context;

        public CustomerMasterRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<CustomerMasterResponseDto>>GetAllAsync(CustomerMasterFilterRequest filter)
        {
            var query = _context.CustomerMaster
                                .Include(c => c.Category)
                                .AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.supplierName))
                    query = query.Where(x => x.supplierName.Contains(filter.supplierName));

                if (filter.categoryId.HasValue && filter.categoryId.Value > 0)
                    query = query.Where(x => x.categoryId == filter.categoryId.Value);

                if (filter.id > 0)
                    query = query.Where(x => x.id == filter.id);
            }

            var pagedRawData = await query
                .AsNoTracking()
                .OrderByDescending(x => x.id)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawData.Map(x => x.ToCustomerMasterResponse());
        }

        public async Task<CustomerMaster?> GetByIdAsync(int id)
        {
            return await _context.CustomerMaster.FindAsync(id);
        }

        public async Task CreateAsync(CustomerMaster entity)
        {
            _context.CustomerMaster.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomerMaster entity)
        {
            _context.CustomerMaster.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CustomerMaster entity)
        {
            _context.CustomerMaster.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}