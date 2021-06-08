using FindADev.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public Role Role { get; set; }

        public ProfileModel Profile { get; set; }
    }
}
