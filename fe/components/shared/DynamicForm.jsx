'use client';

import { useState, useEffect, useMemo, Fragment } from 'react';
import Select from 'react-select';
import CreatableSelect from 'react-select/creatable';
import { dynamicApi, systemApi } from "../../api/api";
import AsyncDropdown from './AsyncDropdown';
import TableDropdown from './TableDropdown';
import PermissionField from './PermissionField';
import { validateField, validateForm } from '../../utils/validationEngine'; 
import DocxViewer from '../shared/DocxViewer';
import { hasPermission } from '../../utils/auth';

const TYPES = [
  { value: 'text', label: 'Text' }, 
  { value: 'textarea', label: 'Textarea' }, 
  { value: 'number', label: 'Number' },
  { value: 'date', label: 'Date' },
  { value: 'time', label: 'Time' },
  { value: 'dateTime', label: 'Date Time' },
  { value: 'singleSelectDropdown', label: 'Single Select Dropdown' },
  { value: 'multiselectDropdown', label: 'Multi Select Dropdown' },
  { value: 'singleComboBox', label: "Single Combo Box"},
  { value: 'multiComboBox', label: 'Multi Combo Box'},
  { value: 'boolean', label: 'Checkbox' }
];

const parseDateString = (dateStr) => {
  if (!dateStr) return '';

  if (dateStr.includes('T') || dateStr.match(/^\d{4}-\d{2}-\d{2}/)) return dateStr;

  const parts = dateStr.split(' ');
  const datePart = parts[0];
  const timePart = parts[1] || '00:00:00';
  const dateSubParts = datePart.split('/');
  if (dateSubParts.length === 3) {
    const day = dateSubParts[0].padStart(2, '0');
    const month = dateSubParts[1].padStart(2, '0');
    const year = dateSubParts[2];
    const timeSubParts = timePart.split(':');
    const hh = (timeSubParts[0] || '00').padStart(2, '0');
    const mm = (timeSubParts[1] || '00').padStart(2, '0');
    const ss = (timeSubParts[2] || '00').padStart(2, '0');
    
    return `${year}-${month}-${day}T${hh}:${mm}:${ss}`;
  }
  
  return dateStr; 
};

