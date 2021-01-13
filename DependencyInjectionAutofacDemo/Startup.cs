using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using DependencyInjectionAutofacDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionAutofacDemo
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
        }

        /// <summary>
        /// Autofac的服务注册方法，在框架原生容器注册后接管
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            #region 普通的注册方式
            //builder.RegisterType<MyService>().As<IMyService>();
            #endregion

            #region 属性注入
            //需要注册相应属性
            //builder.RegisterType<MyNameService>();
            //builder.RegisterType<MyService2>().As<IMyService>().PropertiesAutowired();
            #endregion

            #region AOP注入
            //AOP面向切面编程（在不改变原有逻辑基础上，在中间插入逻辑，即从切面插入逻辑）
            //注册拦截器
            //builder.RegisterType<MyInterceptor>();
            //builder.RegisterType<MyNameService>();
            //注册服务，并用拦截器拦截,这里使用接口拦截形式，
            //如果使用类拦截器，那么需要使用虚方法，使得继承类能够重载，才可以使用类拦截器
            //builder.RegisterType<MyService2>().As<IMyService>().PropertiesAutowired().InterceptedBy(typeof(MyInterceptor)).EnableInterfaceInterceptors();
            #endregion

            #region 子容器注册
            //可以注册到名字为myscope的子容器中，这样限定了服务的作用范围
            builder.RegisterType<MyService>().InstancePerMatchingLifetimeScope("myscope");
            #endregion
        }
        public ILifetimeScope AutofacContainer { get; private set; }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //创建一个autofac的根容器作为框架的一个子容器
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            ////调用服务实例
            //var ms = AutofacContainer.Resolve<IMyService>();
            //ms.ShowCode();

            #region 子容器
            //创建子容器
            using (var myscope = AutofacContainer.BeginLifetimeScope("myscope"))
            {

            }
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
