using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseMediatr.Domain.Entities.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int UserRole { get; set; } = 1;
        public required string Login { get; set; }
        public required string Password { get; set; }
    }
}
