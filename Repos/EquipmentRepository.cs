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
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly AppDbContext _context;

        public EquipmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<EquipmentResponseDto>> GetAllAsync(EquipmentFilterRequest filter)
        {
            var query = _context.Equipment
                .Include(e => e.productCategory)
                    .ThenInclude(p => p.supplier) 
                .Include(e => e.managers)
                .Include(e => e.maintenances)
                .AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.equipmentName))
                    query = query.Where(x => x.productCategory.equipmentName.Contains(filter.equipmentName));

                if (!string.IsNullOrWhiteSpace(filter.equipmentCode))
                    query = query.Where(x => x.productCategory.equipmentCode.Contains(filter.equipmentCode));

                if (filter.id > 0)
                    query = query.Where(x => x.id == filter.id);
            }

            var pagedRawData = await query
                .AsNoTracking()
                .OrderByDescending(x => x.id)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawData.Map(x => x.ToEquipmentResponse());
        }

        public async Task<Equipment?> GetByIdAsync(int id)
        {
            return await _context.Equipment
                .Include(e => e.productCategory)
                    .ThenInclude(p => p.supplier)
                .Include(e => e.managers)
                    .ThenInclude(m => m.user)
                .Include(e => e.maintenances)
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task CreateAsync(Equipment entity)
        {
            _context.Equipment.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Equipment entity)
        {
            _context.Equipment.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Equipment entity)
        {
            _context.Equipment.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}