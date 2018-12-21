using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ServicesLifeCycle.Services;

// Transient: при каждом обращении к сервису создается новый объект сервиса.
// В течение одного запроса может быть несколько обращений к сервису, соответственно при каждом обращении будет создаваться новый объект.
// Подобная модель жизненного цикла наиболее подходит для легковесных сервисов, которые не хранят данных о состоянии

// В нашем случае CounterMiddleware получает объект ICounter, для которого создается один экземпляр класса RandomCounter.
// CounterMiddleware также получает объект CounterService, который также использует ICounter.
// И для этого ICounter будет создаваться второй экземпляр класса RandomCounter.
// Поэтому генерируемые случайные числа обоими экземплярами не совпадают. Таким образом, применение AddTransient создаст два разных объекта RandomCounter.

При втором и последующих запросах к контроллеру будут создаваться новые объекты RandomCounter.

namespace ServicesLifeCycle
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICounter, RandomCounter>();
            services.AddTransient<CounterService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<CounterMiddleware>();

        }
    }
}
