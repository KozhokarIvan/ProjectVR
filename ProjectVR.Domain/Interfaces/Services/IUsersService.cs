using System.Collections.Generic;
using ProjectVR.Domain.Entities;

namespace ProjectVR.Domain.Interfaces.Services
{
    public interface IUsersService
    {
        public List<Userinfo> FindUsers(string? game, string? vrset);
    }
}
