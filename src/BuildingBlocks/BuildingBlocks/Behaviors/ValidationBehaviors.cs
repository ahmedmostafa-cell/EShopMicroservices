using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviors
{
    public class ValidationBehaviors<TRequest, TRepsonse>
        (IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TRepsonse>
        where TRequest : ICommand<TRepsonse>
    {
        public async Task<TRepsonse> Handle(TRequest request, 
            RequestHandlerDelegate<TRepsonse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults =
                await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures =
                validationResults.Where(r => r.Errors.Any())
                .SelectMany(r => r.Errors)
                .ToList();
            if (failures.Any())
                throw new ValidationException(failures);

            return await next();
        }
    }
}
