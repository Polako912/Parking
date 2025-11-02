using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Parking.Application.PipelineBehaviours;

public class LogBehaviour<TRequest, TResponse>(ILogger<LogBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LogBehaviour<TRequest, TResponse>> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Request Handling: { name } {@request }", typeof(TRequest).Name, JsonSerializer.Serialize(request));
        var response = await next(cancellationToken);
        _logger.LogInformation("Response Handling: { name } {@response }", typeof(TResponse).Name, JsonSerializer.Serialize(response));

        return response;
    }
}