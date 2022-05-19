using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestCreadit.Database
{
    public static class SC
    {
        public static void AddInfrastructureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<TestContext>(options => 
                options.UseMySql(configuration.GetConnectionString("TestDBConnection"), 
                    new MySqlServerVersion(new Version(5, 6, 45))));
        }
    }
}