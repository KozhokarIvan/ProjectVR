using System.Threading.Tasks;
using ProjectVR.Domain.Models.VrSet;

namespace ProjectVR.Domain.Interfaces.Repositories;

public interface IVrSetsRepository
{
    Task<VrSet[]> GetVrSets(int limit, int offset);
}