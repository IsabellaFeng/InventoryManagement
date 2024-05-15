using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.DataAccess;
using Microsoft.Extensions.Configuration;

namespace InventoryManagement.Application
{
    public static class DependencyInversions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(DependencyInversions));
            services.AddInventoryEF(configuration);
            return services;
        }
    }
}
