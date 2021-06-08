using FindADev.ASP.Helper;
using FindADev.ASP.Models;
using FindADev.ASP.Models.Form;
using FindADev.ASP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace FindADev.ASP.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly string _UserSessionVariable = "user";
        private readonly IService<UserForm, UserModel> _Service;
        public AuthenticationController(IService<UserForm,UserModel> Service)
        {
            _Service = Service;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm] AuthenticationForm form)
        {
            if(ModelState.IsValid)
            {
                UserModel model = _Service.Find(new UserForm { Email = form.Email, Password = form.Password });

                if (model != null)
                {
                    HttpContext.Session.SetObject(_UserSessionVariable, model);
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["error"] = "No user find";
            return View(form);
        }
    }
}
