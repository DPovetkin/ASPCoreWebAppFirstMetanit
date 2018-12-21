using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIApp.Services
{
    public class TimeService
    {
        public string GetTime() => System.DateTime.Now.ToString();
    }

    //Расширения для добавления сервисов
    //Нередко для сервисов создают собственные методы добавления в виде методов расширения для интерфейса IServiceCollection.
    //Например, создадим подобный метод для сервиса TimeService:

    public static class ServiceProviderExtensions
    {
        public static void AddTimeService(this IServiceCollection services)
        {
            services.AddTransient < TimeService >();
        }
    }
}
