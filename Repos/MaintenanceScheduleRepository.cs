using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Models;
using THUCTAP.Mappers;
using THUCTAP.Extensions;
using THUCTAP.ViewModels;
using THUCTAP.Interfaces;

namespace THUCTAP.Repos
{
    public class MaintenanceScheduleRepository : IMaintenanceScheduleRepository 
    {
        private readonly AppDbContext _context;
        public MaintenanceScheduleRepository(AppDbContext context) { _context = context; }

        public async Task<EquipmentMaintenanceSchedule?> GetByIdAsync(int id)
        {
            return await _context.EquipmentMaintenanceSchedule
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.preparer)
                .Include(x => x.approver)
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task CreateAsync(EquipmentMaintenanceSchedule entity)
        {
            _context.EquipmentMaintenanceSchedule.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EquipmentMaintenanceSchedule entity)
        {
            _context.EquipmentMaintenanceSchedule.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<MaintenanceScheduleResponseDto>> GetAllAsync(MaintenanceScheduleFilterRequest filter)
        {
            var query = _context.EquipmentMaintenanceSchedule
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.preparer)
                .Include(x => x.approver)
                .AsQueryable();

            if (filter != null)
            {
                if (filter.equipmentId.HasValue && filter.equipmentId > 0)
                    query = query.Where(x => x.equipmentId == filter.equipmentId);
                if (filter.year.HasValue && filter.year > 0)
                    query = query.Where(x => x.year == filter.year);
                if (filter.status.HasValue)
                    query = query.Where(x => (int)x.status == filter.status);
            }

            var pagedRawData = await query
                .AsNoTracking()
                .OrderByDescending(x => x.year).ThenBy(x => x.equipmentId)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawData.Map(x => x.ToResponse());
        }

        public async Task DeleteAsync(EquipmentMaintenanceSchedule entity)
        {
            _context.EquipmentMaintenanceSchedule.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}