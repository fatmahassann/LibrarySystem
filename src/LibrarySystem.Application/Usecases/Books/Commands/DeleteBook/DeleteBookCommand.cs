using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.UseCases.Books.Commands.DeleteBook
{
    public sealed record DeleteBookCommand( Guid Id) : IRequest;

}
