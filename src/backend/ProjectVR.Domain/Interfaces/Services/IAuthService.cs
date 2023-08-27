using System.Threading.Tasks;
using ProjectVR.Domain.Models;

namespace ProjectVR.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<UserSummary?> Login(string username);
    }
}