export default function DynamicForm({ schema, initialData, onClose, onSave }) {
  const [formData, setFormData] = useState({});
  const [dropdownOptions, setDropdownOptions] = useState({}); 
  const [errors, setErrors] = useState({});
  const { moduleName, fields, formConfig, endpoint } = schema;
  const isUserModule = endpoint === 'UserAccount' || moduleName === 'User Account';
  const isGroupModule = endpoint === 'UserGroup' || moduleName === 'User Group';
  const normalizedFields = useMemo(() => {
    if (!fields) return [];
    return fields.map(field => {
      let parsedSubfield = [];
      const rawSub = field.subfield || field.subField;
      if (Array.isArray(rawSub)) {
        parsedSubfield = rawSub;
      } else if (typeof rawSub === 'string' && rawSub.trim() !== '') {
        try { 
          let parsed = JSON.parse(rawSub); 
          if(typeof parsed === 'string') parsed = JSON.parse(parsed);
          if (Array.isArray(parsed)) parsedSubfield = parsed;
        } catch(e) {}
      }
      return { ...field, subfield: parsedSubfield };
    });
  }, [fields]);

  const fieldMap = useMemo(() => normalizedFields.reduce((acc, field) => ({ 
    ...acc, 
    [field.name || field.field]: field 
  }), {}), [normalizedFields]);

  const groupFieldName = fieldMap['group']?.name || fieldMap['group']?.field || fieldMap['groupIds']?.name || fieldMap['groupIds']?.field;
  const [activeTab, setActiveTab] = useState(0);

  //const [templateFile, setTemplateFile] = useState(null);
  const [previewData, setPreviewData] = useState(null); 
  const [isProcessingFile, setIsProcessingFile] = useState(false);

  const downloadFromBase64 = (base64Str, fileName) => {
    const byteCharacters = atob(base64Str);
    const byteNumbers = new Array(byteCharacters.length);
    for (let i = 0; i < byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i);
    }
    const byteArray = new Uint8Array(byteNumbers);
    const blob = new Blob([byteArray], { type: 'application/vnd.openxmlformats-officedocument.wordprocessingml.document' });
    
    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.setAttribute("download", fileName || 'NhatKyBaoDuong.docx');
    document.body.appendChild(link);
    link.click();      
    link.parentNode.removeChild(link);
    window.URL.revokeObjectURL(url);
  };

  const fetchReportData = async () => {
    let recordId = formData.id;
    if (!recordId) {
      alert("Need data to export/preview!");
      return null;
    }

    setIsProcessingFile(true);
    const templateName = new Map();
    templateName.set("Equipment", "lylichthietbi.docx");
    templateName.set("Maintenance Log", "NhatKiBaoDuong.docx");
    templateName.set("Maintenance Schedule", "kehoachbaoduong.docx");
    templateName.set("Water System", "theodoilocnuoc.docx");
    templateName.set("Equipment Usage", "theodoithietbi.docx");
    const requestBody = {
      "base64Template": "",
      "templateName": templateName.get(moduleName)
    };

    try {
      const recordData = JSON.stringify(formData);
      const parsedRecordData = JSON.parse(recordData);
      let date = null;
      if (moduleName !== 'Water System'){
        if (parsedRecordData.logDate){
          date = parsedRecordData.logDate;
          recordId = parsedRecordData.equipmentId || recordId;
        }
        else if (parsedRecordData.year){
          date = parsedRecordData.year;
          recordId = parsedRecordData.equipmentId || recordId;
        }
      }
      
      console.log(`recordId: ${recordId}, requestBody: ${JSON.stringify(requestBody)}`);
      const response = await systemApi.exportData(recordId, requestBody, moduleName, date);
      if (response.error || !response.data) {
        alert("Error processing file: " + response.error);
        return null;
      }
      return response.data; 
    } catch (error) {
      console.error("System error:", error);
      alert("An error occurred while processing the file.");
      return null;
    } finally {
      setIsProcessingFile(false);
    }
  };

  const handleExportData = async () => {
    const data = await fetchReportData();
    if (data && data.fileBase64) {
      downloadFromBase64(data.fileBase64, data.fileName);
    }
  };

  const handleViewData = async () => {
    const data = await fetchReportData();
    if (data && data.fileBase64) {
      setPreviewData(data);
    }
  };

  const permissionTarget = schema.permissionKey || moduleName;
  const canReview = hasPermission(permissionTarget, 'Review');
  const canApprove = hasPermission(permissionTarget, 'Approve');
  const [isReviewed, setIsReviewed] = useState(false); 
  const [isApproved, setIsApproved] = useState(false);
  const [recordStatus, setRecordStatus] = useState('');
  const currentUserName = typeof window !== 'undefined' ? localStorage.getItem('userName') : ''; 
  const [inspector, setInspector] = useState(''); 
  const [approver, setApprover] = useState('');
  const isFormDisabled = (moduleName === 'Equipment Usage' || moduleName === 'Maintenance Log') 
    ? isReviewed 
    : (moduleName === 'Maintenance Schedule' ? isApproved : false);
  const handleReviewReport = async () => {
    const userId = Number(localStorage.getItem('userId'));
    const newValue = !isReviewed; 
    const payload = { userId: userId, isApproved: newValue };
    try {
      const response = await dynamicApi.update(endpoint, `${formData.id}/inspect`, payload);
      if (response.error) {
        alert('Error: ' + response.error);
        return;
      }
      await refreshData(); 
    } catch (err) {
      console.error(err);
    }
  };

  const handleApproveReport = async (actionType) => {
    const userId = Number(localStorage.getItem('userId'));
    const isApproveAction = actionType === 'approve'; 
    
    let payload = {};
    let actionPath = moduleName === 'Maintenance Schedule' ? 'approve' : 'review';
    
    if (moduleName === 'Maintenance Schedule') {
      payload = { approverId: userId, isApproved: isApproveAction };
    } else {
      payload = { userId: userId, isApproved: isApproveAction };
    }

    try {
      const response = await dynamicApi.update(endpoint, `${formData.id}/${actionPath}`, payload);
      if (response.error) {
        alert('Error: ' + response.error);
        return;
      }
      await refreshData(); 
    } catch (err) {
      console.error(err);
    }
  };


  const processFormData = (sourceData) => {
    let preparedData = { ...sourceData };
    normalizedFields.forEach(field => {
      const fKey = field.name || field.field;
      const isMetaSubField = fKey === 'subfield' || fKey === 'subField'; 
      const hasSubFields = field.subfield && field.subfield.length > 0; 
      const isDateType = ['date', 'datetime', 'dateTime'].includes(field.type);
      if (isDateType && preparedData[fKey]) {
        preparedData[fKey] = parseDateString(preparedData[fKey]);
      }

      if (field.type === 'boolean') {
          if (preparedData[fKey] === 'X' || preparedData[fKey] === 'x') {
            preparedData[fKey] = true;
          } else if (preparedData[fKey] === '') {
            preparedData[fKey] = false;
          }
        }

      if (isMetaSubField || hasSubFields) {
        if (typeof preparedData[fKey] === 'string' && preparedData[fKey].trim() !== '') {
          try {
            let parsed = JSON.parse(preparedData[fKey]);
            if (typeof parsed === 'string') parsed = JSON.parse(parsed);
            preparedData[fKey] = Array.isArray(parsed) ? parsed : [];
          } catch (e) {
            preparedData[fKey] = [];
          }
        }

        if (Array.isArray(preparedData[fKey]) && field.subfield) {
          preparedData[fKey] = preparedData[fKey].map(row => {
            let newRow = { ...row };
            field.subfield.forEach(sf => {
              const sfKey = sf.name || sf.field;
              const isSubDate = ['date', 'datetime', 'dateTime', 'time'].includes(sf.type);
              if (isSubDate && newRow[sfKey]) {
                newRow[sfKey] = parseDateString(newRow[sfKey]); 
              }
            });
            return newRow;
          });
        }
      }
    });

    if (isUserModule && groupFieldName && sourceData[groupFieldName]) {
      const rawGroups = sourceData[groupFieldName];
      let groupNames = Array.isArray(rawGroups) ? rawGroups : (typeof rawGroups === 'string' && rawGroups.trim() !== '' ? rawGroups.split(',').map(g => g.trim()) : [rawGroups]);

      if (dropdownOptions[groupFieldName] && dropdownOptions[groupFieldName].length > 0) {
          preparedData[groupFieldName] = groupNames.map(nameOrId => {
          const matched = dropdownOptions[groupFieldName].find(g => g.label === nameOrId || g.value === nameOrId);
          return matched ? matched.value : nameOrId;
        });
      } else {
        preparedData[groupFieldName] = groupNames;
      }
    }

    const rawStatus = sourceData.statusName || sourceData.status || '';
    const currentStatus = String(rawStatus).toLowerCase().trim();
    setRecordStatus(currentStatus);

    if (moduleName === 'Equipment Usage' || moduleName === 'Maintenance Log') {
        const isDoneInspect = currentStatus === 'pendingreview' || 
                              currentStatus === 'completed' || 
                              currentStatus === 'approved' ||
                              currentStatus === 'rejected' || 
                              !!sourceData.isInspected;
        const isDoneReview = currentStatus === 'completed' || 
                             currentStatus === 'approved' || 
                             currentStatus === 'rejected' ||
                             !!sourceData.isReviewed;
        setIsReviewed(isDoneInspect); 
        setIsApproved(isDoneReview);  
        setInspector(sourceData.inspectorName || ''); 
        setApprover(sourceData.reviewerName || '');   
    } else if (moduleName === 'Maintenance Schedule') {
        const isDoneApprove = currentStatus === 'Approved' || !!sourceData.isApproved;
        
        setIsApproved(isDoneApprove);  
        setApprover(sourceData.approverName || sourceData.reviewerName || '');
    }

    setFormData(preparedData);
  };

  useEffect(() => {
    const fetchSimpleDropdownData = async () => {
      normalizedFields.forEach(async (field) => {
        const fieldKey = field.name || field.field;
        const apiPath = field.dataSource || field.endpoint;
        if (apiPath && fieldKey.toLowerCase() === 'department') {
          try {
            const res = await dynamicApi.getAll(apiPath);
            if (res && !res.error) {
              const responseData = res.data || res;
              if (Array.isArray(responseData) && typeof responseData[0] === 'string') {
                const parsedOptions = responseData.map(str => ({ label: str, value: str }));
                setDropdownOptions(prev => ({ ...prev, [fieldKey]: parsedOptions }));
              }
            }
          } catch (err) {
            console.error(`Error fetching data for ${fieldKey}:`, err);
          }
        }
      });
    };

    fetchSimpleDropdownData();
  }, [normalizedFields]);

  useEffect(() => {
    if (initialData) {
      processFormData(initialData);
    }
  }, [initialData, dropdownOptions, isUserModule, groupFieldName, normalizedFields]);
  const refreshData = async () => {
    try {
      let fetchKey = schema.primaryKey || 'id';
      let fetchValue = formData.id;
      if (moduleName === 'Maintenance Log' || moduleName === 'Maintenance Schedule') {
        fetchKey = 'equipmentId';
        fetchValue = formData.equipmentId || formData.id;
      }

      const response = await dynamicApi.getById(endpoint, fetchValue, fetchKey);
      
      if (!response.error && response.data) {
        const apiPayload = response.data.data || response.data;
        let detailDataArray = Array.isArray(apiPayload) ? apiPayload : (apiPayload.items ? apiPayload.items : [apiPayload]);
        let detailData = detailDataArray[0];

        if (moduleName === 'Maintenance Log' || moduleName === 'Maintenance Schedule') {
          const matchedRecord = detailDataArray.find(item => item.id === formData.id);
          if (matchedRecord) detailData = matchedRecord;
        }

        if (detailData) {
          processFormData(detailData); 
        }
      }
    } catch (error) {
      console.error("Error refreshing data:", error);
    }
  };

  useEffect(() => {
    const fetchGroupPermissions = async () => {
      if (isUserModule && groupFieldName) {
        const selectedGroups = formData[groupFieldName] || [];
        const groupArray = Array.isArray(selectedGroups) ? selectedGroups : [selectedGroups];

        if (groupArray.length === 0) {
          setFormData(prev => ({ ...prev, permissions: [] }));
          return;
        }

        try {
          const res = await dynamicApi.getAll('UserGroup?pageSize=1000');
          if (res.error || !res.data) return;
          const allGroups = res.data.data?.items || res.data.items || [];
          if (!Array.isArray(allGroups) || allGroups.length === 0) return;

          const mergedMenuMap = new Map();
          groupArray.forEach(selectedG => {
            const matchedGroup = allGroups.find(g =>
              g.id === Number(selectedG) ||
              g.groupName === selectedG ||
              g.groupCode === selectedG
            );

            if (matchedGroup && Array.isArray(matchedGroup.permission)) {
              matchedGroup.permission.forEach(menu => {
                if (!mergedMenuMap.has(menu.menuId)) {
                  mergedMenuMap.set(menu.menuId, { ...menu, action: new Map() });
                }

                if (menu.action && Array.isArray(menu.action)) {
                  const existingActions = mergedMenuMap.get(menu.menuId).action;
                  menu.action.forEach(act => {
                    existingActions.set(act.actionId, act);
                  });
                }
              });
            }
          });

          const finalPayload = Array.from(mergedMenuMap.values()).map(menu => ({
            ...menu,
            action: Array.from(menu.action.values())
          }));

          setFormData(prev => ({ ...prev, permissions: finalPayload }));

        } catch (err) {
          console.error("Error fetching group permissions:", err);
        }
      }
    };

    fetchGroupPermissions();
  }, [formData[groupFieldName], isUserModule, groupFieldName]);

  const handleFieldChange = (name, value) => {
    setFormData(prev => {
      const newData = { ...prev, [name]: value };
      if (name === 'type') {
        const typeColSpanMap = {
          'textarea': 12, 'multiselect': 12, 'tree_checkbox': 12,
          'text': 6, 'number': 6,
          'date': 6, 'datetime': 6, 'dateTime': 6, 'select': 6, 'boolean': 3, 
        };
        if (typeColSpanMap[value]) {
          newData.colSpan = typeColSpanMap[value];
        }
      }
      return newData;
    });

    if (errors[name]) {
      setErrors(prev => ({ ...prev, [name]: null }));
    }
  };

  const handleAddSubRow = (fieldKey) => {
    setFormData(prev => {
      const currentList = Array.isArray(prev[fieldKey]) ? prev[fieldKey] : [];
      const fieldConfig = fieldMap[fieldKey];
      const hasSortOrder = fieldConfig?.subfield?.some(sf => sf.name === 'sortOrder' || sf.field === 'sortOrder');

      const newItem = {};
      if (hasSortOrder) {
        newItem.sortOrder = currentList.length > 0 
          ? Math.max(...currentList.map(item => Number(item.sortOrder) || 0)) + 1 
          : 1;
      }
      
      return {
        ...prev,
        [fieldKey]: [...currentList, newItem]
      };
    });
  };

  const handleRemoveSubRow = (fieldKey, rowIndex) => {
    setFormData(prev => {
      const currentList = Array.isArray(prev[fieldKey]) ? prev[fieldKey] : [];
      return {
        ...prev,
        [fieldKey]: currentList.filter((_, i) => i !== rowIndex)
      };
    });
  };

  const handleSubFieldChange = (fieldKey, rowIndex, childKey, value) => {
    setFormData(prev => {
      const currentList = [...(Array.isArray(prev[fieldKey]) ? prev[fieldKey] : [])];
      if (currentList[rowIndex]) {
        currentList[rowIndex] = { ...currentList[rowIndex], [childKey]: value };
      }
      return { ...prev, [fieldKey]: currentList };
    });
  };


  const handleBlur = (fieldName, value) => {
    const fieldConfig = fieldMap[fieldName];
    if (fieldConfig) {
      const errorMsg = validateField(value, fieldConfig);
      setErrors(prev => ({ ...prev, [fieldName]: errorMsg }));
    }
  };

  const handleSubmit = () => {
    const formErrors = validateForm(formData, normalizedFields);
    
    if (Object.keys(formErrors).length > 0) {
      setErrors(formErrors);
      return; 
    }

    let payload = { ...formData };
    
    normalizedFields.forEach(field => {
      const fKey = field.name || field.field;
      if ((fKey === 'subfield' || fKey === 'subField') && Array.isArray(payload[fKey])) {
        payload[fKey] = JSON.stringify(payload[fKey]);
      }
    });

    if (isGroupModule) {
      const groupPayload = { groupName: payload.groupName, groupCode: payload.groupCode, permission: payload.permissions || [] };
      if (payload.id) groupPayload.id = payload.id;
      onSave(groupPayload);
    } else if (isUserModule) {
      const rawGroups = payload.group || payload.groupIds || [];
      const groupArray = Array.isArray(rawGroups) ? rawGroups : [rawGroups];
      payload.groupId = groupArray.map(id => parseInt(id, 10)).filter(id => !isNaN(id) && id !== 0);
      delete payload.group; delete payload.groupIds; delete payload.permission; delete payload.permissions;
      onSave(payload);
    } else {
      onSave(payload);
    }
  };

  const handleAutoFillChange = (fieldKey, newValue, selectedRowData) => {
    setFormData(prev => {
      let newData = { ...prev, [fieldKey]: newValue };
      
      if (selectedRowData) {
        Object.keys(selectedRowData).forEach(key => {
          if (['_value', '_label', 'permissionsPayload', 'id'].includes(key)) return;
          
          if (fieldMap[key] && key !== fieldKey) {
            newData[key] = selectedRowData[key]; 
          }
        });
      }
      return newData;
    });

    if (errors[fieldKey]) {
      setErrors(prev => ({ ...prev, [fieldKey]: null }));
    }
  };

  const renderTableCellField = (subFieldConfig, parentKey, rowIndex) => {
    const fieldKey = subFieldConfig.name || subFieldConfig.field;
    const booleanFields = ['isShowInForm', 'isShowInList', 'isSearchAble'];
    const effectiveType = fieldKey === 'type' ? 'select' : (booleanFields.includes(fieldKey) ? 'boolean' : (subFieldConfig.type || 'text'));
    const effectiveOptions = fieldKey === 'type' ? TYPES : (dropdownOptions[fieldKey] || subFieldConfig.options || []);
    const rowData = (formData[parentKey] || [])[rowIndex] || {};
    const value = rowData[fieldKey];
    const baseInputClass = `w-full min-w-[120px] border border-gray-300 focus:border-[#00b074] rounded px-2.5 py-1.5 outline-none text-sm transition-colors text-gray-600 bg-white`;    const onChange = (val) => handleSubFieldChange(parentKey, rowIndex, fieldKey, val);
    const handleSubRowChange = (val, selectedRowData) => {
      setFormData(prev => {
        const currentList = [...(Array.isArray(prev[parentKey]) ? prev[parentKey] : [])];
        let rowDataObj = currentList[rowIndex] ? { ...currentList[rowIndex] } : {};
        rowDataObj[fieldKey] = val;
        if (selectedRowData) {
          Object.keys(selectedRowData).forEach(key => {
            if (!['_value', '_label', 'permissionsPayload', 'id'].includes(key) && key !== fieldKey) {
              rowDataObj[key] = selectedRowData[key];
            }
          });

          if (selectedRowData.id !== undefined) {
            if (fieldKey.toLowerCase().includes('name')) {
              const idField = fieldKey.replace(/name$/i, 'Id');
              rowDataObj[idField] = selectedRowData.id;
            }
            if (subFieldConfig.dataSource === 'UserAccount' || subFieldConfig.endpoint === 'UserAccount') {
              rowDataObj.userId = selectedRowData.id;
            }
          }
        }
        currentList[rowIndex] = rowDataObj;
        return { ...prev, [parentKey]: currentList };
      });
    };

    if (fieldKey === 'option' || fieldKey === 'options') {
      return (
        <CreatableSelect
          isMulti
          options={[]}
          value={typeof value === 'string' && value.trim() !== '' ? value.split(',').map(val => ({ label: val.trim(), value: val.trim() })) : []}
          onChange={(selected) => onChange(selected ? selected.map(item => item.value).join(',') : '')}
          placeholder="..."
          styles={{ control: base => ({...base, minHeight: '34px', fontSize: '13px'}) }}
        />
      );
    }

    const dropdownTypes = ['singleComboBox', 'multiComboBox', 'select', 'singleSelectDropdown', 'multiselect', 'multiselectDropdown'];
    
    if (dropdownTypes.includes(effectiveType)) {
      const hasExternalData = subFieldConfig.dataSource || subFieldConfig.endpoint || subFieldConfig.entityName;
      if (hasExternalData && fieldKey !== 'type') {
        return (
          <div className="min-w-[150px]">
            <TableDropdown 
              field={subFieldConfig}
              fieldKey={fieldKey}
              value={value} 
              onChange={(newValues, selectedRowData) => handleSubRowChange(newValues, selectedRowData)} 
              hasError={false}
            />
          </div>
        );
      }

      const isMulti = effectiveType.includes('multi');
      return (
        <Select 
          isMulti={isMulti}
          options={effectiveOptions} 
          value={isMulti
            ? (Array.isArray(value) ? value.map(v => effectiveOptions.find(o => o.value === v)) : [])
            : (effectiveOptions.find(opt => opt.value === value) || null)}
          onChange={(selected) => onChange(isMulti ? (selected ? selected.map(item => item.value) : []) : (selected ? selected.value : ''))} 
          menuPortalTarget={document.body}
          styles={{ 
            menuPortal: base => ({ ...base, zIndex: 9999 }), 
            control: base => ({...base, minHeight: '34px', fontSize: '13px', minWidth: '150px'}) 
          }}
        />
      );
    }

    if (effectiveType === 'text' || effectiveType === 'string' || effectiveType === 'email' || effectiveType === 'password') {
      return <input type={effectiveType === 'string' ? 'text' : effectiveType} value={value || ''} onChange={(e) => onChange(e.target.value)} className={baseInputClass} />;
    }

    if (effectiveType === 'date' || effectiveType === 'datetime' || effectiveType === 'dateTime') {
      const isDateTime = effectiveType === 'datetime' || effectiveType === 'dateTime';
      return (
        <input 
          type={isDateTime ? 'datetime-local' : 'date'}
          value={value ? String(value).substring(0, isDateTime ? 16 : 10) : ''} 
          onChange={(e) => {
            let val = e.target.value;
            if (val) {
              if (effectiveType === 'date') val += 'T00:00:00';
              else if (isDateTime && val.length === 16) val += ':00';
            }
            onChange(val);
          }} 
          className={baseInputClass} 
        />
      );
    }

    if (effectiveType === 'number' || effectiveType === 'int' || effectiveType === 'integer') {
      return <input type="number" value={value ?? ''} onChange={(e) => onChange(e.target.value === '' ? '' : Number(e.target.value))}  className={baseInputClass} />;
    }

    if (effectiveType === 'boolean') {
      return <input type="checkbox" checked={[true, 'true', 1, '1', 'X', 'x'].includes(value)} onChange={(e) => onChange(e.target.checked)} className="h-4 w-4 mt-1" />;
    }

    return null;
  };

  const renderField = (fieldName) => {
    const field = fieldMap[fieldName];
    if (!field) return null;
    const fieldKey = field.name || field.field;
    
    const isHidden = [false, 'false', 0, '0'].includes(field.isShowInForm) || [false, 'false', 0, '0'].includes(field.showInForm);
    if (isHidden) return null;

    const parsedSubfield = field.subfield || [];
    const isMetaSubField = fieldKey === 'subField' || fieldKey === 'subfield';
    const excludedNestedFields = ['menuname', 'menuName', 'menuid', 'menuId', 'subfield', 'subField', 'id'];    
    
    const nestedSchemaToUse = isMetaSubField 
        ? fields.filter(f => !excludedNestedFields.includes(f.name || f.field))
        : parsedSubfield; 
        
    const rawColSpan = Number(field.colSpan);
    const colSpanValue = rawColSpan > 0 ? rawColSpan : 12; 
    const colSpanClass = {
      1: 'sm:col-span-1', 2: 'sm:col-span-2', 3: 'sm:col-span-3', 4: 'sm:col-span-4', 5: 'sm:col-span-5', 6: 'sm:col-span-6',
      7: 'sm:col-span-7', 8: 'sm:col-span-8', 9: 'sm:col-span-9', 10: 'sm:col-span-10', 11: 'sm:col-span-11', 12: 'sm:col-span-12'
    }[colSpanValue] || 'sm:col-span-12';

    if (isMetaSubField || nestedSchemaToUse.length > 0) {
      return (
        <div key={fieldKey} className={`col-span-12 ${colSpanClass} flex flex-col gap-2 mt-6 border-t border-gray-200 pt-6`}>
          <label className="text-sm font-bold text-gray-700 uppercase tracking-wider mb-2">
            {field.label}
          </label>
          
          <div className="overflow-x-auto border border-[#a0c9ca] rounded-xs shadow-sm">
            <table className="w-full text-left border-collapse">
              <thead className="bg-[#f8fbfb] border-b border-[#a0c9ca]">
                <tr>
                  <th className="p-3 text-[11px] font-bold text-gray-500 uppercase tracking-wider w-12 text-center">#</th>
                  {nestedSchemaToUse.map(sf => {
                    const sfKey = sf.name || sf.field;
                    const isHiddenSf = [false, 'false', 0, '0'].includes(sf.isShowInForm) || [false, 'false', 0, '0'].includes(sf.showInForm);
                    if (isHiddenSf) return null;
                    return (
                      <th key={sfKey} className="p-3 text-[11px] font-bold text-gray-500 uppercase tracking-wider min-w-[120px]">
                        {sf.label}
                      </th>
                    );
                  })}
                  <th className="p-3 text-[11px] font-bold text-gray-500 uppercase tracking-wider text-center w-16">Delete</th>
                </tr>
              </thead>
              <tbody>
                {(Array.isArray(formData[fieldKey]) ? formData[fieldKey] : []).map((row, rowIndex) => (
                  <tr key={rowIndex} className="border-b border-gray-100 hover:bg-gray-50 transition-colors">
                    <td className="p-3 text-xs text-gray-500 font-medium text-center align-middle">{rowIndex + 1}</td>
                    
                    {nestedSchemaToUse.map(nestedField => {
                      const sfKey = nestedField.name || nestedField.field;
                      const isHiddenSf = [false, 'false', 0, '0'].includes(nestedField.isShowInForm) || [false, 'false', 0, '0'].includes(nestedField.showInForm);
                      if (isHiddenSf) return null;
                      return (
                        <td key={sfKey} className="p-3 align-top">
                          {renderTableCellField(nestedField, fieldKey, rowIndex)}
                        </td>
                      );
                    })}
                    
                    <td className="p-3 text-center align-middle">
                      <button 
                        type="button"
                        onClick={() => handleRemoveSubRow(fieldKey, rowIndex)}
                        className="w-6 h-6 bg-red-50 text-red-500 rounded flex items-center justify-center hover:bg-red-500 hover:text-white transition-colors mx-auto"
                        title="Delete this row"
                      >✕</button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

          <button 
            type="button"
            onClick={() => handleAddSubRow(fieldKey)}
            className="mt-2 w-full py-2 border-2 border-dashed border-[#a0c9ca] rounded-lg text-[#098392] font-medium hover:bg-[#f8fbfb] hover:border-[#0b798f] hover:text-[#106f7e] transition-colors flex items-center justify-center gap-2 text-sm"
          >
            <svg width="18" height="18" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2"><path d="M12 5v14M5 12h14"/></svg>
            Add {field.label}
          </button>
        </div>
      );
    }

    const booleanFields = ['isShowInForm', 'isShowInList', 'isSearchAble'];
    const effectiveType = fieldKey === 'type' ? 'select' : (booleanFields.includes(fieldKey) ? 'boolean' : field.type);    
    let rawOptions = fieldKey === 'type' ? TYPES : (dropdownOptions[fieldKey] || field.options || []);
    let effectiveOptions = [];

    if (typeof rawOptions === 'string' && rawOptions.trim() !== '') {
      effectiveOptions = rawOptions.split(',').map(val => ({
        value: val.trim(),
        label: val.trim()
      }));
    } else if (Array.isArray(rawOptions) && rawOptions.length > 0) {
      if (typeof rawOptions[0] === 'string') {
        effectiveOptions = rawOptions.map(val => ({
          value: val.trim(),
          label: val.trim()
        }));
      } else {
        effectiveOptions = rawOptions;
      }
    } else {
      effectiveOptions = rawOptions;
    }
    if (fieldKey === 'option' || fieldKey === 'options') {
      const selectedType = formData['type'];
      if (selectedType !== 'select' && selectedType !== 'multiselect') return null; 
    }
    const hasError = !!errors[fieldKey];
    const baseInputClass = "w-full border rounded px-3 py-2 outline-none font-medium transition-colors disabled:bg-gray-50 disabled:text-gray-500 disabled:border-gray-200 disabled:cursor-not-allowed ";
    const colorClass = hasError ? "border-red-500 bg-red-50 focus:border-red-600 text-red-700" : "border-gray-300 focus:border-[#00b074] text-gray-600";
    const isDepartmentField = fieldKey.toLowerCase() === 'department';

    return (
      <div key={fieldKey} className={`col-span-12 ${colSpanClass} flex flex-col gap-1.5 mb-2`}>
        <label className="text-[11px] font-bold text-gray-500 uppercase tracking-wider">
          {field.label}
          {field.validation?.required && <span className="text-red-500 ml-1">*</span>}
        </label>
        
        <div className="relative">
          {['singleComboBox', 'multiComboBox', 'select', 'singleSelectDropdown', 'multiselect', 'multiselectDropdown'].includes(effectiveType) && (
            <div onBlur={() => handleBlur(fieldKey, formData[fieldKey])}>
              {(field.dataSource || field.endpoint) ? (
                <AsyncDropdown
                  field={field}
                  fieldKey={fieldKey}
                  effectiveType={effectiveType}
                  value={formData[fieldKey]}
                  onChange={(newValues) => handleFieldChange(fieldKey, newValues)}
                  hasError={hasError}
                  isDisabled={isFormDisabled} 
                />
              ) : (
                effectiveType.includes('ComboBox') ? (
                  <CreatableSelect
                    isDisabled={isFormDisabled} 
                    isMulti={effectiveType.includes('multi')}
                    options={effectiveOptions} 
                    value={effectiveType.includes('multi') ? (Array.isArray(formData[fieldKey]) ? formData[fieldKey].map(v => ({ label: v, value: v })) : []) : (formData[fieldKey] ? { label: formData[fieldKey], value: formData[fieldKey] } : null)}
                    onChange={(selected) => handleFieldChange(fieldKey, effectiveType.includes('multi') ? (selected ? selected.map(item => item.value) : []) : (selected ? selected.value : ''))}
                    className={hasError ? "border-red-500 rounded border" : ""}
                  />
                ) : (
                  <Select 
                    isDisabled={isFormDisabled}
                    isMulti={effectiveType.includes('multi')}
                    options={effectiveOptions} 
                    value={effectiveType.includes('multi') ? (Array.isArray(formData[fieldKey]) ? formData[fieldKey].map(v => effectiveOptions.find(o => o.value === v)) : []) : (effectiveOptions.find(opt => opt.value === formData[fieldKey]) || null)}
                    onChange={(selected) => handleFieldChange(fieldKey, effectiveType.includes('multi') ? (selected ? selected.map(item => item.value) : []) : (selected ? selected.value : ''))}
                    className={hasError ? "border-red-500 rounded" : ""}
                  />
                )
              )}
            </div>
          )}
          
          {/* Input Text */}
          {(effectiveType === 'text' || effectiveType === 'string' || effectiveType === 'email' || effectiveType === 'password') && (
            <input 
              type={effectiveType === 'string' ? 'text' : effectiveType} 
              value={Array.isArray(formData[fieldKey]) ? JSON.stringify(formData[fieldKey]) : (formData[fieldKey] || '')} 
              onChange={(e) => handleFieldChange(fieldKey, e.target.value)} 
              onBlur={(e) => handleBlur(fieldKey, e.target.value)}
              disabled={isFormDisabled} 
              className={`${baseInputClass} ${colorClass}`} 
            />
          )}

          {/* Date / Time */}
          {(effectiveType === 'date' || effectiveType === 'datetime' || effectiveType === 'dateTime' || effectiveType === 'time') && (
            <input 
              type={
                (effectiveType === 'datetime' || effectiveType === 'dateTime') ? 'datetime-local' :
                effectiveType === 'time' ? 'time' : 'date'
              } 
              value={(() => {
                if (!formData[fieldKey]) return '';
                const val = String(formData[fieldKey]);           
                if (effectiveType === 'time') {
                  return val.includes('T') ? val.split('T')[1].substring(0, 5) : val.substring(0, 5);
                }                
                return val.substring(0, (effectiveType === 'datetime' || effectiveType === 'dateTime') ? 16 : 10);
              })()}
              onChange={(e) => {
                let val = e.target.value;
                if (val) {
                  if (effectiveType === 'date') val += 'T00:00:00';
                  else if ((effectiveType === 'datetime' || effectiveType === 'dateTime') && val.length === 16) val += ':00';
                  else if (effectiveType === 'time' && val.length === 5) val += ':00'; 
                }
                handleFieldChange(fieldKey, val);
              }} 
              onBlur={(e) => handleBlur(fieldKey, e.target.value)}
              disabled={isFormDisabled} 
              className={`${baseInputClass} ${colorClass}`} 
            />
          )}

          {/* Number */}
          {(effectiveType === 'number' || effectiveType === 'int' || effectiveType === 'integer') && (
            <input
              type="number"
              value={formData[fieldKey] ?? ''}
              min={fieldKey === 'colSpan' ? 1 : field.validation?.min}
              max={fieldKey === 'colSpan' ? 12 : field.validation?.max}
              step={fieldKey === 'colSpan' ? "1" : (field.validation?.isInteger ? "1" : "any")}
              onChange={(e) => {
                const isColSpan = fieldKey === 'colSpan' || fieldKey === 'colspan';
                let val = e.target.value;
                if (val === '') {
                  handleFieldChange(fieldKey, '');
                  return;
                }
                let numVal = Number(val);
                if (isColSpan) {
                  if (numVal > 12) numVal = 12;
                  if (numVal < 1) numVal = 1;
                }
                handleFieldChange(fieldKey, numVal);
              }}
              onBlur={(e) => handleBlur(fieldKey, e.target.value === '' ? '' : Number(e.target.value))}
              onKeyDown={(e) => {
                const isColSpan = fieldKey === 'colSpan' || fieldKey === 'colspan';
                if (isColSpan && (e.key === '.' || e.key === ',' || e.key === 'e' || e.key === 'E' || e.key === '-')) {
                  e.preventDefault();
                }
              }}
              disabled={ isFormDisabled} 
              className={`${baseInputClass} ${colorClass}`}
            />
          )}

          {/* boolean */}
          {effectiveType === 'boolean' && (
            <div className="flex items-center gap-2">
              <input
                type="checkbox"
                checked={[true, 'true', 1, '1', 'X', 'x'].includes(formData[fieldKey])}
                onChange={(e) => handleFieldChange(fieldKey, e.target.checked)}
                disabled={isFormDisabled} 
                className="h-4 w-4 disabled:cursor-not-allowed disabled:opacity-60"
              />
            </div>
          )}
          
          {/* Tree Checkbox */}
          {effectiveType === 'tree_checkbox' && (
            <PermissionField 
              apiEndpoint={field.dataSource} 
              matrixId={isUserModule ? 0 : (initialData?.id || 0)} 
              externalPayload={isUserModule ? formData.permissions : formData[fieldKey]}
              onChange={newPayload => handleFieldChange(fieldKey, newPayload)}
              isReadonly={isUserModule || isFormDisabled} 
            />
          )}
        </div>
        
        {hasError && (
          <span className="text-xs text-red-500 font-medium animate-pulse">
            {errors[fieldKey]}
          </span>
        )}
      </div>
    );
  };

  return (
    <Fragment>
      <div className="fixed inset-0 z-[100] flex items-center justify-center bg-black/40 backdrop-blur-sm">
        <div className="bg-white w-full max-w-4xl rounded-lg shadow-xl flex flex-col overflow-hidden max-h-[90vh]">
          
          {/* header*/}
          <div className="flex items-center justify-between px-6 py-4 border-b border-gray-200">
            <h2 className="text-xl font-bold text-gray-800 capitalize">
              {initialData ? `Edit ${moduleName}` : `Add new ${moduleName}`}
            </h2>
            <button onClick={onClose} className="w-8 h-8 flex items-center justify-center rounded-full hover:bg-gray-100 text-gray-500 transition-colors">
              <svg width="20" height="20" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2"><path d="M18 6L6 18M6 6l12 12" /></svg>
            </button>
          </div>

          {/* body */}
          <div className="p-6 overflow-y-auto flex-1">
            <fieldset disabled={isFormDisabled} className="w-full">
              {formConfig.layout.map((section, index) => {
                if (section.type === 'flat') {
                  return (
                    <div key={index} className="grid grid-cols-12 gap-5">
                      {section.fields.map(fieldName => renderField(fieldName))}
                    </div>
                  );
                }
                if (section.type === 'tabs') {
                  return (
                    <div key={index} className="flex flex-col w-full">
                      <div className="flex border-b border-gray-200 mb-5 gap-2">
                        {section.tabItems.map((tab, tIdx) => (
                          <button
                            key={tIdx} type="button" onClick={() => setActiveTab(tIdx)}
                            className={`px-4 py-2 font-medium text-sm border-b-2 transition-colors ${
                            activeTab === tIdx ? 'border-[#9adada] text-[#0b798f]' : 'border-transparent text-gray-500 hover:text-gray-700'
                            }`}
                          >
                            {tab.title}
                          </button>
                        ))}
                      </div>
                      <div className="grid grid-cols-12 gap-5">
                        {section.tabItems[activeTab]?.fields.map(fieldName => renderField(fieldName))}
                      </div>
                    </div>
                  );
                }
                return null;
              })}
            </fieldset>
          </div>

          {/* footer */}
          <div className="flex items-center justify-between px-6 py-4 border-t border-gray-200 bg-gray-50">
            <div className="flex items-center gap-3">
              <button onClick={handleViewData} disabled={isProcessingFile} className="px-4 py-2 text-sm font-medium text-white bg-[#117180] hover:bg-[#028497] rounded transition-colors disabled:opacity-50">
                Preview
              </button>
              <button onClick={handleExportData} disabled={isProcessingFile} className="px-4 py-2 text-sm font-medium text-white bg-[#117180] hover:bg-[#028497] rounded transition-colors disabled:opacity-50">
                Export
              </button>

              {/* review/inspect */}
              {(moduleName === 'Equipment Usage' || moduleName === 'Maintenance Log') && canReview && !isApproved && (
                <button
                  onClick={handleReviewReport}
                  disabled={isProcessingFile}
                  className={`px-4 py-2 text-sm font-medium text-white rounded transition-colors disabled:opacity-50 ${isReviewed ? 'bg-[#117180] hover:bg-[#028497]' : 'bg-[#117180] hover:bg-[#028497]'}`}
                >
                  {isReviewed ? 'Undo Review' : 'Review'}
                </button>
              )}

              {/* approve/reject/undo */}
              {(moduleName === 'Equipment Usage' || moduleName === 'Maintenance Log' || moduleName === 'Maintenance Schedule') && canApprove && (
                <Fragment>
                  {((moduleName === 'Maintenance Schedule' && !isApproved) || 
                    (moduleName !== 'Maintenance Schedule' && !isApproved && isReviewed)) && (
                    <div className="flex items-center gap-2">
                      <button
                        onClick={() => handleApproveReport('reject')}
                        disabled={isProcessingFile}
                        className="px-4 py-2 text-sm font-medium text-white bg-red-500 hover:bg-red-600 rounded transition-colors disabled:opacity-50"
                      >
                        Reject
                      </button>
                      <button
                        onClick={() => handleApproveReport('approve')}
                        disabled={isProcessingFile}
                        className="px-4 py-2 text-sm font-medium text-white bg-[#117180] hover:bg-[#028497] rounded transition-colors disabled:opacity-50"
                      >
                        Approve
                      </button>
                    </div>
                  )}
                  {isApproved && (
                    <button
                      onClick={() => handleApproveReport('undo')}
                      disabled={isProcessingFile}
                      className="px-4 py-2 text-sm font-medium text-white bg-orange-500 hover:bg-orange-600 rounded transition-colors disabled:opacity-50"
                    >
                      Undo Approve
                    </button>
                  )}
                </Fragment>
              )}
            </div>

            {/* Cancel & Save */}
            <div className="flex items-center gap-3">
              <button onClick={onClose} className="px-6 py-2 text-sm font-medium text-[#0b798f]">
                Cancel
              </button>
              <button 
                onClick={handleSubmit} 
                disabled={isFormDisabled}
                className={`px-6 py-2 text-sm font-medium text-white rounded shadow-sm transition-colors ${isFormDisabled ? 'bg-gray-400 cursor-not-allowed' : 'bg-[#117180] hover:bg-[#028497]'}`}
              >
                Save changes
              </button>
            </div>
          </div>
        </div>
      </div>

      {/* view */}
      {previewData && (
        <DocxViewer 
          base64Data={previewData.fileBase64} 
          fileName={previewData.fileName}
          onClose={() => setPreviewData(null)}
          onExport={() => downloadFromBase64(previewData.fileBase64, previewData.fileName)} 
        />
      )}
    </Fragment>
  );
}