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
    public class WaterSystemRepository : IWaterSystemRepository
    {
        private readonly AppDbContext _context;
        public WaterSystemRepository(AppDbContext context) { _context = context; }

        public async Task<PagedResult<WaterSystemLogResponse>> GetAllAsync(WaterSystemFilterRequest filter)
        {
            var query = _context.WaterSystemLog
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.preparer)
                .Include(x => x.inspector)
                .Include(x => x.reviewer)
                .Include(x => x.dailyLogs).ThenInclude(d => d.tracker)
                .AsQueryable();

            if (filter != null)
            {
                if (filter.equipmentId.HasValue && filter.equipmentId > 0)
                    query = query.Where(x => x.equipmentId == filter.equipmentId);
                if (filter.month.HasValue && filter.month > 0)
                    query = query.Where(x => x.month == filter.month);
                if (filter.year.HasValue && filter.year > 0)
                    query = query.Where(x => x.year == filter.year);
                if (filter.status.HasValue)
                    query = query.Where(x => (int)x.status == filter.status);
                if (filter.id > 0)
                    query = query.Where(x => x.id == filter.id);
            }

            var pagedRawData = await query
                .AsNoTracking()
                .OrderByDescending(x => x.year).ThenByDescending(x => x.month)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawData.Map(x => x.ToResponse());
        }

        public async Task<WaterSystemLog?> GetMonthlyLogAsync(int equipmentId, int month, int year)
        {
            return await _context.WaterSystemLog
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.preparer)
                .Include(x => x.inspector)
                .Include(x => x.reviewer)
                .Include(x => x.dailyLogs).ThenInclude(d => d.tracker)
                .FirstOrDefaultAsync(x => x.equipmentId == equipmentId && x.month == month && x.year == year);
        }

        public async Task<WaterSystemLog?> GetByIdAsync(int id)
        {
            return await _context.WaterSystemLog
                .Include(x => x.equipment).ThenInclude(e => e.productCategory)
                .Include(x => x.preparer)
                .Include(x => x.inspector)
                .Include(x => x.reviewer)
                .Include(x => x.dailyLogs).ThenInclude(d => d.tracker)
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task CreateAsync(WaterSystemLog entity)
        {
            _context.WaterSystemLog.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(WaterSystemLog entity)
        {
            _context.WaterSystemLog.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(WaterSystemLog entity)
        {
            _context.WaterSystemLog.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}