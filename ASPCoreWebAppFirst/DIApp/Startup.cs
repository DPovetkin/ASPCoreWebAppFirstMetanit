using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;



//Метод Invoke компонентов middleware
//Подобно тому, как зависимости передаются в метод Configure в классе Startup, точно также их можно передавать в метод Invoke компонента middleware.
// Например,определим следующий компонент: MessageMiddleware

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
            app.UseMiddleware<MessageMiddleware>();


        }
    }
}
