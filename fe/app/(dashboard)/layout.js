'use client';

import { useState, useEffect } from 'react';
import { usePathname, useRouter } from 'next/navigation';
import { useTabStore } from '../../store/tabStore';
import WelcomePage from '../../components/welcome/WelcomePage'; 
import { dynamicApi, systemApi } from '../../api/api';
import { 
  LogOut, 
  ChevronLeft, 
  ChevronRight, 
  Search, 
  Settings, 
  Plus, 
  Folder,
  CircleUser 
} from 'lucide-react';

const toSlug = (str) => {
  if (!str) return '';
  return str.normalize("NFD").replace(/[\u0300-\u036f]/g, "")
    .replace(/[đĐ]/g, 'd') 
    .toLowerCase()
    .replace(/[^a-z0-9]/g, ' ') 
    .trim()
    .replace(/\s+/g, '-');
};

export default function DashboardLayout({ children }) {
  const currentPath = usePathname(); 
  const router = useRouter();
  const [authorizedGroups, setAuthorizedGroups] = useState([]);
  const [isMounted, setIsMounted] = useState(false);
  const [isSidebarOpen, setIsSidebarOpen] = useState(true); 

  const { openTabs, activeTab, addTab, removeTab, setActiveTab, updateLastPath, reorderTabs } = useTabStore();  
  const [draggedIndex, setDraggedIndex] = useState(null);
  const [dragOverInfo, setDragOverInfo] = useState(null);

  const [isMenuModalOpen, setIsMenuModalOpen] = useState(false);
  const [parentName, setParentName] = useState("");
  const [childNames, setChildNames] = useState([]);

  const [currentUserInfo, setCurrentUserInfo] = useState({
  name: "User",
  email: "user@hospital.com",});

  const handleAddChildInput = () => setChildNames([...childNames, ""]);

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
              groupsMap[menu.menuLabel] = {
                groupName: menu.menuLabel,
                menus: []
              };
            }
          });

          permittedMenus.forEach(menu => {
            if (menu.parentLabel) {
              if (!groupsMap[menu.parentLabel]) {
                groupsMap[menu.parentLabel] = {
                  groupName: menu.parentLabel,
                  menus: []
                };
              }
              const slugPath = '/' + toSlug(menu.menuLabel);
              groupsMap[menu.parentLabel].menus.push({
                id: menu.menuId,
                title: menu.menuLabel,
                path: slugPath
              });
            }
          });

          setAuthorizedGroups(Object.values(groupsMap));
        } catch (error) {
          console.error("Menu layout error:", error);
          setAuthorizedGroups([]);
        }
      } else {
        setAuthorizedGroups([]);
      }
    };

    loadAndFilterMenus();
  }, []);

  useEffect(() => {
    if (isMounted && currentPath && currentPath !== '/') {
      let isMainMenu = false;
      let matchedMenu = null;
      
      authorizedGroups.forEach(group => {
        const found = group.menus.find(m => currentPath === m.path || currentPath.startsWith(m.path + '/'));
        if (found) {
          isMainMenu = true;
          matchedMenu = found;
        }
      });

      if (matchedMenu) {
        const existingTab = useTabStore.getState().openTabs.find(t => t.path === matchedMenu.path);
        if (!existingTab) {
          addTab({ id: matchedMenu.id, title: matchedMenu.title, path: matchedMenu.path });
        }
      }
      const currentActiveTab = useTabStore.getState().activeTab;
      if (currentActiveTab) {
        updateLastPath(currentActiveTab, currentPath);
      }
    }
  }, [isMounted, currentPath, addTab, updateLastPath, authorizedGroups]);

  const handleMenuClick = (e, menu) => {
    e.preventDefault(); 
    const existingTab = openTabs.find(t => t.path === menu.path);
    const targetPath = existingTab ? (existingTab.lastPath || existingTab.path) : menu.path;
    addTab({ id: menu.id, title: menu.title, path: menu.path });
    router.push(targetPath); 
  };

  const handleTabClick = (tab) => {
    const targetPath = tab.lastPath || tab.path;
    setActiveTab(tab.path);
    router.push(targetPath);
  };

  const handleCloseTab = (e, path) => {
    e.stopPropagation(); 
    removeTab(path);
    
    setTimeout(() => {
      const currentActive = useTabStore.getState().activeTab;
      const currentTabs = useTabStore.getState().openTabs;
      
      if (currentActive) {
        const activeTabData = currentTabs.find(t => t.path === currentActive);
        const pathToPush = activeTabData ? (activeTabData.lastPath || activeTabData.path) : currentActive;
        router.push(pathToPush);
      } else {
        router.push('/welcome');
      }
    }, 0);
  };

  const handleDragStart = (e, index) => {
    setDraggedIndex(index);
    e.dataTransfer.effectAllowed = "move";
    setTimeout(() => {
      e.target.style.opacity = '0.4';
    }, 0);
  };

  const handleDragOver = (e, index) => {
    e.preventDefault();
    e.dataTransfer.dropEffect = "move";
    if (draggedIndex === index) return;
    const rect = e.currentTarget.getBoundingClientRect();
    const mouseX = e.clientX;
    const midPoint = rect.left + rect.width / 2;
    const position = mouseX < midPoint ? 'left' : 'right';

    setDragOverInfo({ index, position });
  };

  const handleDragLeave = (e) => {
    setDragOverInfo(null);
  };

  const handleDrop = (e, index) => {
    e.preventDefault();
    if (draggedIndex !== null && dragOverInfo) {
      let targetIndex = dragOverInfo.index;
      if (dragOverInfo.position === 'right') {
        targetIndex += 1;
      }
      reorderTabs(draggedIndex, targetIndex);
    }
    setDraggedIndex(null);
    setDragOverInfo(null);
    e.currentTarget.style.opacity = '1';
  };

  const handleDragEnd = (e) => {
    setDraggedIndex(null);
    setDragOverInfo(null);
    e.currentTarget.style.opacity = '1';
  };

  const handleChildNameChange = (index, value) => {
    const updated = [...childNames];
    updated[index] = value;
    setChildNames(updated);
  };
  
  const handleRemoveChild = (index) => {
    setChildNames(childNames.filter((_, i) => i !== index));
  };

  const handleCreateMenu = async () => {
    if (!parentName.trim()) {
      alert("Please enter the parent menu name!");
      return;
    }
    const validChildNames = childNames.filter(name => name.trim() !== "");
    const payload = {
      parentMenuName: parentName,
      childMenuName: validChildNames
    };

    const response = await systemApi.addMenu(payload);
    if (!response.error) {
      alert("Create successful!");
      setIsMenuModalOpen(false);
      setParentName("");
      setChildNames([]);
    } else {
       alert("Error occurred while creating menu!");
    }
  };

  const handleLogout = () => {
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
    localStorage.removeItem('menu');
    router.push('/login');
  };

  useEffect(() => {
    const getUserInfo = async () => {
      const userId = localStorage.getItem('userId');
      if (!userId) return;

      try {
        const response = await dynamicApi.getById('UserAccount', userId, "userCode");
        if (!response.error && response.data) {
          const apiPayload = response.data.data || response.data;
          const itemsList = Array.isArray(apiPayload) ? apiPayload : apiPayload.items;
          if (itemsList && itemsList.length > 0) {
            setCurrentUserInfo({
              name: itemsList[0].userName || "User",
              email: itemsList[0].email || ""
            });
          }
        }
      } catch (error) {
        console.error("Error fetching user info:", error);
      }
    };
    getUserInfo();
  }, []);

  return (
    <div className="flex h-screen w-full bg-[#f4f7f6] overflow-hidden font-sans">
      
      {/* SIDEBAR */}
      <aside 
        className={`relative flex-shrink-0 bg-white border-r border-gray-200 flex flex-col justify-between transition-all duration-300 ease-in-out z-20 ${
          isSidebarOpen ? 'w-[260px]' : 'w-[80px]'
        }`}
      >
        {/* Toggle Button */}
        <button
          onClick={() => setIsSidebarOpen(!isSidebarOpen)}
          className="absolute -right-3.5 top-6 flex h-7 w-7 items-center justify-center rounded-full bg-white border border-gray-200 text-gray-400 hover:text-[#00b074] shadow-sm z-30 transition-transform"
        >
          {isSidebarOpen ? <ChevronLeft size={16} /> : <ChevronRight size={16} />}
        </button>

        <div className="flex flex-col flex-1 overflow-hidden">
          
          {/* LOGO  */}
          <div className="h-[60px] flex items-center justify-center px-4 flex-shrink-0 mt-3">
            <div className={`flex items-center gap-2 text-[#00b074] tracking-wider ${isSidebarOpen ? 'w-full justify-start' : 'justify-center'}`}>
              <img src="/logo/HoanMyLogo.png" alt="Logo" className="w-12 h-12 object-contain flex-shrink-0" />
              {isSidebarOpen && <span className="text-xl font-bold text-[#00829a]">Hoàn Mỹ</span>}
            </div>
          </div>

          {/* SEARCH BAR */}
          <div className="px-4 py-4">
            <div className={`flex items-center rounded bg-gray-100 transition-all ${isSidebarOpen ? 'px-3 py-2.5' : 'p-2.5 justify-center'}`}>
              <Search size={18} className="text-gray-500 flex-shrink-0" />
              {isSidebarOpen && (
                <input 
                  type="text" 
                  placeholder="Search..." 
                  className="ml-3 w-full bg-transparent text-sm text-gray-700 outline-none placeholder-gray-400" 
                />
              )}
            </div>
          </div>

          {/* MENU LIST  */}
          <div className="flex-1 overflow-y-auto pb-2 scrollbar-hide">
            {!isMounted ? (
              <div className="px-4 text-sm text-gray-400 text-center">...</div>
            ) : authorizedGroups.length > 0 ? (
              <>
                {authorizedGroups.map((group, index) => (
                  <div key={index} className="mb-4 px-2">
                    {/* Group Title */}
                    {isSidebarOpen && (
                      <h3 className="px-3 mb-2 text-xs font-bold text-gray-400 tracking-wider uppercase">
                        {group.groupName}
                      </h3>
                    )}
                    
                    <ul className="flex flex-col gap-1">
                      {group.menus.map((menu) => {
                        const isActive = activeTab === menu.path;
                        
                        return (
                          <li key={menu.id}>
                            <a 
                              href={menu.path}
                              onClick={(e) => handleMenuClick(e, menu)}
                              className={`flex items-center rounded-lg transition-colors cursor-pointer ${
                                isSidebarOpen ? 'px-3 py-2.5 gap-3' : 'p-2.5 justify-center mx-auto w-fit'
                              } ${
                                isActive 
                                  ? "bg-[#00829a] text-white shadow-md shadow-[#00b074]/20" 
                                  : "text-gray-500 hover:bg-gray-100 hover:text-gray-900" 
                              }`}
                              title={!isSidebarOpen ? menu.title : ""}
                            >
                              <Folder size={18} className="flex-shrink-0" />
                              {isSidebarOpen && <span className="text-sm font-medium truncate">{menu.title}</span>}
                            </a>
                          </li>
                        );
                      })}
                    </ul>
                  </div>
                ))}
              </>
            ) : (
              <div className="px-4 text-sm text-gray-400 text-center">No permission</div>
            )}
          </div>
          
          {/* ACTIONS & FOOTER */}
          <div className="flex-shrink-0 flex flex-col pb-4 pt-2 bg-white z-10">
            {/* Divider */}
            <div className="w-4/5 mx-auto border-t border-gray-200 mb-3"></div>

            {/* Menu Actions */}
            <div className="px-3 flex flex-col gap-1 mb-3">
              <button
                onClick={() => setIsMenuModalOpen(true)}
                className={`flex items-center rounded-lg text-gray-500 hover:bg-gray-100 hover:text-gray-900 transition-colors ${
                  isSidebarOpen ? 'px-3 py-2.5 gap-3' : 'p-2.5 justify-center mx-auto w-fit'
                }`}
                title={!isSidebarOpen ? "Create Menu" : ""}
              >
                <Plus size={20} className="flex-shrink-0" />
                {isSidebarOpen && <span className="text-sm font-medium">Create Menu</span>}
              </button>

              <button
                className={`flex items-center rounded-lg text-gray-500 hover:bg-gray-100 hover:text-gray-900 transition-colors ${
                  isSidebarOpen ? 'px-3 py-2.5 gap-3' : 'p-2.5 justify-center mx-auto w-fit'
                }`}
                title={!isSidebarOpen ? "Settings" : ""}
              >
                <Settings size={20} className="flex-shrink-0" />
                {isSidebarOpen && <span className="text-sm font-medium">Settings</span>}
              </button>
            </div>

            {/* User Profile Footer */}
            <div className={`px-4 flex items-center ${isSidebarOpen ? 'justify-between' : 'justify-center'}`}>
              {isSidebarOpen ? (
                <div className="flex items-center justify-between w-full p-2 bg-gray-50 rounded-xl border border-gray-100">
                  <div className="flex items-center gap-3 overflow-hidden">
                    <CircleUser size={32} className="text-gray-400 flex-shrink-0" />
                    <div className="flex flex-col min-w-0">
                      <span className="text-sm font-bold text-gray-800 truncate">
                        {currentUserInfo.name}
                      </span>
                      <span className="text-[11px] text-gray-500 truncate">
                        {currentUserInfo.email}
                      </span>
                    </div>
                  </div>
                  <button
                    onClick={handleLogout}
                    className="text-gray-400 hover:text-red-500 transition-colors p-1.5 rounded-lg hover:bg-red-50 flex-shrink-0"
                    title="Logout"
                  >
                    <LogOut size={18} />
                  </button>
                </div>
              ) : (
                <button
                  onClick={handleLogout}
                  className="w-10 h-10 rounded-full bg-gray-50 border border-gray-200 flex items-center justify-center text-gray-400 hover:text-red-500 hover:border-red-200 transition-colors"
                  title="Logout"
                >
                  <CircleUser size={24} />
                </button>
              )}
            </div>
          </div>

        </div>
      </aside>

      {/* modal form menu */}
      {isMenuModalOpen && (
        <div className="fixed inset-0 z-[100] flex items-center justify-center bg-black/40 backdrop-blur-sm">
          <div className="bg-white w-full max-w-md rounded-xl shadow-2xl p-6 flex flex-col gap-4">
            <h2 className="text-xl font-bold text-gray-800 border-b pb-3">Create New Menu</h2>
            
            {/* parent menu */}
            <div className="flex flex-col gap-1.5">
              <label className="text-xs font-bold text-gray-500 uppercase">Menu Name <span className="text-red-500">*</span></label>
              <input 
                type="text" 
                value={parentName}
                onChange={(e) => setParentName(e.target.value)}
                className="w-full border border-gray-300 rounded-lg px-3 py-2 text-sm outline-none focus:border-[#00b074] focus:ring-1 focus:ring-[#00b074]"
                placeholder="e.g., Employee Management"
              />
            </div>

            {/* child menus */}
            <div className="flex flex-col gap-3 mt-2">
              <div className="flex items-center justify-between">
                <label className="text-xs font-bold text-gray-500 uppercase">Child Menus</label>
                <button onClick={handleAddChildInput} className="text-xs font-medium text-[#117180] hover:underline flex items-center gap-1">
                  <Plus size={14} /> Add Child
                </button>
              </div>
              
              <div className="max-h-[200px] overflow-y-auto flex flex-col gap-2 pr-1 scrollbar-hide">
                {childNames.map((child, index) => (
                  <div key={index} className="flex items-center gap-2">
                    <input 
                      type="text" 
                      value={child}
                      onChange={(e) => handleChildNameChange(index, e.target.value)}
                      className="flex-1 border border-gray-300 rounded-lg px-3 py-2 text-sm outline-none focus:border-[#00b074] focus:ring-1 focus:ring-[#00b074]"
                      placeholder={`Child Menu ${index + 1}...`}
                    />
                    <button onClick={() => handleRemoveChild(index)} className="w-9 h-9 flex justify-center items-center rounded-lg text-red-500 hover:bg-red-50 transition-colors">
                      ✕
                    </button>
                  </div>
                ))}
                {childNames.length === 0 && (
                  <p className="text-xs text-gray-400 italic bg-gray-50 p-3 rounded-lg text-center">No child menus added.</p>
                )}
              </div>
            </div>

            {/* Action Buttons */}
            <div className="flex justify-end gap-3 mt-4 pt-4 border-t border-gray-100">
              <button onClick={() => setIsMenuModalOpen(false)} className="px-4 py-2 text-sm text-gray-600 font-medium hover:bg-gray-100 rounded-lg transition-colors">
                Cancel
              </button>
              <button onClick={handleCreateMenu} className="px-6 py-2 text-sm text-white bg-[#117180]  hover:bg-[#028497]  font-medium rounded-lg transition-colors shadow-md shadow-[#00b074]/20">
                Confirm Create
              </button>
            </div>
          </div>
        </div>
      )}

      {/* MAIN WRAPPER */}
      <div className="flex-1 flex flex-col min-w-0">
        
        {/* TOP BAR  */}
        <header className="h-[60px] bg-white flex items-center justify-end px-6 flex-shrink-0">
        </header>

        {/* Tab bar */}
        {isMounted && openTabs.length > 0 && (
          <div 
            className="bg-white border-b border-gray-200 flex px-2 pt-2 gap-1 overflow-x-auto flex-shrink-0 scrollbar-hide"
            onDragLeave={handleDragLeave} 
          >
            {openTabs.map((tab, index) => {
              const isActive = activeTab === tab.path;
              
              return (
                <div 
                  key={tab.path}
                  draggable
                  onDragStart={(e) => handleDragStart(e, index)}
                  onDragOver={(e) => handleDragOver(e, index)}
                  onDrop={(e) => handleDrop(e, index)}
                  onDragEnd={handleDragEnd}
                  onClick={() => handleTabClick(tab)}
                  className={`group flex items-center gap-2 px-4 py-2 text-sm font-medium rounded-t-lg cursor-pointer border-t border-l border-r select-none whitespace-nowrap transition-all duration-200 ${
                    isActive 
                      ? 'bg-[#03879f] text-white border-gray-200 border-b-[#f4f7f6] relative top-[1px]' 
                      : 'bg-gray-100 text-gray-500 border-transparent hover:bg-gray-100'
                  }`}
                >
                  {tab.title}
                  <button 
                    onClick={(e) => handleCloseTab(e, tab.path)}
                    className={`ml-1 w-5 h-5 flex items-center justify-center rounded-full transition-colors ${isActive ? 'text-white hover:bg-[#00b074]/10' : 'text-gray-400 opacity-0 group-hover:opacity-100 hover:bg-gray-200'}`}
                  >
                    ×
                  </button>
                </div>
              );
            })}
          </div>
        )}

        {/* Welcome Page*/}
        <main className="flex-1 overflow-x-hidden overflow-y-auto bg-[#f4f7f6] p-6 relative">
          {isMounted && openTabs.length === 0 ? (
            <WelcomePage />
          ) : (
            children
          )}
        </main>
      </div>
      
    </div>
  );
}