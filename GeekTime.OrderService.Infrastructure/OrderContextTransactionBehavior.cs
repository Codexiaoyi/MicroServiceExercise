using GeekTime.Infrastructure.Core.Behaviors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTime.OrderService.Infrastructure
{
    public class OrderContextTransactionBehavior<TRequest, TResponse> : TransactionBehavior<OrderContext, TRequest, TResponse>
    {
        public OrderContextTransactionBehavior(OrderContext dbContext, ILogger<OrderContextTransactionBehavior<TRequest, TResponse>> logger) : base(dbContext, logger)
        {
        }
    }
}
