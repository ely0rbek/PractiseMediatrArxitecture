using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiseMediatr.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int UserRole { get; set; } = 1;
        public required string Login { get; set; }
        public required string Password { get; set; }
        public string PicturePath { get; set; }
        public bool IsDeleted { get; set; } = false;


    }
}
