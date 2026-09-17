using THUCTAP.Interfaces;
using THUCTAP.Mappers;
using THUCTAP.ViewModels;

namespace THUCTAP.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResult<OrderResponseDto>> GetAllAsync(OrderFilterRequest filter)
        {
            return await _repository.GetAllAsync(filter);
        }

        public async Task<OrderResponseDto> CreateAsync(OrderRequest request)
        {
            var entity = request.ToOrder();
            await _repository.CreateAsync(entity);
            return entity.ToOrderResponse();
        }

        public async Task<OrderResponseDto?> UpdateAsync(int id, OrderRequest request)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return null;

            entity.UpdateOrder(request);

            await _repository.UpdateAsync(entity);
            return entity.ToOrderResponse();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);
            return true;
        }
    }
}