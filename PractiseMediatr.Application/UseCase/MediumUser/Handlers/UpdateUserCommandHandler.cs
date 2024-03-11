using MediatR;
using PractiseMediatr.Application.Abstraction;
using PractiseMediatr.Application.Mappings;
using PractiseMediatr.Application.UseCase.MediumUser.Commands;
using PractiseMediatr.Domain.Entities;
using PractiseMediatr.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseMediatr.Application.UseCase.MediumUser.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IApplicationDbContext _context;

        public UpdateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user= _context.Users.FirstOrDefault(x=>x.Id==request.Id && !x.IsDeleted);
            if (user != null)
            {
                user.Name = request.Name;
                user.SurName = request.SurName;
                user.UserRole = request.UserRole;
                user.Login=request.Login;
                user.Password=request.Password;
                await _context.SaveChangesAsync(cancellationToken);

                return user;
            }
            else
                throw new Exception("Bunday user mavjud emas");
        }
    }
}
