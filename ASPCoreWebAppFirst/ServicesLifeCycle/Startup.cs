using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ServicesLifeCycle.Services;

// AddScoped
// Метод AddScoped создает один экземпляр объекта для всего запроса.
// Он имеет те же перегруженные версии, что и AddTransient.
// Для его применения изменим метод ConfigureServices() в классе Startup

// Теперь в рамках одного и того же запроса и CounterMiddleware и сервис CounterService будут использовать один и тот же объект RandomCounter.
// При следующем запросе к приложению будет генерироваться новый объект RandomCounter

namespace ServicesLifeCycle
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICounter, RandomCounter>();
            services.AddScoped<CounterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<CounterMiddleware>();

        }
    }
}
