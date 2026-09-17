using THUCTAP.Models; 
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class MenuMapper
    {
        public static MenuResponse ToMenuResponseDto(Menu menu)
        {
            if (menu == null) return null;

            return new MenuResponse
            {
                id = menu.id,
                label = menu.label,
                to = menu.to ?? string.Empty,
                icon = menu.icon ?? string.Empty,
                children = new List<MenuResponse>(),
                action = new List<string>()
            };
        }
    }
}