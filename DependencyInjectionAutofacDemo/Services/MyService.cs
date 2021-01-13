using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionAutofacDemo.Services
{
    public interface IMyService
    {
        void ShowCode();
    }

    public class MyService : IMyService
    {
        public void ShowCode()
        {
            Console.WriteLine($"MyService.ShowCode:{GetHashCode()}");
        }
    }

    public class MyService2 : IMyService
    {
        public MyNameService NameService { get; set; }

        public void ShowCode()
        {
            Console.WriteLine($"2.ShowCode:{GetHashCode()},Property is NULL:{NameService == null}");
        }
    }

    public class MyNameService
    {

    }
}
