using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IActionService
    {
        Task<AppAction>CreateActionAsync(ActionCreateRequest request);
        Task<AppAction>UpdateActionAsync(int id, UpdateActionRequest request);
        Task<bool>DeleteActionAsync(int id);
        Task<PagedResult<ActionResponse>>GetAllActionsAsync(ActionFilterRequest filter);
        Task<int> ImportExcelAsync(IFormFile file);


    }
}