using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
//Чтобы использовать класс MessageService, он внедряется в приложение в виде сервиса.
//Поскольку это самодостаточная зависимость, которая представляет конкретный класс, то метод services.AddTransient типизируется одним этим типом MessageService.
//Но так как класс MessageService использует зависимость IMessageSender, которая передается через конструктор, то нам надо также установить и эту зависимость:
//
//services.AddTransient<IMessageSender, EmailMessageSender>();
//И когда при обработке запроса будет использоваться класс MessageService, для создания объекта этого класса будет вызываться провайдер сервисов.
//Провайдер сервисов проверят конструктор класса MessageService на наличие зависимостей.Затем создает объекты для всех используемых зависимостей и передает их в конструктор.

//В методе Configure сервис MessageService передается в качестве параметра и участвует в обработке запроса.

namespace DIApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageSender, EmailMessageSender>();
            services.AddTransient<MessageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, MessageService messageService)
        {            

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(messageService.Send());
            });
        }
    }
}
