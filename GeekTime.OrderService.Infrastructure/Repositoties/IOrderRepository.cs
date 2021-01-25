using GeekTime.Infrastructure.Core;
using GeekTime.OrderService.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTime.OrderService.Infrastructure.Repositoties
{
    public interface IOrderRepository : IRepository<Order, long>
    {

    }
}
