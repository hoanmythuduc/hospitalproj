using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Mappers
{
    public static class OrderMapper
    {
        public static Order ToOrder(this OrderRequest request)
        {
            return new Order
            {
                orderNumber = request.orderNumber,
                orderDate = request.orderDate,
                customerId = request.customerId,
                estimatedTotal = request.estimatedTotal
            };
        }

        public static void UpdateOrder(this Order entity, OrderRequest request)
        {
            entity.orderNumber = request.orderNumber;
            entity.orderDate = request.orderDate;
            entity.customerId = request.customerId;
            entity.estimatedTotal = request.estimatedTotal;
        }

        public static OrderResponseDto ToOrderResponse(this Order entity)
        {
            return new OrderResponseDto
            {
                id = entity.id,
                orderNumber = entity.orderNumber,
                orderDate = entity.orderDate,
                customerId = entity.customerId,
                
                estimatedTotal = entity.estimatedTotal
            };
        }
    }
}