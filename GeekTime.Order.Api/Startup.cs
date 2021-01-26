using GeekTime.OrderService.Infrastructure.Repositoties;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MediatR;
using System.Reflection;
using System.Threading.Tasks;
using GeekTime.OrderService.Domain.OrderAggregate;
using GeekTime.OrderService.Api.Extensions;
using GeekTime.OrderService.Infrastructure;

namespace GeekTime.OrderService.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            });
            services.AddMediatRServices();
            services.AddMySqlDomainContext(Configuration.GetValue<string>("MySql"));
            services.AddRepositories();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                });
                app.UseDeveloperExceptionPage();
            }

            //获取服务判断是否有对应数据库，没有则根据实体创建
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var dc = scope.ServiceProvider.GetService<OrderContext>();
                dc.Database.EnsureCreated();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
