using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTime.Domain.Abstractions
{
    public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent> where TDomainEvent : IDomainEvent
    {
        //INotificationHandler中有默认的Handle方法作为处理的方法
    }
}
