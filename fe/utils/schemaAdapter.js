export const transformApiToSchema = (apiData, moduleEndpoint, moduleName) => {
  let items = [];
  if (Array.isArray(apiData)) items = apiData;
  else if (apiData?.data && Array.isArray(apiData.data)) items = apiData.data;
  else if (apiData?.data?.items && Array.isArray(apiData.data.items)) items = apiData.data.items;
  
  const sortedItems = [...items].sort((a, b) => (a.sortOrder || 0) - (b.sortOrder || 0));
  let primaryKey
  const mappedFields = sortedItems.map(item => {
    const defaultFieldConfig = {
      isShowInForm: true,
      isShowInList: true,
      isSearchAble: false,
      required: false,
      readonly: false,
      disabled: false,
      placeholder: `${item.label}...`,
    };

    let parsedValidation = {};
    if (item.validation) {
      try {
        parsedValidation = typeof item.validation === 'string' ? JSON.parse(item.validation) : item.validation;
      } catch (e) {
        console.warn(`Error parsing validation for field ${item.field}:`, e);
      }
    }

    return {
      name: item.field,
      label: item.label,
      type: item.type, 
      colSpan: item.colSpan || 12,
      entityName: item.entityName,
      isShowInForm: [true, 'true', 1, '1'].includes(item.isShowInForm !== undefined ? item.isShowInForm : defaultFieldConfig.isShowInForm),
      isShowInList: [true, 'true', 1, '1'].includes(item.isShowInList !== undefined ? item.isShowInList : defaultFieldConfig.isShowInList),
      isSearchAble: [true, 'true', 1, '1'].includes(item.isSearchAble !== undefined ? item.isSearchAble : defaultFieldConfig.isSearchAble),
      
      validation: {
        required: item.required !== undefined ? [true, 'true', 1].includes(item.required) : defaultFieldConfig.required,
        ...parsedValidation 
      },
      
      readonly: [true, 'true', 1, '1'].includes(item.readonly !== undefined ? item.readonly : defaultFieldConfig.readonly),
      disabled: [true, 'true', 1, '1'].includes(item.disabled !== undefined ? item.disabled : defaultFieldConfig.disabled),
      placeholder: item.placeholder || defaultFieldConfig.placeholder,
      dataSource: item.endpoint || null,
      tabName: item.tabName || null
    };
  });

  const displayColumns = mappedFields
    .filter(field => field.isShowInList && field.type !== 'password' && field.type !== 'tree_checkbox')
    .map(field => field.name);

  let formLayout = [];
  const fieldsWithTab = mappedFields.filter(f => f.tabName);
  
  if (fieldsWithTab.length > 0) {
    const tabMap = {};
    mappedFields.forEach(f => {
      const tName = f.tabName || 'General'; 
      if (!tabMap[tName]) tabMap[tName] = [];
      tabMap[tName].push(f.name);
    });

    formLayout = [{
      type: 'tabs',
      tabItems: Object.keys(tabMap).map(key => ({ title: key, fields: tabMap[key] }))
    }];
  } else {
    formLayout = [{
      type: 'flat',
      fields: mappedFields.filter(f => f.isShowInForm).map(f => f.name)
    }];
  }

  return {
    moduleName: moduleName,
    endpoint: moduleEndpoint,
    primaryKey: 'id', 
    actions: { canCreate: true, canEdit: true, canDelete: true, canView: true },
    fields: mappedFields,
    listConfig: { displayColumns },
    formConfig: { layout: formLayout }
  };
};