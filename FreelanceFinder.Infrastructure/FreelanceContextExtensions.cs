using FreelanceFinder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace FreelanceFinder.Infrastructure
{
    public static class FreelanceContextExtensions
    {
        public static void AddApplicationDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FreelanceContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("sqlServer")));
        }
    }
}
