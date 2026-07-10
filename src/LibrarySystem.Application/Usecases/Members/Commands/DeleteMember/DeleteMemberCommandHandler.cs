using LibrarySystem.Application.Common.Exceptions;
using LibrarySystem.Application.Common.Interfaces;
using LibrarySystem.Application.UseCases.Books.Commands.DeleteBook;
using LibrarySystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Usecases.Members.Commands.DeleteMember
{
    public class DeleteMemberCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteMemberCommand>
    {
        public async Task Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var member = await context.Members.FirstOrDefaultAsync(x => x.Id == request.id, cancellationToken);

            if (member == null)
            {
                throw new NotFoundException(nameof(Member), request.id);

            }

            member.Delete();

            await context.SaveChangesAsync(cancellationToken);

        }

    }
}
