using FluentValidation;
using MediatR;

namespace DevFreela.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> (IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!validators.Any()) return await next(); // 1. sem validator? deixa passar direto

            var context = new ValidationContext<TRequest>(request);

            var results = await Task.WhenAll(validators
                .Select(v => v.ValidateAsync(context, cancellationToken))); // 2. roda todos os validators

            var failures = results.SelectMany(r => r.Errors)  
                .Where(f => f is not null)
                .ToList(); // 3. junta todos os erros numa lista só

            if (failures.Count > 0)
                throw new ValidationException(failures); // 4. tem erro? barra (o handler NÃO roda)

            return await next(); // 5. tudo certo → segue para o handler
        }
    }
}
