using MediatR;
using PractiseMediatr.Application.Abstraction;
using PractiseMediatr.Application.Mappings;
using PractiseMediatr.Application.UseCase.MediumUser.Commands;
using PractiseMediatr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseMediatr.Application.UseCase.MediumUser.Handlers
{
    public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.Map<User>();
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
