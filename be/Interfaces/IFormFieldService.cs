using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IFormFieldService
    {
        Task<FormField>CreateFormFieldAsync(FormFieldRequest request);
        Task<FormField>UpdateFormFieldAsync(int id, FormFieldRequest request);
        Task<bool>DeleteFormFieldAsync(int id);
        Task<PagedResult<FormFieldResponse>>GetAllFieldsAsync(FormFieldFilterRequest filter);
        Task<int> ImportExcelAsync(IFormFile file);

    }
}