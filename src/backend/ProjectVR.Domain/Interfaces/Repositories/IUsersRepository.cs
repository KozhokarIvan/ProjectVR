using System;
using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Repositories;

public interface IUsersRepository
{
    /// <summary>
    ///     Возвращает массив пользователей, у которых игры или вр гарнитуры совпадают со строкой поиска
    ///     <paramref name="query" />
    /// </summary>
    /// <param name="query">Строка с запросом к поиску</param>
    /// <param name="offset">Сколько записей пропустить</param>
    /// <param name="limit">Нужное количество записей</param>
    /// <param name="ignoredUserGuid">Guid пользователя, которого нужно игнорировать при поиске</param>
    /// <returns>Массив пользователей удовлетворяющих запросу</returns>
    Task<UserSummary[]> FindUsersByGameOrVrSet(string query, int offset, int limit, Guid? ignoredUserGuid = null);

    /// <summary>
    ///     Возвращает массив пользователей, у которых есть хотя бы одна игра совпадающая по названию с
    ///     <paramref name="gameName" />
    ///     и хотя бы одна VR гарнитура совпадающая по названию совпадающая с <paramref name="vrsetName" />
    /// </summary>
    /// <param name="gameName">Название игры. Если null, то игнорируется</param>
    /// <param name="vrsetName">Название vr гарнитуры. Если null, то игнорируется</param>
    /// <param name="offset">Сколько записей пропустить</param>
    /// <param name="limit">Нужное количество записей</param>
    /// <param name="ignoredUserGuid">Guid пользователя, которого нужно игнорировать при поиске</param>
    /// <returns>Массив пользователей удовлетворяющих запросу</returns>
    Task<UserSummary[]> FindUsersByGameAndVrset(string? gameName, string? vrsetName, int offset, int limit,
        Guid? ignoredUserGuid = null);

    /// <summary>
    ///     Получает список случайных пользователей
    /// </summary>
    /// <param name="numberOfUsers">Нужное количество записей</param>
    /// <param name="ignoredUserGuid">Guid пользователя, которого нужно игнорировать при поиске</param>
    /// <returns>Массив случаных пользователей длиной <paramref name="numberOfUsers" /></returns>
    Task<UserSummary[]> GetRandomUsers(int numberOfUsers, Guid? ignoredUserGuid = null);

    /// <summary>
    ///     Возвращает пользователя по его имени
    /// </summary>
    /// <param name="username">Имя пользователя</param>
    /// <returns>Пользователь. null, если пользователя с таким именем не существует</returns>
    Task<UserSummary?> GetUserByUsername(string username);
}