using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using THUCTAP.Data;
using THUCTAP.Extensions;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Repos
{
    public class ActionRepository : IActionRepository
    {
        private readonly AppDbContext _context;

        public ActionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool>ActionCodeExistsAsync(string code, int menuId)
        {
            return await _context.Action.AnyAsync(a => a.code == code && a.menuId == menuId);
        }

        public async Task<AppAction?>GetByIdAsync(int id)
        {
            return await _context.Action.FindAsync(id);
        }

        public async Task<PagedResult<ActionResponse>>GetAllActionsAsync(ActionFilterRequest filter)
        {
            var query = _context.Action.AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.label))
                    query = query.Where(a => a.label.Contains(filter.label));
                if (!string.IsNullOrWhiteSpace(filter.code))
                    query = query.Where(a => a.code.Contains(filter.code));
                if (!string.IsNullOrWhiteSpace(filter.method))
                    query = query.Where(a => a.method.Contains(filter.method));
                if (filter.id > 0)
                    query = query.Where(a => a.id == filter.id);
            }

            var pagedRawActions = await query
                .AsNoTracking()
                .OrderByDescending(a => a.id)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawActions.Map(a => new ActionResponse
            {
                id = a.id,
                menuId = a.menuId,
                label = a.label,
                code = a.code,
                endpoint = a.endpoint,
                method = a.method
            });
        }

        public async Task CreateAsync(AppAction entity)
        {
            _context.Action.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AppAction entity)
        {
            _context.Action.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(AppAction entity)
        {
            _context.Action.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}