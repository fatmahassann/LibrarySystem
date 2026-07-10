using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Usecases.Members.Commands.DeleteMember
{
    public sealed record DeleteMemberCommand(Guid id) : IRequest;

}
