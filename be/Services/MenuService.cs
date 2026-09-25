using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;
using DocumentFormat.OpenXml.InkML;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging; // 👉 Bổ sung thư viện Logging

namespace THUCTAP.Services
{
    public class MenuService : IMenuService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<MenuService> _logger; // 👉 Khai báo Logger

        // 👉 Tiêm ILogger vào Constructor
        public MenuService(AppDbContext context, ILogger<MenuService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<MenuResponse>> GetFullMenuTreeAsync()
        {
            try
            {
                var allMenus = await _context.Menu.OrderBy(m => m.id).ToListAsync();
                var allActions = await _context.Action.ToListAsync();

                var menuTree = new List<MenuResponse>();
                var parentMenus = allMenus.Where(m => m.parentId == null).ToList();

                foreach (var parent in parentMenus)
                {
                    var parentDto = new MenuResponse
                    {
                        id = parent.id,
                        label = parent.label,
                        to = parent.to,
                        icon = parent.icon,
                        children = new List<MenuResponse>()
                    };

                    var childMenus = allMenus.Where(m => m.parentId == parent.id).ToList();
                    foreach (var child in childMenus)
                    {
                        var childDto = new MenuResponse
                        {
                            id = child.id,
                            label = child.label,
                            to = child.to,
                            icon = child.icon,
                            action = allActions.Where(a => a.menuId == child.id).Select(a => a.code).ToList()
                        };
                        parentDto.children.Add(childDto);
                    }
                    menuTree.Add(parentDto);
                }

                return menuTree;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy cây cấu trúc Menu đầy đủ");
                throw;
            }
        }

        public async Task<MenuResponse> CreateDynamicMenuAsync(MenuCreateRequest request)
        {
            try
            {
                var parentMenu = await _context.Menu
                    .FirstOrDefaultAsync(m => m.label == request.parentMenuName);

                if (parentMenu == null)
                {
                    parentMenu = new Menu { label = request.parentMenuName };
                    _context.Menu.Add(parentMenu);
                    await _context.SaveChangesAsync(); 
                }

                var createdChildren = new List<Menu>();
                if (request.childMenuName != null && request.childMenuName.Any())
                {
                    foreach (var childName in request.childMenuName)
                    {
                        if (string.IsNullOrWhiteSpace(childName)) continue;

                        var childMenu = await _context.Menu
                            .FirstOrDefaultAsync(m => m.label == childName && m.parentId == parentMenu.id);

                        if (childMenu == null)
                        {
                            childMenu = new Menu
                            {
                                label = childName,
                                parentId = parentMenu.id
                            };
                            _context.Menu.Add(childMenu);
                        }

                        createdChildren.Add(childMenu);
                    }

                    if (createdChildren.Any())
                    {
                        await _context.SaveChangesAsync();
                    }
                }

                var response = MenuMapper.ToMenuResponseDto(parentMenu);

                foreach (var child in createdChildren)
                {
                    response.children.Add(MenuMapper.ToMenuResponseDto(child));
                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tạo Menu động. Menu cha: {ParentMenu}", request.parentMenuName);
                throw;
            }
        }

        public async Task<MenuResponse> UpdateMenuAsync(int id, MenuUpdateRequest request)
        {
            try
            {
                var menu = await _context.Menu.FirstOrDefaultAsync(m => m.id == id);
                if (menu == null)
                {
                    throw new Exception("Không tìm thấy Menu này!");
                }

                menu.label = request.label;
                menu.to = request.to;
                menu.icon = request.icon;

                if (request.parentId == 0)
                {
                    request.parentId = null;
                }
                if (request.parentId.HasValue)
                {
                    var parentExists = await _context.Menu.AnyAsync(m => m.id == request.parentId.Value);
                    if (!parentExists) throw new Exception("Menu cha không tồn tại!");
                }
                menu.parentId = request.parentId;

                _context.Menu.Update(menu);
                await _context.SaveChangesAsync();

                return MenuMapper.ToMenuResponseDto(menu);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi cập nhật Menu có ID: {MenuId}", id);
                throw;
            }
        }

        public async Task<bool> DeleteMenuAsync(int id)
        {
            try
            {
                var menu = await _context.Menu.FirstOrDefaultAsync(m => m.id == id);
                if (menu == null)
                {
                    return false;
                }

                var hasChildren = await _context.Menu.AnyAsync(m => m.parentId == id);
                if (hasChildren)
                {
                    throw new Exception("Không thể xóa Menu này vì đang chứa Menu con. Vui lòng xóa Menu con trước!");
                }

                _context.Menu.Remove(menu);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa Menu có ID: {MenuId}", id);
                throw;
            }
        }
    }
}