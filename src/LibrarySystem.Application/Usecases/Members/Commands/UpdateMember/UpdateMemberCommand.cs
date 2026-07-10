using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Usecases.Members.Commands.UpdateMember
{
    public sealed record UpdateMemberCommand(
        Guid id , string fullName , string email , string? phone , string? address ) : IRequest;
    
}
