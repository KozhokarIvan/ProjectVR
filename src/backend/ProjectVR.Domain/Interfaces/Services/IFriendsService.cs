using System;
using System.Threading.Tasks;

namespace ProjectVR.Domain.Interfaces.Services
{
    public interface IFriendsService
    {
        /// <summary>
        /// Отправляет заявку от пользователя с Guid <paramref name="userGuid"/> пользователю с Guid <paramref name="friendUserGuid"/>
        /// </summary>
        /// <param name="userGuid">Guid отправителя</param>
        /// <param name="friendUserGuid">Guid получателя</param>
        /// <returns>Была ли заявка успешно отправлена</returns>
        Task<bool> SendFriendRequest(Guid userGuid, Guid friendUserGuid);

        /// <summary>
        /// Принимает заявку от пользователя с Guid <paramref name="friendUserGuid"/> пользователю <paramref name="userGuid"/>
        /// </summary>
        /// <param name="userGuid">Guid получателя</param>
        /// <param name="friendUserGuid">Guid отправителя</param>
        /// <returns>Была ли заявка успешно принята</returns>
        Task<bool> AcceptFriendRequest(Guid userGuid, Guid friendUserGuid);

        /// <summary>
        /// Отменяет или отклоняет заявку между пользователями <paramref name="firstUserGuid"/> и <paramref name="secondUserGuid"/>
        /// </summary>
        /// <param name="firstUserGuid">Guid первого пользователя</param>
        /// <param name="secondUserGuid">Guid второго пользователя</param>
        /// <returns>Была ли заявка успешно отклонена</returns>
        Task<bool> DeclineFriendRequest(Guid firstUserGuid, Guid secondUserGuid);

        /// <summary>
        /// Удаляет из списка друзей пользователя с Guid <paramref name="userGuid"/> пользователя с Guid <paramref name="deletedFriendUserGuid"/>
        /// </summary>
        /// <param name="userGuid">Guid владельца списка друзей</param>
        /// <param name="deletedFriendUserGuid">Guid удаляемого пользователя</param>
        /// <returns>Был ли пользователь удален из списка друзей успешно</returns>
        Task<bool> DeleteFriend(Guid userGuid, Guid deletedFriendUserGuid);
    }
}
