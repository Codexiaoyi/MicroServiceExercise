using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareDemo.Middlewares
{
    class MyMiddleware
    {
        RequestDelegate _next;
        ILogger _logger;
        public MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        //只要有这个方法并且签名一致，就会被框架识别为中间件
        public async Task InvokeAsync(HttpContext context)
        {
            using (_logger.BeginScope("TraceIdentifier:{TraceIdentifier}", context.TraceIdentifier))
            {
                
                _logger.LogDebug("开始执行");
                await _next(context);
                await context.Response.WriteAsync("aaa");
                _logger.LogDebug("结束执行");
            }
        }
    }
}
