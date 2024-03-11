using MediatR;
using PractiseMediatr.Domain.Entities;
using PractiseMediatr.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseMediatr.Application.UseCase.MediumUser.Commands
{
    public class UpdateUserCommand:UserDTO,IRequest<User>
    {
        public Guid Id { get; set; }
    }
}
