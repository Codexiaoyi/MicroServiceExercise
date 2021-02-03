using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GeekTime.OrderService.Infrastructure.Repositoties;
using GeekTime.OrderService.Domain.OrderAggregate;

namespace GeekTime.Ordering.API.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, long>
    {
        IOrderRepository _orderRepository;
        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task<long> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var address = new Address("wen san lu", "hangzhou", "310000");
            var order = new Order("xiaohong1999", "xiaohong", 25, address);

            //_orderRepository.Add(order);
            //await _orderRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            return order.Id;
        }
    }
}
