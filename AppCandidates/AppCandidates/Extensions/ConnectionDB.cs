using Microsoft.EntityFrameworkCore;

namespace AppCandidates.Extensions
{
    public static class ConnectionDB
    {
        public static void AddAppDbContextWithSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Db"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    }
                )
            );
        }
    }
}
