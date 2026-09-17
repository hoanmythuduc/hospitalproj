using System.Text.Json;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class ActionMapper
    {
        
        public static AppAction ToAppAction(this ActionCreateRequest request)
        {
            return new AppAction
            {

                label = request.label,       
                code = request.code,        
                endpoint = request.endpoint ?? string.Empty, 
                method = request.method  ?? string.Empty,     
                menuId = request.menuId,
                createdAt = DateTime.UtcNow,
                updatedAt = DateTime.UtcNow,
            };
        }

        public static void UpdateAppAction(this AppAction action, UpdateActionRequest request)
        {
            action.menuId = request.menuId;
            action.label = request.label;
            action.code = request.code;
            action.endpoint = request.endpoint ?? string.Empty;
            action.method = request.method ?? string.Empty;
            action.updatedAt = DateTime.UtcNow;
        }
    }
}