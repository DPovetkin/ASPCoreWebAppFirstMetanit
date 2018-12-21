using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


//Объект HttpContext.RequestServices предоставляет доступ к всем внедренным зависимостям с помощью своих методов:

//GetService<service>(): использует провайдер сервисов для создания объекта, который представляет тип service. 
//    В случае если в провайдере сервисов для данного сервиса не установлена зависимость, то возвращает значение null

//GetRequiredService<service>(): использует провайдер сервисов для создания объекта, который представляет тип service. 
//    В случае если в провайдере сервисов для данного сервиса не установлена зависимость, то генерирует исключение

namespace DIApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, EmailMessageSender>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {            

            app.Run(async (context) =>
            {
                IMessageSender messageSender = context.RequestServices.GetService<IMessageSender>();
                context.Response.ContentType = "text/html; charset=utf-8";
                await context.Response.WriteAsync(messageSender.Send());
            });
        }
    }
}
