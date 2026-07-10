using LibrarySystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Usecases.Members.Queries.GetAllMembers
{
    public sealed record GetAllMembersQuery : IRequest<List<Member>>;
  
    
}
