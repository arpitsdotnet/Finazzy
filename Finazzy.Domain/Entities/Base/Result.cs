namespace Finazzy.Domain.Entities.Base;

public sealed class Result
{
    private Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    public static Result Success() => new Result(true, Error.None);
    public static Result Failure(Error error) => new Result(false, error);

    public static implicit operator Result(Error error) => Failure(error);

}

public sealed class Result<T>
{
    private Result(bool isSuccess, T data)
    {
        IsSuccess = isSuccess;
        Data = data;
    }
    private Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }
    public T Data { get; }

    public static Result<T> Success(T data) => new Result<T>(true, data);
    public static Result<T> Failure(Error error) => new Result<T>(false, error);


    public static implicit operator Result<T>(Error error) => Result<T>.Failure(error);

    public static implicit operator Result<T>(T data) => Result<T>.Success(data);

}
