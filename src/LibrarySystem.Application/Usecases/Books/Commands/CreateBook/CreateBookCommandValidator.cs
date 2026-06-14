using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.UseCases.Books.Commands.CreateBook
{
    internal class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title should not be empty");

            RuleFor(x => x.Author).NotEmpty().WithMessage("Author should not be empty");

            RuleFor(x => x.ISBN).NotEmpty().Length(10, 13).WithMessage("ISBN must be between 10 and 13 characters");

            RuleFor(x => x.Genre).NotEmpty().WithMessage("Genre should not be empty");

            RuleFor(x => x.Price).GreaterThan(0);

            RuleFor(x => x.PublishedYear).GreaterThan(1000);

        }
    }
}
