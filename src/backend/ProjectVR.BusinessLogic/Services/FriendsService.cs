using ProjectVR.Domain.Interfaces.Repositories;
using ProjectVR.Domain.Interfaces.Services;

namespace ProjectVR.BusinessLogic.Services
{
    public class FriendsService : IFriendsService
    {
        private readonly IUsersRepository _usersRepository;
        public FriendsService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        public async Task<bool> AddFriend(Guid fromUserGuid, Guid toUserGuid)
        {
            bool requestExists = await _usersRepository.RequestExists(toUserGuid, fromUserGuid);
            if (requestExists)
            {
                bool isAccepted = await _usersRepository.AcceptFriendRequest(toUserGuid, fromUserGuid);
                return isAccepted;
            }
            await _usersRepository.CreateFriendRequest(fromUserGuid, toUserGuid);
            return true;
        }
    }
}
