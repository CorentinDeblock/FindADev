using FindADev.ASP.Models;
using FindADev.ASP.Models.Form;
using FindADev.ASP.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IService<UserForm, UserModel> _service;
        public ProfileController(IService<UserForm,UserModel> service)
        {
            _service = service;
        }

        public IActionResult Index(int id)
        {
            return View(_service.ReadFromId(id));
        }
    }
}
