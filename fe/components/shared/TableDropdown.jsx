'use client';

import { useState, useEffect, useRef } from 'react';
import { createPortal } from 'react-dom'; 
import { dynamicApi } from '../../api/api';

export default function TableDropdown({ field, fieldKey, value, onChange, hasError }) {
  const [isOpen, setIsOpen] = useState(false);
  const [options, setOptions] = useState([]);
  const [dynamicColumns, setDynamicColumns] = useState([]); 
  const [page, setPage] = useState(1);
  const [hasMore, setHasMore] = useState(false);
  const [isLoading, setIsLoading] = useState(false);
  const [search, setSearch] = useState('');
  const [labelCache, setLabelCache] = useState({}); 
  
  const [dropdownCoords, setDropdownCoords] = useState({}); 
  
  const dropdownRef = useRef(null);
  const menuRef = useRef(null);
  
  const endpoint = field?.dataSource || field?.endpoint;
  const isMulti = ['multiselect', 'multiselectDropdown', 'multiComboBox'].includes(field?.type);
  
  const normalizedValues = isMulti 
    ? (Array.isArray(value) ? value : (typeof value === 'string' && value.trim() !== '' ? value.split(',').map(v=>v.trim()) : [])) 
    : (value !== undefined && value !== null && value !== '' ? [value] : []);

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (
        dropdownRef.current && !dropdownRef.current.contains(event.target) &&
        (!menuRef.current || !menuRef.current.contains(event.target))
      ) {
        setIsOpen(false);
      }
    };

    const handleScroll = (event) => {
      if (menuRef.current && menuRef.current.contains(event.target)) return;
      setIsOpen(false);
    };

    if (isOpen) {
      document.addEventListener('mousedown', handleClickOutside);
      window.addEventListener('scroll', handleScroll, true); 
    }

    return () => {
      document.removeEventListener('mousedown', handleClickOutside);
      window.removeEventListener('scroll', handleScroll, true);
    };
  }, [isOpen]);

  useEffect(() => {
    if (isOpen && dropdownRef.current) {
      const rect = dropdownRef.current.getBoundingClientRect();
      const viewportWidth = window.innerWidth;
      const viewportHeight = window.innerHeight;
      const padding = 24;

      let coords = {
        top: rect.bottom + 4,
        minWidth: rect.width, 
        maxHeight: Math.min(350, viewportHeight - rect.bottom - 20) 
      };

      if (rect.left > viewportWidth / 2) {
        coords.right = viewportWidth - rect.right;
        coords.maxWidth = rect.right - padding;
      } else {
        coords.left = rect.left;
        coords.maxWidth = viewportWidth - rect.left - padding;
      }
      setDropdownCoords(coords);
    }
  }, [isOpen]);

  useEffect(() => {
    const fetchDynamicColumns = async () => {
      const targetEntity = field?.entityName || endpoint;
      if (!targetEntity) return;

      if (targetEntity.toLowerCase() === 'menu') {
        setDynamicColumns([ { key: 'menuId', label: 'Menu ID' }, { key: 'menuLabel', label: 'Menu Name' } ]);
        return;
      }

      try {
        const menus = JSON.parse(localStorage.getItem('menu') || '[]');
        const normalize = (str) => str?.toLowerCase().trim();
        const targetMenu = menus.find(m => normalize(m.menuLabel) === normalize(targetEntity));

        if (targetMenu && targetMenu.menuId) {
          const res = await dynamicApi.getAll(`CustomField?menuId=${targetMenu.menuId}&pageIndex=1&pageSize=100`);
          if (!res.error && res.data) {
             const items = Array.isArray(res.data) ? res.data : (res.data.items || res.data.data?.items || []);
             const visibleCols = items
                .filter(item => [true, 'true', 1, '1'].includes(item.isShowInList))
                .sort((a, b) => (a.sortOrder || 0) - (b.sortOrder || 0))
                .map(f => ({ key: f.field, label: f.label }));
             
             if (visibleCols.length > 0) setDynamicColumns(visibleCols);
          }
        }
      } catch (err) { console.error("Error fetching dynamic columns:", err); }
    };
    fetchDynamicColumns();
  }, [field?.entityName, endpoint]);

  const loadData = async (currentPage, searchQuery, isAppend = false) => {
    if (!endpoint) return;
    setIsLoading(true);
    try {
      const separator = endpoint.includes('?') ? '&' : '?';
      let apiSearchKey = fieldKey;      
      if (fieldKey === 'group') apiSearchKey = 'groupName'; 
      
      const searchParam = searchQuery ? `&${apiSearchKey}=${encodeURIComponent(searchQuery)}` : '';
      let url = `${endpoint}${separator}pageIndex=${currentPage}&pageSize=10${searchParam}`;
      
      if (endpoint.toLowerCase() === 'menu') url = `Menu${separator}pageIndex=${currentPage}&pageSize=100${searchParam}`; 

      const response = await dynamicApi.getAll(url);
      if (!response.error && response.data) {
        let payload = response.data.data || response.data;
        if (typeof payload === 'string') payload = JSON.parse(payload);
        
        let items = Array.isArray(payload) ? payload : (payload.items || []);
        if (endpoint.toLowerCase() === 'menu') items = items.filter(item => item.parentLabel !== null);
        
        const formatted = items.map(item => {
          const keys = Object.keys(item);
          const nameKey = keys.find(k => k.toLowerCase().endsWith('name') || k.toLowerCase() === 'name' || k.toLowerCase().includes('tên'));
          
          return {
            ...item,
            _value: item[fieldKey] ?? item.id ?? item.menuId ?? item.code ?? item.value,
            _label: item[nameKey] ?? item.menuLabel ?? item.name ?? item.label ?? item[fieldKey],
          };
        });

        const newCache = { ...labelCache };
        formatted.forEach(item => {
           if (item._value !== undefined && item._label !== undefined) newCache[item._value] = item._label;
        });
        setLabelCache(newCache);
        setOptions(prev => isAppend ? [...prev, ...formatted] : formatted);
        
        const totalPages = payload.totalPages || 1;
        setHasMore(currentPage < totalPages && items.length === 10);
      }
    } catch (err) { console.error("Error TableDropdown:", err); } 
    finally { setIsLoading(false); }
  };

  useEffect(() => {
    if (!isOpen) return; 
    setPage(1);
    const timeoutId = setTimeout(() => { loadData(1, search, false); }, 500);
    return () => clearTimeout(timeoutId);
  }, [search, endpoint, fieldKey, isOpen]);

  const isChecked = (row) => normalizedValues.some(val => String(val) === String(row._value));

  const handleToggleOption = (row) => {
    if (isMulti) {
      let newValues = [...normalizedValues];
      const existingIndex = newValues.findIndex(val => String(val) === String(row._value));
      if (existingIndex !== -1) newValues.splice(existingIndex, 1); 
      else {
        newValues.push(row._value); 
        setLabelCache(prev => ({ ...prev, [row._value]: row._label }));
      }
      onChange(newValues, row); 
    } else {
      setLabelCache(prev => ({ ...prev, [row._value]: row._label }));
      onChange(row._value, row); 
      setIsOpen(false);
    }
  };

  return (
    <div className="relative w-full" ref={dropdownRef}>
      <div 
        onClick={() => setIsOpen(!isOpen)}
        className={`min-h-[38px] w-full border bg-white rounded px-3 py-1.5 cursor-pointer flex flex-wrap items-center gap-1.5 transition-colors ${hasError ? 'border-red-500 bg-red-50' : 'border-gray-300 hover:border-[#00b074]'}`}
      >
        {normalizedValues.length === 0 ? (
          <span className="text-gray-400 text-sm">{field?.placeholder || "Select data..."}</span>
        ) : (
          normalizedValues.map((val, idx) => {
            const displayLabel = labelCache[val] || val; 
            return (
              <span key={idx} className="bg-[#f0f9fa] text-[#098392] border border-[#a0c9ca] px-2 py-0.5 rounded text-[13px] font-medium flex items-center gap-1 shadow-sm">
                {displayLabel}
                <button 
                  type="button" 
                  onClick={(e) => { 
                    e.stopPropagation(); 
                    if (isMulti) onChange(normalizedValues.filter(v => v !== val), null); 
                    else onChange('', null);
                  }}
                  className="hover:text-red-500 hover:bg-red-50 rounded-full w-4 h-4 flex items-center justify-center font-bold ml-1 transition-colors leading-none"
                >×</button>
              </span>
            )
          })
        )}
      </div>

      {isOpen && typeof document !== 'undefined' && createPortal(
        <div 
          ref={menuRef}
          className="fixed z-[9999] w-max bg-white border border-gray-200 rounded shadow-lg flex flex-col"
          style={{
            top: `${dropdownCoords.top}px`,
            left: dropdownCoords.left !== undefined ? `${dropdownCoords.left}px` : 'auto',
            right: dropdownCoords.right !== undefined ? `${dropdownCoords.right}px` : 'auto',
            maxWidth: `${dropdownCoords.maxWidth}px`,
            maxHeight: `${dropdownCoords.maxHeight}px`,
            minWidth: `${dropdownCoords.minWidth}px`
          }}
        >
          <div className="p-2 border-b border-gray-100 bg-gray-50 shrink-0">
            <input 
              type="text" placeholder="Tìm kiếm..." value={search}
              onChange={(e) => setSearch(e.target.value)}
              className="w-full text-sm border border-gray-300 rounded px-2.5 py-1.5 outline-none focus:border-[#00b074]"
            />
          </div>

          <div className="overflow-auto flex-1 w-full">
            <table className="w-full text-left text-sm">
              <thead className="bg-[#f8fbfb] sticky top-0 z-10 shadow-sm">
                <tr>
                  {dynamicColumns.map((col, idx) => (
                    <th key={idx} className="p-2 text-[11px] font-bold text-gray-500 uppercase tracking-wider border-b border-[#a0c9ca] whitespace-nowrap">
                      {col.label}
                    </th>
                  ))}
                </tr>
              </thead>
              <tbody>
                {options.map((row, idx) => {
                  const active = isChecked(row);
                  return (
                    <tr 
                      key={idx} onClick={() => handleToggleOption(row)}
                      className={`border-b border-gray-50 cursor-pointer transition-colors border-l-4 ${active ? 'bg-[#e6f4f1] border-[#00b074]' : 'hover:bg-gray-50 border-transparent'}`}
                    >
                      {dynamicColumns.map((col, cIdx) => (
                        <td key={cIdx} className="p-2 text-gray-700 whitespace-nowrap">{row[col.key]}</td>
                      ))}
                    </tr>
                  );
                })}
                {options.length === 0 && !isLoading && (
                  <tr><td colSpan={dynamicColumns.length || 1} className="p-4 text-center text-gray-400 italic">Không có dữ liệu</td></tr>
                )}
              </tbody>
            </table>
          </div>
          
          {hasMore && (
            <div onClick={() => { if(!isLoading) { setPage(p => p+1); loadData(page+1, search, true); } }} className="p-2 shrink-0 text-center text-sm font-medium text-[#098392] border-t border-gray-100 bg-gray-50 hover:bg-gray-100 cursor-pointer transition-colors">
              {isLoading ? 'Loading...' : 'Load more...'}
            </div>
          )}
        </div>,
        document.body
      )}
    </div>
  );
}