using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Models.Form
{
    public class ProfileForm
    {
        public int Id { get; set; }
        public IFormFile ImageFile { get; set; }

        public int UserId { get; set; }
    }
}
