using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebApi.BLL.Concrete.DbObjectManager;
using WebApi.DAL.Abstract;
using WebApi.DAL.Concrete.EntityFramework;
using WebApi.DbObject;
using WebApi.Helper;
using WebApi.Interface.DbObjects;
using WebApi.Logging;

namespace WebApiInfrastructure
{
    public class Startup
    {
        [System.Obsolete("")]
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionStrings = Configuration.GetSection("ConnectionStrings");
            var memoryDatabaseName = connectionStrings.GetValue<string>("MemoryDatabaseName");
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiInfrastructure", Version = "v1" });
            });
            services.AddDbContext<WebApiDbContext>(options =>
options.UseInMemoryDatabase(memoryDatabaseName));
            services.AddScoped<IUserDal, EFUserDal>();
            services.AddScoped<IUserServices, UserManager>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new LoggerProvider(_hostingEnvironment, Configuration));
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiInfrastructure v1"));
            }
            app.ImplementationOthersMiddleware();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
