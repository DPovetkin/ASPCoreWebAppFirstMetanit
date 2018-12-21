using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ServicesLifeCycle.Services;

// AddSingleton
// AddSingleton создает один объект для всех последующих запросов, при этом объект создается только тогда, когда он непосредственно необходим.
// Этот метод имеет все те же перегруженые версии, что и AddTransient и AddScoped.

// Для применения AddSingleton изменим метод ConfigureServices():

namespace ServicesLifeCycle
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICounter, RandomCounter>();
            services.AddSingleton<CounterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<CounterMiddleware>();

        }
    }
}
