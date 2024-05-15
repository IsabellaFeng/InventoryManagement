using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.DataAccess.Data;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.DataAccess
{
    public static class DependencyInversions
    {
        public static IServiceCollection AddInventoryEF(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextFactory<InventoryDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
