using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectVR.BusinessLogic.Services;
using ProjectVR.DataAccess;
using ProjectVR.DataAccess.Repositories;
using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;

namespace ProjectVR.WebAPI.Extensions
{
    internal static class IServiceCollectionExtensions
    {
        internal static IServiceCollection AddBusinessLogic(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUsersService, UsersService>();
            serviceCollection.AddScoped<IAuthService, AuthService>();
            serviceCollection.AddScoped<IFriendsService, FriendsService>();
            return serviceCollection;
        }
        internal static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string connectionString =  configuration.GetConnectionString(nameof(ProjectVRDbContext));
            serviceCollection.AddDbContext<ProjectVRDbContext>(options =>
                    options.UseNpgsql(connectionString));
            serviceCollection.AddScoped<IUsersRepository, UsersRepository>();
            serviceCollection.AddScoped<IFriendsRepository, FriendsRepository>();
            return serviceCollection;
        }
    }
}
