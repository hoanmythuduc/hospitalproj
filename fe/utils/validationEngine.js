const defaultRules = {
  email: {
    pattern: "^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$",
    messages: { pattern: "Vui lòng nhập email hợp lệ (vd: abc@domain.com)" }
  },
  password: {
    minLength: 6,
    messages: { minLength: "Mật khẩu phải có ít nhất 6 ký tự" }
  },
  text: { maxLength: 255 },
  textarea: { maxLength: 1000 },
  singleComboBox: { maxLength: 100 }, 
  multiComboBox: { maxSelections: 10 }
};

export const validateField = (value, fieldConfig) => {
  const defaultRule = defaultRules[fieldConfig.type] || {};
  const customRule = fieldConfig.validation || {};

  const mergedRule = {
    ...defaultRule,
    ...customRule,
    messages: {
      ...(defaultRule.messages || {}),
      ...(customRule.messages || {})
    }
  };

  const isArrayType = ['multiselectDropdown', 'multiComboBox'].includes(fieldConfig.type);
  const isDateType = ['date', 'time', 'dateTime'].includes(fieldConfig.type);
  
  //Required
  if (mergedRule.required) {
    if (isArrayType && (!Array.isArray(value) || value.length === 0)) {
      return mergedRule.messages.required || `${fieldConfig.label} is required.`;
    }
    if (!isArrayType && (value === undefined || value === null || String(value).trim() === '')) {
      return mergedRule.messages.required || `${fieldConfig.label} is required.`;
    }
  }

  if (!mergedRule.required && (value === undefined || value === null || value === '' || (Array.isArray(value) && value.length === 0))) {
    return null;
  }

  // Validate Array 
  if (isArrayType && Array.isArray(value)) {
    if (mergedRule.maxSelections && value.length > mergedRule.maxSelections) {
      return mergedRule.messages.maxSelections || `Only ${mergedRule.maxSelections} items can be selected.`;
    }
    if (fieldConfig.type === 'multiComboBox' && mergedRule.maxLength) {
       const overLengthItem = value.find(v => String(v).length > mergedRule.maxLength);
       if (overLengthItem) return `Each select must not exceed ${mergedRule.maxLength} characters.`;
    }
    return null;
  }
  const valString = String(value).trim();

  if (mergedRule.minLength && valString.length < mergedRule.minLength) {
    return mergedRule.messages.minLength || `${fieldConfig.label} must have at least ${mergedRule.minLength} characters.`;
  }

  if (mergedRule.maxLength && valString.length > mergedRule.maxLength) {
    return mergedRule.messages.maxLength || `${fieldConfig.label} does not exceed ${mergedRule.maxLength} characters.`;
  }

  if (mergedRule.pattern) {
    const regex = new RegExp(mergedRule.pattern);
    if (!regex.test(valString)) {
      return mergedRule.messages.pattern || `${fieldConfig.label} does not match the required format.`;
    }
  }

  if (fieldConfig.type === 'number') {
    const numVal = Number(value);
    if (isNaN(numVal)) return `${fieldConfig.label} must be a valid number.`;

    if (fieldConfig.field === 'colSpan'){
      if (mergedRule.isInteger && !Number.isInteger(numVal)) {
        return mergedRule.messages.isInteger || `${fieldConfig.label} must be an integer.`;
      }
      if (numVal < 1 || numVal > 12) {
        return `${fieldConfig.label} must be between 1 and 12.`;
      }
    }

    else {
      if (mergedRule.min !== undefined && numVal < mergedRule.min) {
        return mergedRule.messages.min || `Value must be at least ${mergedRule.min}.`;
      }
      if (mergedRule.max !== undefined && numVal > mergedRule.max) {
        return mergedRule.messages.max || `Value must be at most ${mergedRule.max}.`;
      }
    }
  }

  if (isDateType) {
    const dateVal = new Date(value);
    if (isNaN(dateVal.getTime())) return `${fieldConfig.label} must be a valid date.`;
    
    if (mergedRule.minDate) {
      if (dateVal < new Date(mergedRule.minDate)) return `Date must be at least ${mergedRule.minDate}.`;
    }
    if (mergedRule.maxDate) {
      if (dateVal > new Date(mergedRule.maxDate)) return `Date must be at most ${mergedRule.maxDate}.`;
    }
  }

  return null;
};

export const validateForm = (formData, fields) => {
  const errors = {};
  fields.forEach(field => {
    if (!field.isReadonly && !field.disabled) {
      const error = validateField(formData[field.name || field.field], field);
      if (error) errors[field.name || field.field] = error;
    }
  });
  return errors;
};