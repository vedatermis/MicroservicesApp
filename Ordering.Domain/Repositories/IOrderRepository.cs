using System.Collections.Generic;
using System.Threading.Tasks;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories.Base;

namespace Ordering.Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersBySellerUserName(string userName);
    }
}