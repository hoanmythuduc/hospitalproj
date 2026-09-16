//const BASE_URL = 'http://localhost:5165/api';
const BASE_URL = 'http://10.36.22.102:81/api';

export const authApi = {
  login: async (credentials: any) => {
    try {
      const res = await fetch(`${BASE_URL}/auth/login`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(credentials),
      });

      if (!res.ok) {
        return { error: 'Invalid username or password', data: null };
      }

      const responseData = await res.json();
      return { error: null, data: responseData };
    } catch (err) {
      console.error('Login error:', err);
      return { error: 'Connection error', data: null };
    }
  }
};

const getAuthHeaders = () => {
  const token = localStorage.getItem('token'); 
  return {
    'Content-Type': 'application/json',
    'Authorization': token ? `Bearer ${token}` : '',
  };
};

export const dynamicApi = {
  getAll: async (endpoint: string) => {
    // if (endpoint.includes('WaterSystem') && !endpoint.includes('CustomField')){
    //   endpoint = 'WaterSystem/1';
    //   console.log(`endpoint: ${endpoint}`);
    // }
    try {
      const res = await fetch(`${BASE_URL}/${endpoint}` , {
        method: 'GET',
        headers: getAuthHeaders(),
      });
      if (!res.ok) return { data: [], error: "Connection error!" };
      return res.json();
    } catch (err) {
      return { data: [], error: "Failed to fetch" };
    }
  },

  getById: async (endpoint: string, id: number, key?: string) => {
    try {
      const url = key ? `${BASE_URL}/${endpoint}?${key}=${id}` : `${BASE_URL}/${endpoint}/${id}`;
      const res = await fetch(url, {
        method: 'GET',
        headers: getAuthHeaders()
      });
      if (!res.ok) {
        return { data: [], error: "Connection error!" };
      }
      const responseData = await res.json();
      return {data: responseData, error: null};
    } catch (err) {
      return { data: [], error: "Failed to fetch" };
    }
  },

  create: async (endpoint: string, data: Record<string, any>) => {
    const res = await fetch(`${BASE_URL}/${endpoint}`, {
      method: 'POST',
      headers: getAuthHeaders(),
      body: JSON.stringify(data),
      });
    if (!res.ok){
      return {data: [], error: "Connection error!"}
    }
    return data;
  },

  update: async (endpoint: string, id: number, data: Record<string, any>) => {
    const res = await fetch(`${BASE_URL}/${endpoint}/${id}`, {
      method: 'PUT',
      headers: getAuthHeaders(),
      body: JSON.stringify(data),
    });
    if (!res.ok)return {data: [], error: "Connection error!"}
    console.log(JSON.stringify(res.json))
    return res.json();
  },

  delete: async (endpoint: string, id: number) => {
    const res = await fetch(`${BASE_URL}/${endpoint}/${id}`, {
      method: 'DELETE',
      headers: getAuthHeaders()
    });
    if (!res.ok)return {data: [], error: "Connection error!"}
    return true;
  }
};

export const systemApi = {
  getMenu: async (userId: number) => {
    try {
      const res = await fetch(`${BASE_URL}/User/userId=${userId}/Menu`, {
        method: 'GET',
        headers: getAuthHeaders(),
      });
      
      if (!res.ok) {
        return { error: 'Connection error', data: [] }; 
      }
      
      const responseData = await res.json();
      return { error: null, data: responseData };
    } catch (err) {
      console.error('Fetch error:', err);
      return { error: 'Connection error', data: [] };
    }
  },

  addMenu: async (menuData: Record<string, any>) => {
    try {
      const res = await fetch(`${BASE_URL}/Menu`, {
        method: 'POST',
        headers: getAuthHeaders(),
        body: JSON.stringify(menuData)
      });
      if (!res.ok) {
        return { error: 'Connection error', data: null };
      }
      const responseData = await res.json();
      return { error: null, data: responseData };
    } catch (err) {
      console.error('Add menu error:', err);
      return { error: 'Connection error', data: null };
    }
  },

  updateMenu: async (menuData: Record<string, any>, menuId: number) => {
    try {
      const res = await fetch(`${BASE_URL}/Menu/${menuId}`, {
        method: 'PUT',
        headers: getAuthHeaders(),
        body: JSON.stringify(menuData)
      })

      if (!res.ok) {
        return { error: 'Connection error', data: null };
      }
      const responseData = await res.json();
      return { error: null, data: responseData };

    } catch (err) {
      console.error('Update menu error:', err);
      return {error: 'Connection error', data: null};
    }
  },

  deleteMenu: async (menuId: number) => {
    try {
      const res = await fetch(`${BASE_URL}/Menu/${menuId}`, {
        method: 'DELETE',
        headers: getAuthHeaders()
      })

      if (!res.ok) {
        return { error: 'Connection error', data: null };
      }
      const responseData = await res.json();
      return { error: null, data: responseData };

    } catch (err) {
      console.error('Delete menu error:', err);
      return {error: 'Connection error', data: null};
    }
  },

  exportData: async (id: number, data: Record<string, any>, moduleName: string, logDate?:any) => {
    try {
      let endpoint = '';
      let requestBody = data;
      console.log(`logDate: ${logDate}`);
      
      if (moduleName === 'Equipment') {
        endpoint = `${BASE_URL}/Report/equipment/${id}/export-word`;
      } 
      else if (moduleName === 'Maintenance Schedule') {
        endpoint = `${BASE_URL}/Report/maintenance-schedule/export-word?year=${logDate}`; 
      }
      else if (moduleName === 'Maintenance Log') {
        const date = new Date(logDate);
        endpoint = `${BASE_URL}/Report/maintenance-log/export-word?equipmentId=${id}&month=${date?.getMonth() + 1}&year=${date?.getFullYear()}`;
      }
      else if (moduleName === 'Water System') {
        endpoint = `${BASE_URL}/Report/water-system-log/export-word/${id}`;
      }
      else if (moduleName === 'Equipment Usage'){
        endpoint = `${BASE_URL}/Report/equipment-usage-log/export-word/${id}`;
      }

      const res = await fetch(endpoint, {
        method: 'POST',
        headers: getAuthHeaders(),
        body: JSON.stringify(requestBody)
      });

      if (!res.ok) {
        return { error: 'Failed to export document', data: null };
      }
    
      const responseData = await res.json();
      return { error: null, data: responseData }; 
    } catch (err) {
      console.error('Export error:', err);
      return { error: 'Connection error', data: null };
    }
  }
    
};