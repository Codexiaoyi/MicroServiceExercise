using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceLearn.UserService.Extension
{
    public static class ConsulManager
    {
        public static void UseConsul(this IApplicationBuilder app, IConfiguration configuration, IConsulClient consul)
        {
            string serviceGroup = configuration["ServiceGroup"];
            string ip = configuration["ip"];
            int port = Convert.ToInt32(configuration["port"]);
            string serviceId = $"{serviceGroup}_{ip}_{port}";

            //健康检查
            var check = new AgentServiceCheck()
            {
                Interval = TimeSpan.FromSeconds(6),
                HTTP = $"http://{ip}:{port}/heartcheck",
                Timeout = TimeSpan.FromSeconds(2),
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(2)
            };

            //注册到consul
            var register = new AgentServiceRegistration()
            {
                Check = check,
                Address = ip,
                Port = port,
                Name = serviceGroup,
                ID = serviceId
            };

            consul.Agent.ServiceRegister(register);
        }
    }
}
