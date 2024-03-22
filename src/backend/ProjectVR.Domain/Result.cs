using System;

namespace ProjectVR.Domain;

public class Result<TValue, TStatus> where TStatus : struct, Enum
{
    private readonly TValue? _value;

    public Result(TStatus errorStatus, string? errorMessage = default)
    {
        _value = default;
        ErrorStatus = errorStatus;
        ErrorMessage = errorMessage;
    }

    public Result(TValue value, string? errorMessage = default)
    {
        _value = value;
        ErrorStatus = null;
        ErrorMessage = errorMessage;
    }

    public TStatus? ErrorStatus { get; }
    public TValue Value => IsSuccess && _value is not null ? _value : throw new InvalidOperationException();
    public bool IsSuccess => ErrorStatus is null && _value is not null;
    public string? ErrorMessage { get; }
}