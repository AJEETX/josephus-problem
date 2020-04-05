using Demo.Library.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Library.Infrastructure
{
    public static class DependencyService
    {
        static IServiceCollection services = new ServiceCollection();
        public static IServiceCollection GetServices()
        {
            services.AddSingleton<IChildrenInCircleService, ChildrenInCircleService>();
            return services;
        }
    }
}
