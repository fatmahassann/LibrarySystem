using LibrarySystem.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.UseCases.Books.Commands.DeleteBook
{
    public sealed class DeleteBookCommandHndler(IApplicationDbContecxt context) : IRequestHandler<DeleteBookCommand>
    {
        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (book is null)
            {
                throw new KeyNotFoundException($"Book With ID '{request.Id}' not found");

            }

            book.Delete();

            await context.SaveChangesAsync(cancellationToken);

        }
    }
}
