using MediatR;
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
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IApplicationDbContext _context;

        public GetUserByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _context.Users.FirstOrDefault(x=>x.Id==request.Id && !x.IsDeleted)!;
        }
    }
}
