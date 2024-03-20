using System.Threading.Tasks;
using ProjectVR.Domain.Models.VrSet;

namespace ProjectVR.Domain.Interfaces.Services;

public interface IVrSetsService
{
    Task<VrSet[]> GetVrSets(int limit, int offset);
}