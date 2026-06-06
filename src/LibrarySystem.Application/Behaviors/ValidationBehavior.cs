using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Behaviors
{
    public class ValidationBehavior<TRequest, Tresponse>(IEnumerable<IValidator<TRequest>> validators)
        : IPipelineBehavior<TRequest, Tresponse>
        where TRequest : notnull
    {
        public async Task<Tresponse> Handle(TRequest request, RequestHandlerDelegate<Tresponse> next, CancellationToken cancellationToken)
        {
            if (!validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var results = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = results.SelectMany(r => r.Errors).Where(e => e is not null);

            if (failures.Count() != 0)
            {
                throw new ValidationException(failures);
            }
            return await next(cancellationToken);
        }
    }
}
