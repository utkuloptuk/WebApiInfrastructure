using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Logging
{
    public class Logger : ILogger
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public IConfiguration configuration { get; }
        public Logger(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.configuration = configuration;

        }

        public IDisposable BeginScope<TState>(TState state) => null;
        public bool IsEnabled(LogLevel logLevel) => true;

        public async void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var logPath = configuration["logPath:logPathTxt"];

            if (!System.IO.File.Exists(logPath))
            {
                using var tw = new StreamWriter(logPath);
            }
            using StreamWriter streamWriter = new StreamWriter(logPath, true);
            await streamWriter.WriteLineAsync($"{DateTime.Now} --> Log Level : {logLevel} | Event ID : {eventId.Id} | Event Name : {eventId.Name} | Formatter : {formatter(state, exception)}");
            streamWriter.Close();
            await streamWriter.DisposeAsync();
        }
    }
}
