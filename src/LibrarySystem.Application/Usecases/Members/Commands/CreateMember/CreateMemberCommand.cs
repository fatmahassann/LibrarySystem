using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Usecases.Members.Commands.CreateMember
{
    public sealed record CreateMemberCommand(string fullName , string email , string? phone , string? address) : IRequest<Guid>;
    
}
