using Microsoft.EntityFrameworkCore;
using PractiseMediatr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseMediatr.Application.Abstraction
{
    public interface IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken=default);
    }
}
