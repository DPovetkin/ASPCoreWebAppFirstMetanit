﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ServicesLifeCycle.Services;

// AddSingleton
// Для создания singleton-объектов необязательно полагаться на механизм DI.Мы его можем сами создать и передать в нужный метод:

namespace ServicesLifeCycle
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {            

            RandomCounter randomCounter = new RandomCounter();
            services.AddSingleton<ICounter>(randomCounter);
            services.AddSingleton<CounterService>(new CounterService(randomCounter));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<CounterMiddleware>();

        }
    }
}
