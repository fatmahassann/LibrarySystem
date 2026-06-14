using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.UseCases.Books.Commands.UpdateBook
{
    public sealed record UpdateBookCommand
    (
        Guid Id,
        string Title,
        string Author,
        string Genre,
        decimal Price,
        int PublishedYear

    ) : IRequest;

}
