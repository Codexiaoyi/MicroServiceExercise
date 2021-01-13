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
        /// Autofac�ķ���ע�᷽�����ڿ��ԭ������ע���ӹ�
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            #region ��ͨ��ע�᷽ʽ
            //builder.RegisterType<MyService>().As<IMyService>();
            #endregion

            #region ����ע��
            //��Ҫע����Ӧ����
            //builder.RegisterType<MyNameService>();
            //builder.RegisterType<MyService2>().As<IMyService>().PropertiesAutowired();
            #endregion

            #region AOPע��
            //AOP���������̣��ڲ��ı�ԭ���߼������ϣ����м�����߼���������������߼���
            //ע��������
            //builder.RegisterType<MyInterceptor>();
            //builder.RegisterType<MyNameService>();
            //ע����񣬲�������������,����ʹ�ýӿ�������ʽ��
            //���ʹ��������������ô��Ҫʹ���鷽����ʹ�ü̳����ܹ����أ��ſ���ʹ����������
            //builder.RegisterType<MyService2>().As<IMyService>().PropertiesAutowired().InterceptedBy(typeof(MyInterceptor)).EnableInterfaceInterceptors();
            #endregion

            #region ������ע��
            //����ע�ᵽ����Ϊmyscope���������У������޶��˷�������÷�Χ
            builder.RegisterType<MyService>().InstancePerMatchingLifetimeScope("myscope");
            #endregion
        }
        public ILifetimeScope AutofacContainer { get; private set; }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //����һ��autofac�ĸ�������Ϊ��ܵ�һ��������
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            ////���÷���ʵ��
            //var ms = AutofacContainer.Resolve<IMyService>();
            //ms.ShowCode();

            #region ������
            //����������
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
