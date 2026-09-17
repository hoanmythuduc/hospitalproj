using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class CustomerCategoryMapper
    {
        public static CustomerCategory ToCustomerCategory(this CustomerCategoryRequest request)
        {
            return new CustomerCategory
            {
                groupName = request.groupName,
                discount = request.discount,
                isActive = request.isActive
            };
        }

        public static void UpdateCustomerCategory(this CustomerCategory entity, CustomerCategoryRequest request)
        {
            entity.groupName = request.groupName;
            entity.discount = request.discount;
            entity.isActive = request.isActive;
        }

        public static CustomerCategoryResponseDto ToCustomerCategoryResponse(this CustomerCategory entity)
        {
            return new CustomerCategoryResponseDto
            {
                id = entity.id,
                groupName = entity.groupName,
                discount = entity.discount,
                isActive = entity.isActive
            };
        }
    }
}