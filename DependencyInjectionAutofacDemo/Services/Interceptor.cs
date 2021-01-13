using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionAutofacDemo.Services
{
    public class MyInterceptor : IInterceptor
    {
        /// <summary>
        /// 拦截器，可以拦截方法的执行
        /// </summary>
        /// <param name="invocation"></param>
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"before method:{invocation.Method.Name} action");
            //执行被拦截方法
            invocation.Proceed();
            Console.WriteLine($"after method:{invocation.Method.Name} action");
        }
    }
}
