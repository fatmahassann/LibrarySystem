using LibrarySystem.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.UseCases.Books.Commands.UpdateBook
{
    public sealed class UpdateBookCommandHndler(IApplicationDbContecxt context) : IRequestHandler<UpdateBookCommand>
    {
        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (book is null)
            {
                throw new KeyNotFoundException($"Book With ID '{request.Id}' not found");
            }
            book.Update(
            request.Title,
            request.Author,
            request.Genre,
            request.Price,
            request.PublishedYear
        );

        }
    }
}
