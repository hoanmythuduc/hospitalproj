using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Extensions;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers; // Thêm thư viện Mapper

namespace THUCTAP.Repos
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context) { _context = context; }

        public async Task<PagedResult<ProductCategoryResponseDto>> GetAllAsync(ProductCategoryFilterRequest filter)
        {
            var query = _context.ProductCategory.Include(x => x.supplier).AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.equipmentName))
                    query = query.Where(x => x.equipmentName.Contains(filter.equipmentName));
                if (!string.IsNullOrWhiteSpace(filter.equipmentCode))
                    query = query.Where(x => x.equipmentCode.Contains(filter.equipmentCode));
                if (filter.supplierId.HasValue && filter.supplierId.Value > 0)
                    query = query.Where(x => x.supplierId == filter.supplierId.Value);
                if (filter.id > 0)
                    query = query.Where(x => x.id == filter.id);
            }

            var pagedRawData = await query
                .AsNoTracking()
                .OrderByDescending(x => x.id)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawData.Map(x => x.ToProductCategoryResponse());
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            return await _context.ProductCategory.Include(x => x.supplier).FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task CreateAsync(ProductCategory entity)
        {
            _context.ProductCategory.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductCategory entity)
        {
            _context.ProductCategory.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductCategory entity)
        {
            _context.ProductCategory.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}