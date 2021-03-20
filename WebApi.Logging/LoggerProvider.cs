using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Logging
{
    public class LoggerProvider : ILoggerProvider
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        public LoggerProvider(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }
        public ILogger CreateLogger(string categoryName) => new Logger(_hostingEnvironment, _configuration);
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
