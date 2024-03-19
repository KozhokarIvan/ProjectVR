using System;

namespace ProjectVR.WebAPI.Contracts.Requests;

public class SetUserVrSetsRequest
{
    public UpdateUserVrSet[] VrSets { get; init; } = Array.Empty<UpdateUserVrSet>();
}