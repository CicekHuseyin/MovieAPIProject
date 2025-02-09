using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public sealed class ServerErrorProblemDetails : ProblemDetails
{
    public ServerErrorProblemDetails(string detail)
    {
        Title = "Server Exception";
        Detail = detail;
        Status = StatusCodes.Status500InternalServerError;
        Type = "http://example.com/problems/server";
    }
}
