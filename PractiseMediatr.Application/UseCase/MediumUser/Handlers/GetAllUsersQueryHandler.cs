using MediatR;
using Microsoft.EntityFrameworkCore;
using PractiseMediatr.Application.Abstraction;
using PractiseMediatr.Application.UseCase.MediumUser.Queries;
using PractiseMediatr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseMediatr.Application.UseCase.MediumUser.Handlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllUsersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Users.Where(x=>!x.IsDeleted).ToListAsync();
        }
    }
}
