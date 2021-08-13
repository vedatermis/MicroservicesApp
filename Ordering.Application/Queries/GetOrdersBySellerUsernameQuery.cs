using System.Collections.Generic;
using MediatR;
using Ordering.Application.Responses;

namespace Ordering.Application.Queries
{
    public class GetOrdersBySellerUsernameQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public string UserName { get; set; }
        public GetOrdersBySellerUsernameQuery(string userName)
        {
            UserName = userName;
        }
    }
}