using LibrarySystem.Application.Common.Interfaces;
using LibrarySystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.UseCases.Books.Queries.GetBookById
{
    public sealed class GetBookByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetBookByIdQuery, Book?>
    {
        public async Task<Book?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            //return await context.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            // to hide the deleted row

            return await context.Books.FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);
        }
    }
}
