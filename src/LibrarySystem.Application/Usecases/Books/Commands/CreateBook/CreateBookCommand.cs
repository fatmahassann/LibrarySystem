using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.UseCases.Books.Commands.CreateBook
{
    public sealed record CreateBookCommand(
        string Title,
        string Author,
        string ISBN,
        string Genre,
        decimal Price,
        int PublishedYear
    ) : IRequest<Guid>;
}
