using Microsoft.Extensions.DependencyInjection;
using ProjectVR.BusinessLogic.Services;
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
        internal static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUsersRepository, UsersRepository>();
            return serviceCollection;
        }
    }
}
