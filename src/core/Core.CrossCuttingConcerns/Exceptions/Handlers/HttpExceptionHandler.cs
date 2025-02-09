using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.CrossCuttingConcerns.Exceptions.Handlers;

public sealed class HttpExceptionHandler : ExceptionHandler
{
    private HttpResponse response;
    public HttpResponse Response { get; set; }

    protected override Task HandleException(NotFoundException notFoundException)
    {
        Response.StatusCode = StatusCodes.Status404NotFound;
        NotFoundProblemDetails problem = new NotFoundProblemDetails(notFoundException.Message);
        string details = JsonSerializer.Serialize(problem);
        return Response.WriteAsync(details);
    }

    protected override Task HandleException(BusinessException businessException)
    {
        Response.StatusCode = StatusCodes.Status400BadRequest;
        string details = new BusinessProblemDetails(businessException.Message).AsJson();
        return Response.WriteAsync(details);
    }

    protected override Task HandleException(Exception exception)
    {
        Response.StatusCode = StatusCodes.Status500InternalServerError;
        string details = new ServerErrorProblemDetails(exception.Message).AsJson();
        return Response.WriteAsync(details);
    }
}
