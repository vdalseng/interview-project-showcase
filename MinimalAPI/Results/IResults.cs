namespace MinimalAPI.Results;

public interface IResult
{
    Status Status { get; }

    IEnumerable<string> Errors { get; }

    Type ValueType { get; }
}
