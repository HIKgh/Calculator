using FluentValidation;
using MediatR;

namespace Calculator.Application.Common.Behaviors;

public class ValidationsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationsBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var context = new ValidationContext<TRequest>(request);
        foreach (var validator in _validators)
        {
            await validator.ValidateAsync(context, cancellationToken);
        }

        return await next();
    }
}