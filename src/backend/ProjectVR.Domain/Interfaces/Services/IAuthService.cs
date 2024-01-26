using System.Threading.Tasks;
using ProjectVR.Domain.Models;
using ProjectVR.Domain.Models.User;

namespace ProjectVR.Domain.Interfaces.Services;

public interface IAuthService
{
    /// <summary>
    ///     Авторизует пользователя и возвращает его данные
    /// </summary>
    /// <param name="username">Имя пользователя</param>
    /// <returns>Данны пользователя</returns>
    Task<UserSummary?> Login(string username);
}