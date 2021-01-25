using GeekTime.OrderService.Domain.OrderAggregate;
using GeekTime.OrderService.Infrastructure.Repositoties;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekTime.OrderService.Api.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        //private readonly IOrderRepository _orderRepository;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
            //_orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Port()
        {
            var address = new Address("wen san lu", "hangzhou", "310000");
            var order = new Order("xiaohong1999", "xiaohong", 25, address);

            foreach (var domainEvent in order.DomainEvents)
                await _mediator.Publish(domainEvent);
            //_orderRepository.Add(order);
            //await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            return Ok(order.Id);
        }
    }
}
