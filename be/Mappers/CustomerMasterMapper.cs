using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class CustomerMasterMapper
    {
        public static CustomerMaster ToCustomerMaster(this CustomerMasterRequest request)
        {
            return new CustomerMaster
            {
                supplierName = request.supplierName,
                supplierAddress = request.supplierAddress,
                engineerInCharge = request.engineerInCharge,
                supplierPhone = request.supplierPhone,
                supplierEmail = request.supplierEmail,
                categoryId = request.categoryId
            };
        }

        public static void UpdateCustomerMaster(this CustomerMaster entity, CustomerMasterRequest request)
        {
            entity.supplierName = request.supplierName;
            entity.supplierAddress = request.supplierAddress;
            entity.engineerInCharge = request.engineerInCharge;
            entity.supplierPhone = request.supplierPhone;
            entity.supplierEmail = request.supplierEmail;
            entity.categoryId = request.categoryId;
        }

        public static CustomerMasterResponseDto ToCustomerMasterResponse(this CustomerMaster entity)
        {
            return new CustomerMasterResponseDto
            {
                id = entity.id,
                supplierName = entity.supplierName,
                supplierAddress = entity.supplierAddress,
                engineerInCharge = entity.engineerInCharge,
                supplierPhone = entity.supplierPhone,
                supplierEmail = entity.supplierEmail,
                categoryId = entity.categoryId,
                categoryName = entity.Category?.groupName ?? ""
            };
        }
    }
}