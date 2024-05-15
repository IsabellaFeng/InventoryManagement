using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.DataAccess.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace InventoryManagement.DataAccess
{
    public static class DependencyInversions
    {
        public static IServiceCollection AddInventoryEF(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextFactory<InventoryDbContext>(option =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                option.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
