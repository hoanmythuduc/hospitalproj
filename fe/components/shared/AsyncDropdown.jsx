'use client';

import { useState, useEffect } from 'react';
import Select, { components } from 'react-select';
import CreatableSelect from 'react-select/creatable';
import { dynamicApi } from '../../api/api';

const CustomMenuList = (props) => {
  return (
    <components.MenuList {...props}>
      {props.children}
      {props.selectProps.hasMore && (
        <div
          className="p-2 text-center text-sm text-[#098392] font-medium border-t border-gray-100 hover:bg-gray-50 cursor-pointer transition-colors"
          onMouseDown={(e) => {
            e.preventDefault(); 
            e.stopPropagation();
            props.selectProps.onLoadMore();
          }}
        >
          {props.selectProps.isLoadingMore ? 'Loading...' : 'Load more...'}
        </div>
      )}
    </components.MenuList>
  );
};

export default function AsyncDropdown({ field, fieldKey, effectiveType, value, onChange, hasError }) {
  const [options, setOptions] = useState([]);
  const [page, setPage] = useState(1);
  const [hasMore, setHasMore] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [search, setSearch] = useState('');
  const [mappingConfig, setMappingConfig] = useState({ valueKey: 'id', labelKey: null });
  const [isConfigLoaded, setIsConfigLoaded] = useState(false);

  const endpoint = field.dataSource || field.endpoint;
  const isMulti = effectiveType === 'multiComboBox' || effectiveType === 'multiselectDropdown' || effectiveType === 'multiselect';
  const isCreatable = effectiveType === 'singleComboBox' || effectiveType === 'multiComboBox';

  useEffect(() => {
    const fetchMappingConfig = async () => {
      if (!endpoint) {
        setIsConfigLoaded(true);
        return;
      }

      try {
        const menus = JSON.parse(localStorage.getItem('menu') || '[]');
        const normalize = (str) => str?.toLowerCase().trim();
        const targetName = field.entityName || endpoint;
        const targetMenu = menus.find(m => normalize(m.menuLabel) === normalize(targetName) || normalize(m.menuName) === normalize(targetName));

        let valKey = 'id'; // Mặc định ID
        let labKey = null;

        if (targetMenu && targetMenu.menuId) {
          const res = await dynamicApi.getAll(`CustomField?menuId=${targetMenu.menuId}&pageIndex=1&pageSize=100`);
          if (!res.error && res.data) {
            const items = Array.isArray(res.data) ? res.data : (res.data.items || res.data.data?.items || []);
            const textFields = items.filter(item => 
              (item.type === 'text' || item.type === 'string') && 
              [true, 'true', 1, '1'].includes(item.isShowInList)
            ).sort((a, b) => (a.sortOrder || 0) - (b.sortOrder || 0));

            if (textFields.length > 0) {
              labKey = textFields[0].field;
            }

            const idFields = items.filter(item => 
              item.type === 'number' && item.field.toLowerCase().includes('id')
            );
            if (idFields.length > 0 && !items.find(i => i.field === 'id')) {
               valKey = idFields[0].field;
            }
          }
        }
        setMappingConfig({ valueKey: valKey, labelKey: labKey });
      } catch (err) {
        console.error("Error fetching dynamic mapping config:", err);
      } finally {
        setIsConfigLoaded(true);
      }
    };

    fetchMappingConfig();
  }, [endpoint, field.entityName]);

  const loadData = async (currentPage, searchQuery, isAppend = false) => {
    if (!endpoint || !isConfigLoaded) return;
    setIsLoading(true);
    try {
      const separator = endpoint.includes('?') ? '&' : '?';
      const { valueKey, labelKey } = mappingConfig;
      const searchParamKey = labelKey || fieldKey;
      const searchParam = searchQuery ? `&${searchParamKey}=${encodeURIComponent(searchQuery)}` : '';
      const url = `${endpoint}${separator}pageIndex=${currentPage}&pageSize=10${searchParam}`;
      
      const response = await dynamicApi.getAll(url);
      if (!response.error && response.data) {
        const payload = response.data.data || response.data;
        const items = Array.isArray(payload) ? payload : (payload.items || []);
        
        const formatted = items.map(item => {
          if (typeof item === 'string') return { value: item, label: item };
          const finalValue = item[valueKey] ?? item.id ?? item.categoryId ?? item.departmentCode ?? item.groupCode ?? item.code ?? item.value;
          const finalLabel = (labelKey ? item[labelKey] : null) ?? item.categoryName ?? item.productCategoryName ?? item.equipmentName ?? item.departmentName ?? item.groupName ?? item.name ?? item.label;

          return {
            ...item,
            value: finalValue,
            label: finalLabel,
          };
        });

        setOptions(prev => isAppend ? [...prev, ...formatted] : formatted);
        
        const totalPages = payload.totalPages || 1;
        setHasMore(currentPage < totalPages && items.length === 10);
      }
    } catch (err) {
      console.error("Error loading:", err);
    } finally {
      setIsLoading(false);
    }
  };

  useEffect(() => {
    if (!isConfigLoaded) return; 
    setPage(1);
    const timeoutId = setTimeout(() => {
      loadData(1, search, false);
    }, 500);
    return () => clearTimeout(timeoutId);
  }, [search, endpoint, fieldKey, isConfigLoaded]);

  const handleLoadMore = () => {
    if (!isLoading && hasMore) {
      const nextPage = page + 1;
      setPage(nextPage);
      loadData(nextPage, search, true);
    }
  };

  const SelectComponent = isCreatable ? CreatableSelect : Select;

  return (
    <SelectComponent
      isMulti={isMulti}
      options={options}
      components={{ MenuList: CustomMenuList }}
      isLoading={isLoading}
      isLoadingMore={isLoading}
      hasMore={hasMore}
      onLoadMore={handleLoadMore}
      onInputChange={(val, actionMeta) => {
        if (actionMeta.action === 'input-change') setSearch(val);
      }}
      value={
        isMulti
          ? (Array.isArray(value) ? value.map(v => options.find(o => o.value === v) || { label: v, value: v }) : [])
          : (options.find(opt => opt.value === value) || (value ? { label: value, value: value } : null))
      }
      onChange={(selected) => {
        if (isMulti) onChange(selected ? selected.map(item => item.value) : []);
        else onChange(selected ? selected.value : '');
      }}
      placeholder={field.placeholder || "Search..."}
      className={hasError ? "border-red-500 rounded border" : ""}
      styles={{ menuPortal: base => ({ ...base, zIndex: 9999 }) }}
      menuPortalTarget={typeof document !== 'undefined' ? document.body : null}
    />
  );
}