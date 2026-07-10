using LibrarySystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//abstraction for AppDbContext
namespace LibrarySystem.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Book> Books { get; }
        DbSet<Member> Members { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);


    }
}
