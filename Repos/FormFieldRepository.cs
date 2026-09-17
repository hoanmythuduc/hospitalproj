using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Extensions;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Repos
{
    public class FormFieldRepository : IFormFieldRepository
    {
        private readonly AppDbContext _context;

        public FormFieldRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool>FieldKeyExistsAsync(string field)
        {
            return await _context.FormField.AnyAsync(f => f.field == field);
        }

        public async Task<FormField?> GetFormFieldByIdAsync(int id)
        {
            return await _context.FormField.FirstOrDefaultAsync(f => f.id == id);
        }

        public async Task<PagedResult<FormFieldResponse>>GetAllFieldsAsync(FormFieldFilterRequest filter)
        {
            var query = _context.FormField
                .Include(f => f.menu)
                .AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.field))
                    query = query.Where(f => f.field.Contains(filter.field));
                if (!string.IsNullOrWhiteSpace(filter.type))
                    query = query.Where(f => f.type.Contains(filter.type));
                if (filter.menuId.HasValue)
                    query = query.Where(f => f.menuId == filter.menuId.Value);
                if (filter.id > 0)
                    query = query.Where(f => f.id == filter.id);
            }

            var pagedRawFields = await query
                .AsNoTracking()
                .OrderByDescending(f => f.id)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawFields.Map(f => new FormFieldResponse
            {

                id = f.id,
                entityName = f.entityName,
                label = f.label,
                field = f.field,
                type = f.type,
                option = f.option,
                colSpan = f.colSpan,
                sortOrder = f.sortOrder,
                subfield = f.subField,
                tagfield = f.tagField,
                tabname = f.tabName,
                endpoint = f.endPoint,
                isSearchAble = f.isSearchAble,
                isShowInForm = f.isShowInForm,
                isShowInList = f.isShowInList,
                menuId = f.menuId ?? 0,
                menuName = f.menu != null ? f.menu.label : null
            });
        }

        public async Task CreateFormFieldAsync(FormField field)
        {
            _context.FormField.Add(field);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFormFieldAsync(FormField field)
        {
            _context.FormField.Update(field);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFormFieldAsync(FormField field)
        {
            _context.FormField.Remove(field);
            await _context.SaveChangesAsync();
        }
    }
}