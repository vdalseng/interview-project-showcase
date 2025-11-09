namespace MinimalAPI.Results;

public class Result<T> : IResult
{
    protected Result() { }

    protected Result(T value) => Value = value;

    protected Result(T value, string message)
        : this(value) => Message = message;

    protected Result(Status status) => Status = status;

    public T? Value { get; init; }

    public Type ValueType => typeof(T);

    public Status Status { get; protected set; } = Status.Ok;

    public bool IsSuccess =>
        Status switch
        {
            Status.Ok or Status.Created or Status.NoContent => true,
            _ => false,
        };

    public bool IsFailure => !IsSuccess;

    public string Message { get; set; } = string.Empty;

    public IEnumerable<string> Errors { get; protected set; } = [];

    public static Result<T> Success(T value) => new(value);

    public static Result<T> Success(T value, string successMessage) => new(value, successMessage);

    public static Result<T> Failure() => new(Status.Error);

    public static Result<T> Failure(string error) => new(Status.Error) { Errors = [error] };

    public static Result<T> Failure(IEnumerable<string> errors) =>
        new(Status.Error) { Errors = errors };

    public static Result<T> BadRequest() => new(Status.BadRequest);

    public static Result<T> BadRequest(string error) => new(Status.BadRequest) { Errors = [error] };

    public static Result<T> BadRequest(IEnumerable<string> errors) =>
        new(Status.BadRequest) { Errors = errors };

    public static Result<T> Invalid() => new(Status.Invalid);

    public static Result<T> Invalid(string error) => new(Status.Invalid) { Errors = [error] };

    public static Result<T> Invalid(IEnumerable<string> errors) =>
        new(Status.Invalid) { Errors = errors };

    public static Result<T> NotFound() => new(Status.NotFound);

    public static Result<T> NotFound(string error) => new(Status.NotFound) { Errors = [error] };

    public static Result<T> NotFound(IEnumerable<string> errors) =>
        new(Status.NotFound) { Errors = errors };

    public static Result<T> Error() => new(Status.Error);

    public static Result<T> Error(string error) => new(Status.Error) { Errors = [error] };

    public static Result<T> Error(IEnumerable<string> errors) =>
        new(Status.Error) { Errors = errors };

    public static Result<T> Unavailable() => new(Status.Unavailable);

    public static Result<T> Unavailable(string error) =>
        new(Status.Unavailable) { Errors = [error] };

    public static Result<T> Unavailable(IEnumerable<string> errors) =>
        new(Status.Unavailable) { Errors = errors };
}

public class Result : Result<Result>
{
    private Result()
        : base() { }

    protected Result(Status status)
        : base(status) { }

    public static Result Success() => new();

    public static Result Success(string message) => new() { Message = message };

    public static new Result BadRequest() => new(Status.BadRequest);

    public static new Result BadRequest(string error) =>
        new(Status.BadRequest) { Errors = [error] };

    public static new Result BadRequest(IEnumerable<string> errors) =>
        new(Status.BadRequest) { Errors = errors };

    public static new Result NotFound() => new(Status.NotFound);

    public static new Result NotFound(string error) => new(Status.NotFound) { Errors = [error] };

    public static new Result NotFound(IEnumerable<string> errors) =>
        new(Status.NotFound) { Errors = errors };

    public static new Result Error() => new(Status.Error);

    public static new Result Error(string error) => new(Status.Error) { Errors = [error] };

    public static new Result Error(IEnumerable<string> errors) =>
        new(Status.Error) { Errors = errors };

    public static new Result Unavailable() => new(Status.Unavailable);

    public static new Result Unavailable(string error) =>
        new(Status.Unavailable) { Errors = [error] };

    public static new Result Unavailable(IEnumerable<string> errors) =>
        new(Status.Unavailable) { Errors = errors };
}
