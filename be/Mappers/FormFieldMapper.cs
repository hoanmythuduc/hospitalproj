using Microsoft.Data.SqlClient;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class FormFieldMapper
    {
        public static FormField ToFormField(this FormFieldRequest request)
        {
            return new FormField
            {
                label = request.label,
                field = request.field,
                entityName = request.entityName,
                type = request.type,
                colSpan = request.colSpan,
                option = request.option,
                sortOrder = request.sortOrder,
                isSearchAble = request.isSearchAble,
                isShowInForm = request.isShowInForm,
                isShowInList = request.isShowInList,
                subField = request.subField,
                tagField = request.tagField,
                tabName = request.tabName,
                endPoint = request.endPoint,
                menuId = request.menuId
              
            };
        }

      
        public static void UpdateFormField(this FormField field, FormFieldRequest request)
        {
            field.label = request.label;
            field.field = request.field;
            field.entityName = request.entityName;
            field.type = request.type;
            field.colSpan = request.colSpan;
            field.option = request.option;
            field.sortOrder = request.sortOrder;
            field.isSearchAble = request.isSearchAble;
            field.isShowInForm = request.isShowInForm;
            field.isShowInList = request.isShowInList;
            field.subField = request.subField;
            field.tagField = request.tagField;
            field.tabName = request.tabName;
            field.endPoint = request.endPoint;
            field.menuId = request.menuId;
        }
    }
}