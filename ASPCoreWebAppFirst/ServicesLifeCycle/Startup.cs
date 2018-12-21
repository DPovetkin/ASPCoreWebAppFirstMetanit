using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ServicesLifeCycle.Services;

// Использование фабрики сервисов
// Ряд перегруженных версий у всех трех методов в качестве параметра могут принимать 
// фабрику сервисов - Func<IServiceProvider, object> implementationFactory, которая управляет созданием объектов сервисов.
// Фабрика позволяет нам применить более сложную логику по созданию сервиса, например, добавить условия создания:



namespace ServicesLifeCycle
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<RandomCounter>();
            services.AddTransient<ICounter>(provider =>
           {
               var counter = provider.GetService<RandomCounter>();
               return counter;
           });


            // ли к примеру у нас есть зависимость IMessageSender и есть две ее реализации - EmailMessageSender и SmsMessageSender:
            //services.AddTransient<IMessageSender>(provider =>
            //{
            //    if (DateTime.Now.Hour >= 12)
            //        return new EmailMessageSender();
            //    else
            //        return new SMSMessageSender();
            //});

            services.AddTransient<CounterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<CounterMiddleware>();

        }
    }
}
