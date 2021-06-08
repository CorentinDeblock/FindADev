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
    public class ProfileController : Controller
    {
        private readonly IService<ProfileForm, ProfileModel> _profileService;
        public ProfileController(IService<ProfileForm,ProfileModel> profileService)
        {
            _profileService = profileService;
        }
        public IActionResult Index()
        {
            return View(_profileService.Read());
        }

        public IActionResult Details(int id)
        {
            return View(_profileService.ReadFromId(id));
        }

        public IActionResult Create(int id)
        {
            ProfileForm form = new ProfileForm { UserId = id };
            return View(form);
        }
        [HttpPost]
        public IActionResult Create([FromForm] ProfileForm form)
        {
            if (ModelState.IsValid)
            {
                _profileService.Insert(form);
                return RedirectToAction("Index");
            }
            return View(form);
        }
    }
}
