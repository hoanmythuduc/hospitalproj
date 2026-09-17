export const getUserPermissions = () => {
  if (typeof window === 'undefined') return [];
  const userMenu = localStorage.getItem('menu');
  if (!userMenu) return [];
  
  try {
    const parsedData = JSON.parse(userMenu);
    if (Array.isArray(parsedData)) {
      return parsedData;
    }
    if (parsedData.data && Array.isArray(parsedData.data.permissions)) {
      return parsedData.data.permissions;
    }
    return parsedData.permissions || [];
    
  } catch (error) {
    console.error("Error parsing user's information:", error);
    return [];
  }
};

export const hasPermission = (moduleName, actionLabel) => {
  if (!moduleName || !actionLabel) return false;
  
  const permissions = getUserPermissions();

  const menu = permissions.find(
    (p) => p.menuLabel && p.menuLabel.toLowerCase().includes(moduleName.toLowerCase())
  );

  if (!menu || !menu.action || !Array.isArray(menu.action)) {
    return false;
  }

  const hasAction = menu.action.some(
    (act) => act.actionLabel && act.actionLabel.toLowerCase() === actionLabel.toLowerCase()
  );

  return hasAction;
};