using AwesomeShop.Domain.Entities;

namespace AwesomeShop.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync (Guid id);
        Task AddAsync (Order order);
        Task UpdateAsync (Order order);
    }
}
