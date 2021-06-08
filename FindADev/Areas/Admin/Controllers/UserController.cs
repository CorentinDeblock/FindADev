using FindADev.ASP.Models;
using FindADev.ASP.Models.Form;
using FindADev.ASP.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Controllers.Admin
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private IService<UserForm, UserModel> _service;
        public UserController(IService<UserForm,UserModel> service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.Read());
        }

        public IActionResult Details(int id)
        {
            return View(_service.ReadFromId(id));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] UserForm form)
        {
            if(ModelState.IsValid)
            {
                _service.Insert(form);
                return RedirectToAction("Index");
            }

            return View(form);
        }
    }
}
