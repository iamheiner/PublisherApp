using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection service, IConfiguration configuration)
        {           
            service.AddDbContext<PublisherDbContext>(options =>
                                                     options.UseSqlServer(configuration.GetConnectionString("PublisherDB"),
                                                     b => b.MigrationsAssembly(typeof(PublisherDbContext).Assembly.FullName)
                                                     )            
            );

            service.AddScoped<IApplicationDbContext>(provider => provider.GetService<PublisherDbContext>());
            return service;
        }
    }
}
