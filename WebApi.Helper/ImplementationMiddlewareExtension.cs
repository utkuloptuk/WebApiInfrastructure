using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Helper.ExceptionHandler;

namespace WebApi.Helper
{
    public static class ImplementationMiddlewareExtension
    {
        public static void ImplementationOthersMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandleMiddleware>();
        }
    }
}
