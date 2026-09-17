using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Extensions;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;
using THUCTAP.Mappers;

namespace THUCTAP.Repos
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<OrderResponseDto>> GetAllAsync(OrderFilterRequest filter)
        {
            // Join với bảng CustomerMaster để lấy được tên Khách hàng ra ngoài DataGrid (Hình 1)
            var query = _context.Order
                .Include(o => o.customer)
               
                .AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.orderNumber))
                    query = query.Where(x => x.orderNumber.Contains(filter.orderNumber));
                if (filter.customerId.HasValue && filter.customerId.Value > 0)
                    query = query.Where(x => x.customerId == filter.customerId.Value);
                if (filter.id > 0)
                    query = query.Where(x => x.id == filter.id);
            }

            var pagedRawData = await query
                .AsNoTracking()
                .OrderByDescending(x => x.id)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawData.Map(x => x.ToOrderResponse());
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            return await _context.Order
                .Include(o => o.customer)
                
                .FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task CreateAsync(Order entity)
        {
            _context.Order.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Order entity)
        {
            _context.Order.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order entity)
        {
            _context.Order.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}