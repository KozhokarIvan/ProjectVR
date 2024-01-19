using System;
using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Services;

public interface IUsersService
{
    /// <summary>
    ///     Список пользователей, у которых есть либо игра либо vr гарнитура с названием, содержащим <paramref name="query" />
    /// </summary>
    /// <param name="query">Строка поиска</param>
    /// <param name="offset">Количество записей, которое будет проигнорировано при получении</param>
    /// <param name="limit">Количество записей которое будет получено</param>
    /// <param name="signedUserGuid">Guid авторизованного пользователя</param>
    /// <returns>
    ///     Массив пользователей, у которых есть игры или vr гарнитуры совпадающие с запросом <paramref name="query" />.
    ///     Если <paramref name="signedUserGuid" /> не null, то пользователь с таким Guid и его друзья, входящие заявки и
    ///     исходящие заявки не попадают в поиск
    /// </returns>
    Task<UserSummary[]> FindUsersByGameOrVrSet(string query, int offset, int limit, Guid? signedUserGuid = null);

    /// <summary>
    ///     Список пользователей, у которых есть игра либо vr гарнитура содержащая соответственно <paramref name="game" /> и
    ///     <paramref name="vrset" /> в названии
    /// </summary>
    /// <param name="game">Название игры. Если null, игнорируется</param>
    /// <param name="vrset">Название VR гарнитуры. Если null, игнорируется</param>
    /// <param name="offset">Количество записей, которое будет проигнорировано при получении</param>
    /// <param name="limit">Количество записей которое будет получено</param>
    /// <param name="signedUserGuid">Guid авторизованного пользователя</param>
    /// <returns>
    ///     <para>Массив запрашиваемых пользователей</para>
    ///     Если <paramref name="signedUserGuid" /> не null, то пользователь с таким Guid и его друзья, входящие заявки и
    ///     исходящие заявки не попадают в поиск
    /// </returns>
    Task<UserSummary[]> FindUsersByGameAndVrset(string? game, string? vrset, int offset, int limit,
        Guid? signedUserGuid = null);

    /// <summary>
    ///     Получает список случайных пользователей
    /// </summary>
    /// <param name="numberOfUsers">Количество пользователей для получения</param>
    /// <param name="signedUserGuid">Guid авторизованного пользователя</param>
    /// <returns>Массив с случайными пользователями длиной <paramref name="numberOfUsers" /></returns>
    Task<UserSummary[]> GetRandomUsers(int numberOfUsers, Guid? signedUserGuid = null);

    /// <summary>
    /// Получает полную информацию о пользователе
    /// </summary>
    /// <param name="username">Уникальное имя пользователя</param>
    /// <param name="signedUserGuid">Guid авторизованного пользователя</param>
    /// <returns>Полная информация о пользователе</returns>
    Task<UserDetails?> GetUserDetailsByUsername(string username, Guid? signedUserGuid = null);
}