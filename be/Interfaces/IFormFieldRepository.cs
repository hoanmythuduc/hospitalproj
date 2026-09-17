using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IFormFieldRepository
    {
        Task<bool>FieldKeyExistsAsync(string fieldKey);
        Task<FormField?>GetFormFieldByIdAsync(int id);
        Task<PagedResult<FormFieldResponse>>GetAllFieldsAsync(FormFieldFilterRequest filter);
   
        Task CreateFormFieldAsync(FormField field);
        Task UpdateFormFieldAsync(FormField field);
        Task DeleteFormFieldAsync(FormField field);
    }
}