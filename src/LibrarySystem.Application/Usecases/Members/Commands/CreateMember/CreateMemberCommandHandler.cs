using AutoMapper.Execution;
using LibrarySystem.Application.Common.Interfaces;
using LibrarySystem.Domain.Entities;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Usecases.Members.Commands.CreateMember
{
    // sealed so noone can inhirite from it
    public sealed class CreateMemberCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateMemberCommand, Guid>
    {
        public async Task<Guid> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = new Domain.Entities.Member
            (
                request.fullName,
                request.email,
                request.phone,
                request.address
            );

            context.Members.Add(member);

            await context.SaveChangesAsync(cancellationToken);

            return member.Id;
        }
    }
}
