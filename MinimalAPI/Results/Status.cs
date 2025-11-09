namespace MinimalAPI.Results;

public enum Status
{
    Ok, // 200
    Created, // 201
    NoContent, // 204
    NotModified, // 304
    BadRequest, // 400
    Invalid, // 400
    NotFound, // 404
    Error, // 500
    Unavailable, // 503
}
