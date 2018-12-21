using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


//При этом необязательно разделять определение сервиса в виде интерфейса и его реализацию.Сам термин "сервис" в данном 
//    случае может представлять любой объект, функциональность которого может использоваться в приложении.

//Например, определим новый класс TimeService:

namespace DIApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTimeService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, TimeService timeService)
        {            

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync($"Текущее время: {timeService?.GetTime()}");
            });
        }
    }
}
