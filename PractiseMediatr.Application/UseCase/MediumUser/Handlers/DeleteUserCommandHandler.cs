using MediatR;
using PractiseMediatr.Application.Abstraction;
using PractiseMediatr.Application.UseCase.MediumUser.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseMediatr.Application.UseCase.MediumUser.Handlers
{
    public class DeleteUserCommandHandler : AsyncRequestHandler<DeleteUserCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        protected override async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == request.Id && !x.IsDeleted);
            if (user != null)
            {
                user.IsDeleted= true;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception("Bunday user topilmadi");
            }
        }
    }
}
