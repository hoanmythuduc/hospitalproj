using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Interfaces
{
    public interface IActionRepository
    {
        Task<bool>ActionCodeExistsAsync(string code, int menuId);
        Task<AppAction?>GetByIdAsync(int id);
        Task<PagedResult<ActionResponse>>GetAllActionsAsync(ActionFilterRequest filter);

        Task CreateAsync(AppAction entity);
        Task UpdateAsync(AppAction entity);
        Task DeleteAsync(AppAction entity);
    }
}