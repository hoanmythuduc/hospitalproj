using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using THUCTAP.Data;
using THUCTAP.Extensions;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;

namespace THUCTAP.Repos
{
    public class EquipmentUsageRepository : IEquipmentUsageRepository
    {
        private readonly AppDbContext _context;
        public EquipmentUsageRepository(AppDbContext context) { _context = context; }

        public async Task<PagedResult<EquipmentUsageLogResponse>> GetAllAsync(EquipmentUsageFilterRequest filter)
        {
            var query = _context.EquipmentUsageLog
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.preparer)
                .Include(x => x.inspector)
                .Include(x => x.reviewer)
                .Include(x => x.dailyLogs)
                .AsQueryable();

            if (filter != null)
            {
                if (filter.equipmentId.HasValue && filter.equipmentId > 0)
                    query = query.Where(x => x.equipmentId == filter.equipmentId);
                if (filter.year.HasValue && filter.year > 0)
                    query = query.Where(x => x.year == filter.year);
                if (filter.month.HasValue && filter.month > 0)
                    query = query.Where(x => x.month == filter.month);
                if (filter.weekOfMonth.HasValue && filter.weekOfMonth > 0)
                    query = query.Where(x => x.weekOfMonth == filter.weekOfMonth);
                if (filter.status.HasValue)
                    query = query.Where(x => (int)x.status == filter.status);
                if (filter.id > 0)
                    query = query.Where(x => x.id == filter.id);
            }

            var pagedRawData = await query
                .AsNoTracking()
                .OrderByDescending(x => x.year).ThenByDescending(x => x.month).ThenByDescending(x => x.weekOfMonth)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawData.Map(x => x.ToResponse());
        }

        public async Task<EquipmentUsageLog?> GetWeeklyLogAsync(int equipmentId, int year, int month, int weekOfMonth)
        {
            return await _context.EquipmentUsageLog
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.dailyLogs)
                .FirstOrDefaultAsync(x => x.equipmentId == equipmentId && x.year == year && x.month == month && x.weekOfMonth == weekOfMonth);
        }

        public async Task<EquipmentUsageLog?> GetByIdAsync(int id)
        {
            return await _context.EquipmentUsageLog
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.preparer)
                .Include(x => x.inspector)
                .Include(x => x.reviewer)
                .Include(x => x.dailyLogs)
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task CreateAsync(EquipmentUsageLog entity)
        {
            _context.EquipmentUsageLog.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(EquipmentUsageLog entity)
        {
            _context.EquipmentUsageLog.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(EquipmentUsageLog entity)
        {
            _context.EquipmentUsageLog.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}