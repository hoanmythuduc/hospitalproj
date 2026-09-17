using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.Mappers;
using THUCTAP.Extensions;
using THUCTAP.ViewModels;

namespace THUCTAP.Repos
{
    public class MaintenanceLogRepository : IMaintenanceLogRepository
    {
        private readonly AppDbContext _context;
        public MaintenanceLogRepository(AppDbContext context) { _context = context; }

        public async Task<EquipmentMaintenanceLog?> GetByIdAsync(int id)
        {
            return await _context.EquipmentMaintenanceLog
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.executor)
                .Include(x => x.inspector)
                .Include(x => x.reviewer)
                .Include(x => x.relatedMaintenance)
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<EquipmentMaintenanceLog>> GetLogsByMonthAsync(int equipmentId, int month, int year)
        {
            return await _context.EquipmentMaintenanceLog
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.executor)
                .Include(x => x.inspector)
                .Include(x => x.reviewer)
                .Include(x => x.relatedMaintenance)
                .Where(x => x.equipmentId == equipmentId && x.logDate.Month == month && x.logDate.Year == year)
                .OrderBy(x => x.logDate)
                .ToListAsync();
        }

        public async Task CreateAsync(EquipmentMaintenanceLog entity)
        {
            _context.EquipmentMaintenanceLog.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EquipmentMaintenanceLog entity)
        {
            _context.EquipmentMaintenanceLog.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<PagedResult<MaintenanceLogResponseDto>> GetAllAsync(MaintenanceLogFilterRequest filter)
        {
            var query = _context.EquipmentMaintenanceLog
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.executor)
                .Include(x => x.inspector)
                .Include(x => x.reviewer)
                .Include(x => x.relatedMaintenance)
                .AsQueryable();

            if (filter != null)
            {
                if (filter.equipmentId.HasValue && filter.equipmentId > 0)
                    query = query.Where(x => x.equipmentId == filter.equipmentId);
                if (filter.fromDate.HasValue)
                    query = query.Where(x => x.logDate >= filter.fromDate.Value);
                if (filter.toDate.HasValue)
                    query = query.Where(x => x.logDate <= filter.toDate.Value);
                if (filter.status.HasValue && filter.status > 0)
                    query = query.Where(x => (int)x.status == filter.status);
            }

            var pagedRawData = await query
                .AsNoTracking()
                .OrderByDescending(x => x.logDate)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawData.Map(x => x.ToResponse());
        }

        public async Task DeleteAsync(EquipmentMaintenanceLog entity)
        {
            _context.EquipmentMaintenanceLog.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}