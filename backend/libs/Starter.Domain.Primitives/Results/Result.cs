namespace Starter.Domain.Primitives.Results;

public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public Exception? DomainError { get; }

    protected Result(bool success, Exception? domainError)
    {
        IsSuccess = success;
        DomainError = domainError;
    }

    public static Result Ok() => new(true, null);
    public static Result Fail(Exception error) => new(false, error);
}

public class Result<T> : Result
{
    public T? Value { get; }

    private Result(bool success, T? value, Exception? domainError)
        : base(success, domainError)
    {
        Value = value;
    }

    public static Result<T> Ok(T value) => new(true, value, null);

    public new static Result<T> Fail(Exception error) => new(false, default, error);
}
