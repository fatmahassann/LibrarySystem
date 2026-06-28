using LibrarySystem.Application.Common.Interfaces;
using LibrarySystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.UseCases.Books.Queries.GetAllBooks
{
    public sealed class GetAllBooksQueryHandler(IApplicationDbContext context) : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        public async Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            //return await context.Books.ToListAsync(cancellationToken);
//
            // to hide the deleted row
            return await context.Books.Where(x => !x.IsDeleted).ToListAsync();
        }
    }
}
