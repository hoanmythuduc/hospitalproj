'use client';

import { useState, useEffect } from 'react';
import { usePathname, useRouter } from 'next/navigation';
import { useTabStore } from '../../store/tabStore';
import { systemApi } from '../../api/api';
import Image from 'next/image';
import { Folder, Plus, Search, Settings, LogOut } from 'lucide-react';
import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarGroup,
  SidebarGroupContent,
  SidebarGroupLabel,
  SidebarHeader,
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
  SidebarInput,
} from "../ui/sidebar";

const toSlug = (str) => {
  if (!str) return '';
  return str.normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/[đĐ]/g, 'd').toLowerCase().replace(/[^a-z0-9]/g, ' ').trim().replace(/\s+/g, '-');
};

export function AppSidebar() {
  const currentPath = usePathname();
  const router = useRouter();
  const { openTabs, activeTab, addTab, setActiveTab } = useTabStore();
  
  const [authorizedGroups, setAuthorizedGroups] = useState([]);
  const [isMounted, setIsMounted] = useState(false);

  useEffect(() => {
    setIsMounted(true);
    const loadAndFilterMenus = () => {
      const storedMenus = localStorage.getItem('menu');
      if (storedMenus) {
        try {
          const permittedMenus = JSON.parse(storedMenus);
          const groupsMap = {};
          permittedMenus.forEach(menu => {
            if (!menu.parentLabel) {
              groupsMap[menu.menuLabel] = { groupName: menu.menuLabel, menus: [] };
            }
          });

          permittedMenus.forEach(menu => {
            if (menu.parentLabel) {
              if (!groupsMap[menu.parentLabel]) {
                groupsMap[menu.parentLabel] = { groupName: menu.parentLabel, menus: [] };
              }
              groupsMap[menu.parentLabel].menus.push({
                id: menu.menuId,
                title: menu.menuLabel,
                path: '/' + toSlug(menu.menuLabel)
              });
            }
          });
          setAuthorizedGroups(Object.values(groupsMap));
        } catch (error) {
          setAuthorizedGroups([]);
        }
      }
    };
    loadAndFilterMenus();
  }, []);

  const handleMenuClick = (e, menu) => {
    e.preventDefault();
    const existingTab = openTabs.find(t => t.path === menu.path);
    const targetPath = existingTab ? (existingTab.lastPath || existingTab.path) : menu.path;
    addTab({ id: menu.id, title: menu.title, path: menu.path });
    router.push(targetPath);
  };

  const handleLogout = () => {
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    localStorage.removeItem('menu');
    router.push('/login');
  };

  if (!isMounted) return null;

  return (
    <Sidebar collapsible="icon">
      <SidebarHeader className="py-4">
        {/* Logo + name */}
        <div className="flex items-center gap-2 px-2 cursor-pointer" onClick={() => router.push('/')}>
          
          {/* Logo */}
          <div className="flex-shrink-0 w-8 h-8 relative flex items-center justify-center">
            <Image 
              src="/HoanMyLogo.png" 
              alt="Hoàn Mỹ Logo" 
              fill
              className="object-contain"
              priority 
            />
          </div>

          {/* name */}
          <div className="relative h-6 w-[100px] group-data-[collapsible=icon]:hidden">
            <Image 
              src="/HoanMyText.png" 
              alt="Hoàn Mỹ Text" 
              fill 
              className="object-contain object-left"
              priority
            />
          </div>
        </div>

        {/* Search */}
        <div className="mt-4 px-2 group-data-[collapsible=icon]:hidden">
          <SidebarInput placeholder="Search..." icon={<Search className="w-4 h-4" />} />
        </div>
      </SidebarHeader>

      <SidebarContent>
        {authorizedGroups.map((group, index) => (
          <SidebarGroup key={index}>
            <SidebarGroupLabel>{group.groupName}</SidebarGroupLabel>
            <SidebarGroupContent>
              <SidebarMenu>
                {group.menus.map((menu) => {
                  const isActive = activeTab === menu.path;
                  return (
                    <SidebarMenuItem key={menu.id}>
                      <SidebarMenuButton 
                        isActive={isActive}
                        onClick={(e) => handleMenuClick(e, menu)}
                        tooltip={menu.title}
                        className={isActive ? "bg-[#00b074] text-white hover:bg-[#009662] hover:text-white" : ""}
                      >
                        <Folder />
                        <span>{menu.title}</span>
                      </SidebarMenuButton>
                    </SidebarMenuItem>
                  );
                })}
              </SidebarMenu>
            </SidebarGroupContent>
          </SidebarGroup>
        ))}

        {/* Create Menu */}
        <SidebarGroup>
          <SidebarMenu>
            <SidebarMenuItem>
              <SidebarMenuButton 
                onClick={() => alert('Mở Modal Create Menu')} 
                className="text-[#00b074] border border-dashed border-[#00b074]/30"
                tooltip="Create Menu"
              >
                <Plus />
                <span>Create Menu</span>
              </SidebarMenuButton>
            </SidebarMenuItem>
          </SidebarMenu>
        </SidebarGroup>
      </SidebarContent>

      <SidebarFooter>
        <SidebarMenu>
          <SidebarMenuItem>
            <SidebarMenuButton tooltip="Settings">
              <Settings />
              <span>Settings</span>
            </SidebarMenuButton>
          </SidebarMenuItem>
          <SidebarMenuItem>
            <SidebarMenuButton onClick={handleLogout} className="text-red-500 hover:text-red-600" tooltip="Logout">
              <LogOut />
              <span>Logout</span>
            </SidebarMenuButton>
          </SidebarMenuItem>
        </SidebarMenu>
      </SidebarFooter>
    </Sidebar>
  );
}