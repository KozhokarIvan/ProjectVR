using System;
using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Repositories;

public interface IRequestsRepository
{
    /// <summary>
    ///     Создает заявку в друзья в базе данных
    /// </summary>
    /// <param name="userGuid">Guid отправителя заявки в друзья</param>
    /// <param name="friendUserGuid">Guid получателя заявки в друзья</param>
    Task CreateRequest(Guid userGuid, Guid friendUserGuid);

    /// <summary>
    ///     Возвращает заявку в друзья, при этом <paramref name="userGuid" /> это обязательно Guid отправителя, а
    ///     <paramref name="friendUserGuid" /> - получателя
    /// </summary>
    /// <param name="userGuid">Guid отправителя</param>
    /// <param name="friendUserGuid">Guid получателя</param>
    /// <returns>Заявка в друзья. null если такой заявки не найдено</returns>
    Task<Friend?> GetExactRequestByUsersGuids(Guid userGuid, Guid friendUserGuid);

    /// <summary>
    ///     Возвращает заявку в друзья. Неважно кто отправитель, а кто получатель
    /// </summary>
    /// <param name="firstUserGuid">Guid первого пользователя</param>
    /// <param name="secondUserGuid">Guid второго пользователя</param>
    /// <returns>Заявка в друзья. null если такой заявки не найдено</returns>
    Task<Friend?> GetRequestByUserGuids(Guid firstUserGuid, Guid secondUserGuid);

    /// <summary>
    ///     Очищает дату принятия записи с id <paramref name="friendEntryId" />
    /// </summary>
    /// <param name="friendEntryId">id заявки</param>
    /// <returns>Выполнилась ли операция успешно</returns>
    Task<bool> ClearAcceptedAtDate(int friendEntryId);

    /// <summary>
    ///     Добавляет к записи с id
    /// </summary>
    /// <param name="friendEntryId">id заявки</param>
    /// <param name="date">Дата принятия заявки</param>
    /// <returns>Выполнилась ли операция успешно</returns>
    Task<bool> AddAcceptedAtDate(int friendEntryId, DateTimeOffset date);

    /// <summary>
    ///     Удаляет заявку с id <paramref name="friendEntryId" />
    /// </summary>
    /// <param name="friendEntryId">id заявки</param>
    /// <returns>Выполнилась ли операция успешно</returns>
    Task<bool> DeleteRequest(int friendEntryId);
}