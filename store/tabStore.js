import { create } from 'zustand';

// const saveToSession = (tabs, active) => {
//   if (typeof window !== 'undefined') {
//     sessionStorage.setItem('open_tabs', JSON.stringify(tabs));
//     sessionStorage.setItem('active_tab', active || '');
//   }
// };

const loadFromSession = () => {
  if (typeof window !== 'undefined') {
    const savedTabs = sessionStorage.getItem('open_tabs');
    const savedActive = sessionStorage.getItem('active_tab');
    return {
      openTabs: savedTabs ? JSON.parse(savedTabs) : [],
      activeTab: savedActive || null,
    };
  }
  return { openTabs: [], activeTab: null };
};

export const useTabStore = create((set, get) => ({
  ...loadFromSession(), 
  
  tabStates: {}, 

  addTab: (tab) => set((state) => {
    const isTabExists = state.openTabs.some((t) => t.path === tab.path);
    if (isTabExists) {
      //saveToSession(state.openTabs, tab.path);
      return { activeTab: tab.path };
    }
    
    const newTab = { ...tab, lastPath: tab.path }; 
    const newTabs = [...state.openTabs, newTab];
    //saveToSession(newTabs, tab.path);
    return { openTabs: newTabs, activeTab: tab.path };
  }),

  removeTab: (tabPath) => set((state) => {
    const newTabs = state.openTabs.filter((t) => t.path !== tabPath);
    let newActiveTab = state.activeTab;

    if (state.activeTab === tabPath) {
      const closedTabIndex = state.openTabs.findIndex((t) => t.path === tabPath);
      if (newTabs.length > 0) {
        const nextIndex = closedTabIndex > 0 ? closedTabIndex - 1 : 0;
        newActiveTab = newTabs[nextIndex].path;
      } else {
        newActiveTab = null; 
      }
    }

    const newStates = { ...state.tabStates };
    delete newStates[tabPath];

    //saveToSession(newTabs, newActiveTab);
    return { openTabs: newTabs, activeTab: newActiveTab, tabStates: newStates };
  }),

  setActiveTab: (tabPath) => set((state) => {
    //saveToSession(state.openTabs, tabPath);
    return { activeTab: tabPath };
  }),

  updateLastPath: (tabPath, currentUrl) => set((state) => {
    const newTabs = state.openTabs.map(tab => 
      tab.path === tabPath ? { ...tab, lastPath: currentUrl } : tab
    );
    //saveToSession(newTabs, state.activeTab);
    return { openTabs: newTabs };
  }),

  updateTabState: (tabPath, newState) => set((state) => {
    return {
      tabStates: {
        ...state.tabStates,
        [tabPath]: {
          ...(state.tabStates[tabPath] || {}), 
          ...newState 
        }
      }
    };
  }),

  reorderTabs: (startIndex, targetIndex) => set((state) => {
    const newTabs = Array.from(state.openTabs);
    const [removed] = newTabs.splice(startIndex, 1);
    let insertIndex = targetIndex;
    if (startIndex < targetIndex) {
      insertIndex -= 1;
    }
    newTabs.splice(insertIndex, 0, removed);
    //saveToSession(newTabs, state.activeTab);
    return { openTabs: newTabs };
  }),
}));