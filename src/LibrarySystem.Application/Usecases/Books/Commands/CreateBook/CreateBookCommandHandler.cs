using LibrarySystem.Application.Common.Interfaces;
using LibrarySystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.UseCases.Books.Commands.CreateBook
{
    public sealed class CreateBookCommandHandler(IApplicationDbContecxt context) : IRequestHandler<CreateBookCommand, Guid>
    {
        public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            (
                                request.Title,
                                request.Author,
                                request.ISBN,
                                request.Genre,
                                request.Price,
                                request.PublishedYear
            );

            context.Books.Add( book );
            await context.SaveChangesAsync(cancellationToken);
            return book.Id;



        }
    }
}
