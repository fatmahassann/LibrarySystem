using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.UseCases.Books.Commands.UpdateBook
{
    internal class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title should not be empty");

            RuleFor(x => x.Author).NotEmpty().WithMessage("Author should not be empty");

            RuleFor(x => x.Genre).NotEmpty().WithMessage("Genre should not be empty");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero");

            RuleFor(x => x.PublishedYear).GreaterThan(1000);

        }
    }
}
