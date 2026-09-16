'use client';

import { useState, useEffect } from 'react';
import DynamicTable from './DynamicTable';
import { dynamicApi } from '../../api/api';
import { transformApiToSchema } from '../../utils/schemaAdapter';

const toPascalCase = (str) => {
  if (!str) return '';
  return str.split('-').map(word => word.charAt(0).toUpperCase() + word.slice(1)).join('');
};

const toSlug = (str) => {
  if (!str) return '';
  return str.normalize("NFD").replace(/[\u0300-\u036f]/g, "")
    .replace(/[đĐ]/g, 'd')
    .toLowerCase()
    .replace(/[^a-z0-9]/g, ' ')
    .trim()
    .replace(/\s+/g, '-');
};

export default function ModuleWrapper({ moduleSlug }) {
  const [dynamicSchema, setDynamicSchema] = useState(null);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const initializeModule = async () => {
      setIsLoading(true);
      setError(null);
      
      try {
        const userPermissions = JSON.parse(localStorage.getItem('menu') || '[]');
        const normalizeSlug = (label) => label ? toSlug(label) : '';
        const currentMenu = userPermissions.find(m => normalizeSlug(m.menuLabel) === moduleSlug);
        let hasAccess = false;
        let menuId = null;
        let moduleName = "";
        let pageTabs = [];
        let permissionKey = null; 
        const endpoint = toPascalCase(moduleSlug); 
        const securityMenuSlugs = ['user-accounts', 'user-groups', 'custom-fields', 'form-actions'];
        const securityTabs = [
          { title: "Users", path: "/user-accounts", isActive: moduleSlug === 'user-accounts' },
          { title: "Groups", path: "/user-groups", isActive: moduleSlug === 'user-groups' },
          { title: "Custom Fields", path: "/custom-fields", isActive: moduleSlug === 'custom-fields' },
          { title: "Form Actions", path: "/form-actions", isActive: moduleSlug === 'form-actions' }
        ];

        if (currentMenu) {
          hasAccess = true;
          menuId = currentMenu.menuId;
          moduleName = currentMenu.menuLabel;
          permissionKey = currentMenu.menuLabel; 
          
          if (securityMenuSlugs.includes(moduleSlug)) {
            pageTabs = securityTabs;
          }
        } 
        
        if (!hasAccess || !menuId) {
          setError('This feature is not configured or you do not have permission to access it.');
          setIsLoading(false);
          return;
        }
        const response = await dynamicApi.getAll(`CustomField?menuId=${menuId}&pageIndex=1&pageSize=100`);
        
        if (!response.error && response.data) {
          let items = [];
          if (Array.isArray(response.data)) {
            items = response.data;
          } else if (response.data?.items && Array.isArray(response.data.items)) {
            items = response.data.items;
          } else if (response.data?.data?.items && Array.isArray(response.data.data.items)) {
            items = response.data.data.items;
          }
          const filteredItems = items.filter(item => Number(item.menuId) === Number(menuId));
          const fixedResponse = { data: { items: filteredItems } };
          const schema = transformApiToSchema(fixedResponse, endpoint, moduleName);
          let finalSchema = { ...schema };
          
          if (finalSchema && Array.isArray(finalSchema.fields)) {
            finalSchema.fields = finalSchema.fields.map(field => {
              const rawItem = filteredItems.find(item => item.field === (field.name || field.field));
              const rawSub = rawItem ? (rawItem.subfield || rawItem.subField) : (field.subfield || field.subField);

              let parsedSubfield = [];
              if (Array.isArray(rawSub)) {
                parsedSubfield = rawSub;
              } else if (typeof rawSub === 'string' && rawSub.trim() !== '') {
                try { 
                  let safeString = rawSub.trim();
                  if (safeString.startsWith('"') && safeString.endsWith('"')) {
                    safeString = safeString.slice(1, -1);
                  }

                  if (safeString.startsWith('[') || safeString.startsWith('{')) {
                    let parsed = JSON.parse(safeString);
                    if (typeof parsed === 'string') {
                       if (parsed.trim().startsWith('[') || parsed.trim().startsWith('{')) {
                           parsed = JSON.parse(parsed);
                       }
                    }
                    
                    if (Array.isArray(parsed)) {
                       parsedSubfield = parsed; 
                    }
                  } else {
                     console.warn(`skipped: ${rawSub}`);
                  }
                } catch (e) {
                  console.error("error parsing JSON:", e, "Data:", rawSub);
                }
              }
              
              const colSpanToUse = rawItem?.colSpan || field.colSpan;
              return { ...field, subfield: parsedSubfield, colSpan: colSpanToUse };
            });
          }
          
          finalSchema.pageTabs = pageTabs;
          if (permissionKey) {
            finalSchema.permissionKey = permissionKey;
          }
          
          setDynamicSchema(finalSchema);
        } else {
          setError('Failed to fetch field configuration.');
        }
      } catch (err) {
        console.error("Error while initializing module:", err);
        setError('Connection error while initializing module.');
      } finally {
        setIsLoading(false);
      }
    };

    if (moduleSlug) {
      initializeModule();
    }
  }, [moduleSlug]);

  if (isLoading) {
    return (
      <div className="flex flex-col items-center justify-center h-[70vh] gap-4">
        <svg className="animate-spin h-8 w-8 text-[#098392]" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"><circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle><path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path></svg>
        <span className="text-gray-500 font-medium tracking-wide animate-pulse">Loading schema configuration...</span>
      </div>
    );
  }

  if (error) {
    return (
      <div className="flex flex-col items-center justify-center h-[70vh] gap-3">
        <div className="text-lg text-red-500 font-bold bg-red-50 px-6 py-3 rounded border border-red-100">{error}</div>
      </div>
    );
  }

  if (!dynamicSchema) return null;
  return <DynamicTable schema={dynamicSchema} />;
}