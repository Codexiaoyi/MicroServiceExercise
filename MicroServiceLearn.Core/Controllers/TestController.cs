using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MicroServiceLearn.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IConfiguration configuration;

        public TestController(ILogger<TestController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            int port = int.Parse(configuration["port"]);
            return port.ToString();
        }
    }
}
