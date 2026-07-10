using LibrarySystem.Application.Common.Interfaces;
using LibrarySystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Application.Usecases.Members.Queries.GetAllMembers
{
    public sealed class GetAllMembersQueryHandler(IApplicationDbContext context) : IRequestHandler<GetAllMembersQuery, List<Member>>
    {
        public async Task<List<Member>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            //return await context.Members.ToListAsync(cancellationToken);
            // to hide the deleted row
            return await context.Members.Where(x => !x.IsDeleted).ToListAsync();
        }
    }

}
