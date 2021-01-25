using GeekTime.Domain.Abstractions;
using GeekTime.OrderService.Domain.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTime.OrderService.Domain.Events
{
    public class OrderCreatedDomainEvent : IDomainEvent
    {
        public Order Order { get; private set; }
        public OrderCreatedDomainEvent(Order order)
        {
            this.Order = order;
        }
    }
}
