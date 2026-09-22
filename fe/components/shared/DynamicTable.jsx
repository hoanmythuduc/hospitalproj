'use client';

import { useState, useMemo, useEffect, useRef } from 'react';
import Link from 'next/link';
import DynamicForm from './DynamicForm';
import { dynamicApi } from "../../api/api";
import { useCachedFetch } from '../../hooks/useCachedFetch'; 
import { cacheManager } from '../../utils/cacheManager';
import { hasPermission } from '../../utils/auth';
import { usePathname } from 'next/navigation';
import { useTabStore } from '../../store/tabStore';


export default function DynamicTable({ schema }) {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [tableData, setTableData] = useState([]);
  const [selectedRow, setSelectedRow] = useState(null);

  const pathname = usePathname(); 
  const { tabStates, updateTabState } = useTabStore();
  const savedState = tabStates[pathname] || {}
  
  const [pageIndex, setPageIndex] = useState(savedState.pageIndex || 1);
  const [pageSize, setPageSize] = useState(savedState.pageSize || 10);
  const [searchQueries, setSearchQueries] = useState(savedState.searchQueries || {});
  const [sortConfig, setSortConfig] = useState(savedState.sortConfig || { key: null, direction: 'asc' });
  const [totalRecords, setTotalRecords] = useState(0);
  const [totalPages, setTotalPages] = useState(1);
  const [debouncedSearch, setDebouncedSearch] = useState({});
  
  const [confirmBox, setConfirmBox] = useState({ isOpen: false, title: '', message: '', action: null });
  const [toast, setToast] = useState({ isOpen: false, message: '', type: 'success' });
  const [isFetchingDetail, setIsFetchingDetail] = useState(false);
  
  const { moduleName, actions, fields, listConfig, pageTabs } = schema || {};
  const endpoint = schema?.endpoint || (moduleName ? moduleName.toLowerCase().replace(' ', '-') : '');
  const permissionTarget = schema?.permissionKey || moduleName;
  const [permissions, setPermissions] = useState({ 
    canCreate: false, 
    canEdit: false, 
    canDelete: false,
    canView: false
  });

  const [subTableModal, setSubTableModal] = useState({
    isOpen: false,
    title: '',
    columns: [],
    data: []
  });

  const handleOpenSubTable = (field, dataArray) => {
    setSubTableModal({
      isOpen: true,
      title: `Chi tiết ${field.label}`,
      columns: field.subfield, 
      data: dataArray || []
    });
  };

  useEffect(() => {
    setPermissions({
      canView: hasPermission(permissionTarget, 'View'),
      canCreate: hasPermission(permissionTarget, 'Create'),
      canEdit: hasPermission(permissionTarget, 'Update'),
      canDelete: hasPermission(permissionTarget, 'Delete')
    });
  }, [permissionTarget]);

  const { canView, canCreate, canEdit, canDelete } = permissions;

  const showToast = (message, type = 'success') => {
    setToast({ isOpen: true, message, type });
    setTimeout(() => setToast(prev => ({ ...prev, isOpen: false })), 3000);
  };

  const displayFields = useMemo(() => {
    if (!fields) return [];
    return fields.filter(field => field.isShowInList !== false && field.showInList !== false).map(field => {
      let parsedSubfield = [];
      const rawSub = field.subfield || field.subField;
      if (Array.isArray(rawSub)) {
        parsedSubfield = rawSub;
      } else if (typeof rawSub === 'string' && rawSub.trim() !== '') {
        try { 
          let parsed = JSON.parse(rawSub); 
          if (typeof parsed === 'string') parsed = JSON.parse(parsed);
          if (Array.isArray(parsed)) parsedSubfield = parsed;
        } catch(e) {}
      }
      
      return { ...field, subfield: parsedSubfield };
    });
  }, [fields]);

  const isFirstRender = useRef(true);
  useEffect(() => {
    const timer = setTimeout(() => {
      setDebouncedSearch(searchQueries);
      if (isFirstRender.current) {
        isFirstRender.current = false;
      } else {
        setPageIndex(1); 
      }
    }, 500);
    return () => clearTimeout(timer);
  }, [searchQueries]);

  const fullEndpoint = useMemo(() => {
    if (!endpoint) return null;
    const params = new URLSearchParams({
      pageIndex: pageIndex.toString(),
      pageSize: pageSize.toString(),
    });

    Object.entries(debouncedSearch).forEach(([key, val]) => {
      if (val !== undefined && val !== null && String(val).trim() !== '') {
        params.append(key, String(val).trim());
      }
    });

    if (sortConfig.key) {
      params.append('sortBy', sortConfig.key);
      params.append('sortDirection', sortConfig.direction); 
    }

    const queryString = params.toString();
    return queryString ? `${endpoint}?${queryString}` : endpoint;
  }, [endpoint, pageIndex, pageSize, debouncedSearch, sortConfig]);

  const { data: responseData, isLoading, isFetching, error, refetch } = useCachedFetch(fullEndpoint);

  useEffect(() => {
    if (!responseData) return;
    
    let actualData = [];
    if (Array.isArray(responseData)) {
      actualData = responseData;
    } else if (responseData && Array.isArray(responseData.data)) {
      actualData = responseData.data;
    } else if (responseData && responseData.data && Array.isArray(responseData.data.items)) {
      actualData = responseData.data.items;
      setTotalRecords(responseData.data.totalRecords || 0);
      setTotalPages(responseData.data.totalPages || 1);
    }
    
    setTableData(actualData);
  }, [responseData]);

  if (!schema) return <div>Page configuration not found!</div>;

  const handleSearchChange = (fieldName, value) => {
    setSearchQueries(prev => ({ ...prev, [fieldName]: value }));
  };

  const handleSort = (fieldName) => {
    setSortConfig(prev => {
      if (prev.key === fieldName) {
        return { key: fieldName, direction: prev.direction === 'asc' ? 'desc' : 'asc' };
      }
      return { key: fieldName, direction: 'asc' };
    });
    setPageIndex(1);
  };

  const handleDelete = async (id) => {
    setConfirmBox({
      isOpen: true,
      title: 'Delete Confirmation',
      message: 'Are you sure you want to delete this record? This action cannot be undone.',
      action: async () => {
        setConfirmBox(prev => ({ ...prev, isOpen: false }));
        try {
          await dynamicApi.delete(endpoint, id);
          showToast('Record deleted successfully', 'success');
          cacheManager.invalidate(endpoint);
          cacheManager.invalidate('permissions');

          if (tableData.length === 1 && pageIndex > 1) {
            setPageIndex(p => p - 1); 
          } else {
            refetch(); 
          }
        } catch (err) {
          showToast('Connection error', 'error');
        }
      }
    });
  };

  const handleSave = async (formData) => {
    try {
      if (selectedRow) {
        const recordId =  selectedRow.id || selectedRow[schema.primaryKey] || selectedRow.userCode || selectedRow.groupCode;
        
        await dynamicApi.update(endpoint, recordId, formData);
        showToast('Record updated successfully', 'success');
      } else {
        await dynamicApi.create(endpoint, formData);
        showToast('New record created successfully', 'success');
      }
      
      setIsModalOpen(false);
      cacheManager.invalidate(endpoint);
      if (!selectedRow) {
        setPageIndex(1); 
      } else {
        refetch(); 
      }
    } catch (error) {
      showToast('Connection error', 'error');
    }
  };

  const handleOpenCreate = () => {
    setSelectedRow(null); 
    setIsModalOpen(true);
  };

  const handleOpenEdit = async (row) => {
    setIsFetchingDetail(true);
    try {
      if (schema.disableDetailFetch) {
        setSelectedRow(row);
      } else {
        let fetchKey = schema.primaryKey || 'id';
        let fetchValue = row[fetchKey] || row.id || row.userCode || row.groupCode;
        if (moduleName === 'Maintenance Log' || moduleName === 'Maintenance Schedule') {
          fetchKey = 'equipmentId';
          fetchValue = row.equipmentId; 
        }
        let response = await dynamicApi.getById(endpoint, fetchValue, fetchKey);
        console.log(`response: ${JSON.stringify(response)}`);

        if (!response.error && response.data) {
          const apiPayload = response.data.data || response.data;
          let detailDataArray = [];
          if (Array.isArray(apiPayload)) {
            detailDataArray = apiPayload;
          } else if (apiPayload.items !== undefined) {
            detailDataArray = apiPayload.items;
          } else {
            detailDataArray = [apiPayload];
          }
          let detailData = detailDataArray[0];
          if (moduleName === 'Maintenance Log' || moduleName === 'Maintenance Schedule') {
            const matchedRecord = detailDataArray.find(item => item.id === row.id);
            if (matchedRecord) {
              detailData = matchedRecord;
            }
          }

          setSelectedRow(detailData || row);
        } else {
          setSelectedRow(row);
        }
      }
    } catch (err) {
      console.error("Error fetching details:", err);
      setSelectedRow(row); 
    } finally {
      setIsFetchingDetail(false);
      setIsModalOpen(true);
    }
  };

  useEffect(() => {
    updateTabState(pathname, { pageIndex, pageSize, searchQueries, sortConfig });
  }, [pageIndex, pageSize, searchQueries, sortConfig, pathname, updateTabState]);


  if (!canView) {
    return (
      <div className="flex flex-col gap-6">
        {pageTabs && pageTabs.length > 0 && (
          <div className="flex gap-2">
            {pageTabs.map((tab, idx) => (
              <Link key={idx} href={tab.path} className={`px-4 py-1.5 rounded-sm text-sm border font-medium transition-colors ${tab.isActive ? 'bg-[#117180] text-white border-[#048ca6]' : 'bg-white text-[#117180] border-[#048ca6]/50 hover:[#9adada]'}`}>
                {tab.title}
              </Link>
            ))}
          </div>
        )}
        <div className="flex flex-col items-center justify-center min-h-[50vh] bg-white rounded shadow-sm border border-gray-100 p-8">
          <svg className="w-16 h-16 text-gray-300 mb-4" fill="none" viewBox="0 0 24 24" stroke="currentColor">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="1.5" d="M12 15v2m-6 4h12a2 2 0 002-2v-6a2 2 0 00-2-2H6a2 2 0 00-2 2v6a2 2 0 002 2zm10-10V7a4 4 0 00-8 0v4h8z" />
          </svg>
          <h2 className="text-xl font-bold text-gray-700">Access Denied</h2>
          <p className="text-gray-500 mt-2 text-sm text-center">
            You do not have permission to view data in the <strong>{moduleName}</strong> module. <br />
          </p>
        </div>
      </div>
    );
  }
  

  return (
    <div className="flex flex-col gap-6">
      {toast.isOpen && (
        <div className={`fixed top-6 right-6 z-[70] px-5 py-3 rounded shadow-lg text-white font-medium flex items-center gap-3 transition-all duration-300 ${toast.type === 'success' ? 'bg-[#048ca6]' : 'bg-red-500'}`}>
          {toast.message}
        </div>
      )}

      {confirmBox.isOpen && (
        <div className="fixed inset-0 z-[60] flex items-center justify-center bg-black/40 backdrop-blur-sm">
          <div className="bg-white rounded-lg shadow-xl w-full max-w-sm overflow-hidden">
            <div className="p-6">
              <h3 className="text-lg font-bold text-gray-900 mb-2">{confirmBox.title}</h3>
              <p className="text-sm text-gray-600">{confirmBox.message}</p>
            </div>
            <div className="flex items-center justify-end gap-3 px-6 py-4 bg-gray-50 border-t border-gray-100">
              <button onClick={() => setConfirmBox(prev => ({ ...prev, isOpen: false }))} className="px-4 py-2 text-sm font-medium text-gray-700 hover:bg-gray-200 rounded transition-colors">Cancel</button>
              <button onClick={confirmBox.action} className="px-4 py-2 text-sm font-medium text-white bg-red-500 hover:bg-red-600 rounded shadow-sm transition-colors">Confirm Delete</button>
            </div>
          </div>
        </div>
      )}
      
      {pageTabs && pageTabs.length > 0 && (
        <div className="flex gap-2">
          {pageTabs.map((tab, idx) => (
            <Link key={idx} href={tab.path} className={`px-4 py-1.5 rounded-sm text-sm border font-medium transition-colors ${tab.isActive ? 'bg-[#117180] text-white border-[#048ca6]' : 'bg-white text-[#117180] border-[#048ca6]/50 hover:bg-[#9adada]'}`}>
              {tab.title}
            </Link>
          ))}
        </div>
      )}

      {isFetchingDetail && (
        <div className="fixed inset-0 z-[60] flex items-center justify-center bg-black/20 backdrop-blur-sm">
          <div className="bg-white px-6 py-3 rounded shadow-lg text-gray-700 font-medium flex items-center gap-3">
             <svg className="animate-spin h-5 w-5 text-[#048ca6]" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"><circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle><path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path></svg>
             Loading data...
          </div>
        </div>
      )}

      <div className="bg-white rounded shadow-sm border border-gray-100 p-6">
        <div className="flex justify-between items-center mb-6">
          <h2 className="text-xl font-bold text-gray-700 uppercase tracking-wider flex items-center gap-3">
            {moduleName}
            {isFetching && !isLoading && (
              <svg className="animate-spin h-4 w-4 text-[#9adada]" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"><circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle><path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path></svg>
            )}
          </h2>

          {canCreate && (
            <button onClick={handleOpenCreate} className="bg-[#048ca6] hover:bg-[#117180] text-white px-4 py-2 rounded text-sm font-medium flex items-center gap-2 transition-colors">
              <span>+</span> New Entry
            </button>
          )}
        </div>

        <div className="overflow-x-auto">
          <table className="w-full min-w-max table-fixed text-left text-sm text-gray-600">
            <thead>              
              <tr className="border-b border-gray-200">
                {displayFields.map((field) => {
                  const fieldKey = field.name || field.field; 
                  return (
                  <th key={fieldKey} className="pb-3 font-semibold text-gray-700 whitespace-nowrap pr-4 cursor-pointer hover:text-[#098392] select-none min-w-[150px]" onClick={() => handleSort(fieldKey)}>
                    <div className="flex items-center gap-1.5 whitespace-normal break-words min-w-[130px] align-top">
                      {field.label}
                      <span className="flex items-center">
                        {sortConfig.key === fieldKey ? (
                          sortConfig.direction === 'asc' 
                          ? <svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" className="text-[#00b074]"><polyline points="18 15 12 9 6 15"></polyline></svg>
                          : <svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" className="text-[#00b074]"><polyline points="6 9 12 15 18 9"></polyline></svg>
                          ) : <svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" className="text-gray-300 opacity-50"><polyline points="18 15 12 9 6 15"></polyline></svg>}
                      </span>
                    </div>
                  </th>
                )})}
                <th className="pb-3 font-semibold text-gray-700 text-center w-24">Actions</th>
              </tr>
              
              <tr className="border-b border-gray-200 bg-gray-50">
                {displayFields.map((field) => {
                  const fieldKey = field.name;
                  return (
                    <th key={`search-${fieldKey}`} className="py-2 pr-4 font-normal align-middle">
                      {field.isSearchAble && (
                        <div className="flex items-center gap-2">
                          <input 
                            type="text" 
                            placeholder={`Search...`}
                            value={searchQueries[fieldKey] || ''} 
                            onChange={(e) => handleSearchChange(fieldKey, e.target.value)} 
                            onKeyDown={(e) => {
                              if (e.key === 'Enter') {
                                e.preventDefault();
                                setDebouncedSearch(prev => ({ ...prev, [fieldKey]: e.target.value }));
                                setPageIndex(1);
                              }
                            }}
                            className="border border-gray-300 rounded px-2.5 py-1.5 w-full min-w-[120px] max-w-[200px] outline-none focus:border-[#00b074] text-gray-600 text-[13px] bg-white shadow-sm" 
                          />
                        </div>
                      )}
                    </th>
                  )
                })}
                <th className="py-2"></th>
              </tr>
              </thead>

            <tbody>
              {isLoading ? (
                <tr>
                  <td colSpan={displayFields.length + 1} className="py-8 text-center text-gray-500 font-medium">
                    <div className="flex items-center justify-center gap-2">
                      <svg className="animate-spin h-5 w-5 text-[#098392]" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24"><circle className="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="4"></circle><path className="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path></svg>
                      Loading data...
                    </div>
                  </td>
                </tr>
              ) : error ? (
                <tr>
                  <td colSpan={displayFields.length + 1} className="py-8 text-center text-red-500 font-medium">Error: {error}</td>
                </tr>
              ) : tableData.length > 0 ? (
                tableData.map((row, index) => (
                  <tr key={row.id || `${row[schema.primaryKey || 'code']}-${index}`} className="border-b border-gray-100 hover:bg-gray-50">
                    {displayFields.map((field) => {
                      const fieldKey = field.name || field.field;
                      const isMetaSubField = fieldKey === 'subfield' || fieldKey === 'subField';
                      const hasSubFields = field.subfield && field.subfield.length > 0;

                      if (hasSubFields || isMetaSubField) {
                        let actualData = Array.isArray(row[fieldKey]) ? row[fieldKey] : [];
                        if (typeof row[fieldKey] === 'string' && row[fieldKey].trim() !== '') {
                          try { 
                            let parsed = JSON.parse(row[fieldKey]); 
                            if (typeof parsed === 'string') parsed = JSON.parse(parsed); 
                            actualData = Array.isArray(parsed) ? parsed : [];
                          } catch(e) {}
                        }
                        
                        const subItemCount = actualData.length;
                        const popupFieldConfig = hasSubFields ? field : {
                          ...field,
                          subfield: [
                            { field: 'field', label: 'Mã trường' },
                            { field: 'label', label: 'Tên hiển thị' },
                            { field: 'type', label: 'Kiểu dữ liệu' },
                            { field: 'colSpan', label: 'Độ rộng cột' }
                          ]
                        };

                        return (
                        <td key={`${row.id}-${fieldKey}`} className="py-4 pr-4">
                          {subItemCount > 0 ? (
                            <button 
                            onClick={() => handleOpenSubTable(popupFieldConfig, actualData)}
                            className="text-[#048ca6] hover:text-[#117180] font-medium underline underline-offset-2 text-[13px] flex items-center gap-1.5 transition-colors"
                            >
                              <svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2"><path d="M1 12s4-8 11-8 11 8 11 8-4 8-11 8-11-8-11-8z"></path><circle cx="12" cy="12" r="3"></circle></svg>
                              Detail ({subItemCount})
                            </button>
                          ) : (
                          <span className="text-gray-400 italic text-xs"></span>
                          )}
                        </td>
                        )
                      }

                      return (
                        <td key={`${row.id}-${fieldKey}`} className="py-4 pr-4">
                          {Array.isArray(row[fieldKey]) ? (
                            <div className="flex gap-1.5 flex-wrap">
                              {row[fieldKey].map((tag, idx) => {
                                let displayValue = tag;
                                if (typeof tag === 'object' && tag !== null) {
                                  displayValue = tag.name || tag.userName || tag.label || tag.value || JSON.stringify(tag);
                                }
                                return (
                                <span key={idx} className="bg-[#9adada] text-[#028497] border border-[#a0c9ca]/20 px-2.5 py-0.5 rounded text-[12px] font-medium whitespace-normal break-words shadow-sm">
                                  {displayValue}
                                  </span>
                                  );
                                })}
                            </div>
                          ) : (fieldKey === 'group' || fieldKey === 'groupIds') && typeof row[fieldKey] === 'string' && row[fieldKey].trim() !== '' ? (
                            <div className="flex gap-1.5 flex-wrap">
                              {row[fieldKey].split(',').map((tag, idx) => (
                                <span key={idx} className="bg-[#9adada] text-[#028497] border border-[#a0c9ca]/20 px-2.5 py-0.5 rounded text-[12px] font-medium whitespace-nowrap shadow-sm">
                                  {tag.trim()}
                                </span>
                              ))}
                            </div>
                          ) : (
                            <div className="text-gray-600 max-w-[500px] whitespace-normal break-words">
                              {row[fieldKey]}
                            </div>
                          )}
                        </td>
                      )
                    })}
                          <td className="py-4 text-center">
                      <div className="flex items-center justify-center gap-2">
                        {canEdit && (
                          <button onClick={() => handleOpenEdit(row)} className="w-7 h-7 rounded-full border border-gray-400 text-green-500 flex items-center justify-center hover:bg-green-50 transition-colors">✏️</button>
                        )}
                        {canDelete && (
                          <button onClick={() => handleDelete(row.id)} className="w-7 h-7 rounded-full border border-gray-400 text-red-500 flex items-center justify-center hover:bg-red-50 transition-colors">🗑</button>
                        )}
                      </div>
                    </td>
                  </tr>
                ))
              ) : (
                <tr>
                  <td colSpan={displayFields.length + 1} className="py-8 text-center text-gray-400">No results found.</td>
                </tr>
              )}
            </tbody>
          </table>
        </div>

        {/* PAGINATION */}
        <div className="flex flex-col sm:flex-row justify-between items-center mt-6 pt-4 border-t border-gray-100 gap-4">
          <div className="flex items-center gap-2 text-sm text-gray-600">
            <span>Showing</span>
            <select 
              value={pageSize} 
              onChange={(e) => { setPageSize(Number(e.target.value)); setPageIndex(1); }} 
              className="border border-gray-300 rounded px-2 py-1 outline-none focus:border-[#00b074]"
            >
              <option value={10}>10</option>
              <option value={20}>20</option>
            </select>
            <span>records / Total: <strong className="text-gray-800">{totalRecords}</strong></span>
          </div>

          <div className="flex items-center gap-2">
            <button 
              disabled={pageIndex === 1} 
              onClick={() => setPageIndex(p => p - 1)} 
              className="px-3 py-1.5 border border-gray-300 text-sm font-medium rounded text-gray-600 hover:bg-gray-50 disabled:opacity-40 disabled:cursor-not-allowed transition-colors"
            >
              Prev
            </button>
            <div className="text-sm text-gray-600 px-2 font-medium">
              Page {pageIndex} / {totalPages || 1}
            </div>
            <button 
              disabled={pageIndex >= totalPages || totalPages === 0} 
              onClick={() => setPageIndex(p => p + 1)} 
              className="px-3 py-1.5 border border-gray-300 text-sm font-medium rounded text-gray-600 hover:bg-gray-50 disabled:opacity-40 disabled:cursor-not-allowed transition-colors"
            >
              After
            </button>
          </div>
        </div>

      </div>

      {isModalOpen && (
        <DynamicForm schema={schema} initialData={selectedRow} onClose={() => setIsModalOpen(false)} onSave={handleSave} />
      )}

      {subTableModal.isOpen && (
        <div className="fixed inset-0 z-[110] flex items-center justify-center bg-black/40 backdrop-blur-sm">
           <div className="bg-white rounded-lg shadow-xl w-full max-w-6xl overflow-hidden flex flex-col max-h-[85vh]">
              {/* Modal Header */}
              <div className="flex items-center justify-between px-6 py-4 border-b border-gray-200 bg-gray-50">
                <h3 className="text-lg font-bold text-gray-800 uppercase tracking-wide">{subTableModal.title}</h3>
                <button onClick={() => setSubTableModal({ ...subTableModal, isOpen: false })} className="w-8 h-8 flex items-center justify-center rounded-full hover:bg-gray-200 text-gray-500 transition-colors">
                   <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2"><path d="M18 6L6 18M6 6l12 12"/></svg>
                </button>
              </div>
              
              {/* Modal Body*/}
              <div className="p-6 overflow-y-auto bg-white">
                <table className="w-full text-left text-sm text-gray-600 border-collapse">
                   <thead>
                      <tr className="border-b-2 border-gray-200">
                         {subTableModal.columns.map(col => (
                           <th key={col.name || col.field} className="pb-3 font-semibold text-gray-700 uppercase tracking-wider text-xs">
                             {col.label}
                           </th>
                         ))}
                      </tr>
                   </thead>
                   <tbody>
                      {subTableModal.data.map((row, idx) => (
                         <tr key={idx} className="border-b border-gray-100 hover:bg-gray-50 transition-colors">
                            {subTableModal.columns.map(col => {
                               const cKey = col.name || col.field;
                               return (
                                 <td key={cKey} className="py-3 pr-4 whitespace-normal break-words align-top">
                                    {row[cKey] !== undefined && row[cKey] !== null && row[cKey] !== '' ? (
                                      (col.type === 'date' || col.type === 'datetime') && typeof row[cKey] === 'string' 
                                        ? String(row[cKey]).split('T')[0] 
                                        : String(row[cKey])
                                    ) : (
                                      <span className="text-gray-300">-</span>
                                    )}
                                 </td>
                               );
                            })}
                         </tr>
                      ))}
                   </tbody>
                </table>
              </div>

              {/* Modal Footer */}
              <div className="px-6 py-4 border-t border-gray-200 bg-gray-50 flex justify-end">
                <button 
                  onClick={() => setSubTableModal({ ...subTableModal, isOpen: false })} 
                  className="px-6 py-2 text-sm font-medium text-gray-700 bg-white border border-gray-300 rounded shadow-sm hover:bg-gray-100 transition-colors"
                >
                  Close
                </button>
              </div>
           </div>
        </div>
      )}
    </div>
  );
}