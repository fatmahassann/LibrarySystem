using LibrarySystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Usecases.Members.Queries.GetMemberById
{
    public sealed record GetMemberByIdQuery : IRequest<Member?>
    {
        public Guid Id { get; set; }
        //new
        public GetMemberByIdQuery(Guid id)
        {
            Id = id;
        }
    }

}
