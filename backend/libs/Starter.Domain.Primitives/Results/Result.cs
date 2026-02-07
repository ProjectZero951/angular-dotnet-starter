namespace Starter.Domain.Primitives.Results;

public record Error(string Message, string? Code = null);

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error? Error { get; }

    protected Result(bool success, Error? error)
    {
        IsSuccess = success;
        Error = error;
    }

    public static Result Ok() => new(true, null);
    public static Result Fail(Error error) => new(false, error);
}

public class Result<T> : Result
{
    public T? Value { get; }

    private Result(bool success, T value, Error? domainError)
        : base(success, domainError)
    {
        Value = value;
    }

    public static Result<T> Ok(T value) => new(true, value, null);

    public new static Result<T> Fail(Error error) => new(false, default!, error);
}
