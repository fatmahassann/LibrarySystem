using LibrarySystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.UseCases.Books.Queries.GetBookById
{
    //it will return the domain entity and this is not professional , we should return DTOs
    public sealed class GetBookByIdQuery : IRequest<Book?>
    {
        public Guid Id { get; set; }
        //new
        public GetBookByIdQuery(Guid id)
        {
            Id = id;
        }

    }


}
