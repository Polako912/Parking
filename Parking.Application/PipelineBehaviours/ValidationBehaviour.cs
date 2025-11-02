using FluentValidation;
using MediatR;

namespace Parking.Application.PipelineBehaviours;

public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators ?? throw new ArgumentNullException(nameof(validators));

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any()) return await next(cancellationToken);
        
        var context = new ValidationContext<TRequest>(request);
        var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                
        var failures = validationResults
            .Where(r => r.Errors.Count != 0)
            .SelectMany(r => r.Errors)
            .Select(r => new { PropertyMessage = r.PropertyName, r.ErrorMessage })
            .ToList();

        if (failures.Count != 0)
        {
            throw new ArgumentException(failures.Select(f => f.ErrorMessage).Aggregate((a, b) => $"{a}, {b}"));
        }

        return await next(cancellationToken);
    }
}