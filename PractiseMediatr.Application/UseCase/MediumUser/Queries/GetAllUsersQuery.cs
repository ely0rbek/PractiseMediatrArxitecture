using MediatR;
using PractiseMediatr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseMediatr.Application.UseCase.MediumUser.Queries
{
    public class GetAllUsersQuery:IRequest<List<User>>
    {

    }
}
