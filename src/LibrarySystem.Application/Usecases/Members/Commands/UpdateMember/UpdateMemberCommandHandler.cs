using LibrarySystem.Application.Common.Interfaces;
using LibrarySystem.Application.Usecases.Members.Commands.CreateMember;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Usecases.Members.Commands.UpdateMember
{
    public sealed class UpdateMemberCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateMemberCommand>
    {
        public async Task Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var member =await context.Members.FirstOrDefaultAsync(x => x.Id == request.id, cancellationToken);

            if(member == null)
            {
                throw new KeyNotFoundException($"member with id '{request.id}' not found");
            }
            member.Update
             (
                request.fullName,
                request.email,
                request.phone,
                request.address
             );

            //new
            await context.SaveChangesAsync(cancellationToken);


        }
    }
}
