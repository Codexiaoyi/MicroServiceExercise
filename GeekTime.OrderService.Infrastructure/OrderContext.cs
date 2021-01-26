using GeekTime.Infrastructure.Core;
using GeekTime.OrderService.Domain.OrderAggregate;
using GeekTime.OrderService.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace GeekTime.OrderService.Infrastructure
{
    public class OrderContext : EFContext
    {
        public OrderContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
