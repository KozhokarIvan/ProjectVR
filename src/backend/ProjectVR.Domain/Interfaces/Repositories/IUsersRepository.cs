using System;
using System.Threading.Tasks;
using ProjectVR.Domain.Models.User;

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
    Task<UserSummary[]> FindUsersByQuery(string query, int offset, int limit, Guid? ignoredUserGuid = null);

    /// <summary>
    ///     Возвращает массив пользователей, у которых есть хотя бы одна игра совпадающая по названию с
    ///     <paramref name="gameName" />
    ///     и хотя бы одна VR гарнитура совпадающая по названию совпадающая с <paramref name="vrSet" />
    /// </summary>
    /// <param name="gameName">Название игры. Если null, то игнорируется</param>
    /// <param name="vrSet">Название vr гарнитуры. Если null, то игнорируется</param>
    /// <param name="offset">Сколько записей пропустить</param>
    /// <param name="limit">Нужное количество записей</param>
    /// <param name="ignoredUserGuid">Guid пользователя, которого нужно игнорировать при поиске</param>
    /// <returns>Массив пользователей удовлетворяющих запросу</returns>
    Task<UserSummary[]> FindUsersByGameAndVrSet(string? gameName, string? vrSet, int offset, int limit,
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

    /// <summary>
    ///     Возвращает полную информацию о пользователе по его уникальному имени
    /// </summary>
    /// <param name="username">Имя пользователя</param>
    /// <param name="ignoredUserGuid">Guid пользователя, с которым нужно проверить статус друга</param>
    /// <returns>Пользователь. null, если пользователя с таким именем не существует</returns>
    Task<UserDetails?> GetUserDetailsByUsername(string username, Guid? ignoredUserGuid = null);

    /// <summary>
    ///     Создает пользователя и возвращает данные о нем
    /// </summary>
    /// <param name="username">Имя пользователя</param>
    /// <param name="avatar">Адрес изображения пользователя</param>
    /// <returns>Новый пользователь</returns>
    Task<UserDetails> CreateUser(string username, string? avatar);

    /// <summary>
    ///     Проверяет существует ли пользователь с таким именем
    /// </summary>
    /// <param name="username">Имя пользователя</param>
    /// <returns>Существует ли пользователь с таким именем</returns>
    Task<bool> DoesUsernameExist(string username);

    Task<UserVrSet[]> GetUserVrSets(Guid userGuid, int limit, int offset);

    Task<UserVrSet[]> GetAllUserVrSets(Guid userGuid);

    Task AddUserVrSets(Guid userGuid, UpdateUserVrSet[] vrSets);

    Task EditUserVrSets(Guid userGuid, UpdateUserVrSet[] vrSets);

    Task DetachUserVrSets(Guid userGuid, int[] vrSetIds);
}