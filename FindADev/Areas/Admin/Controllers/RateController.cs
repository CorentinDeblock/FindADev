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
    public class RateController : Controller
    {
        private readonly IService<RateForm, RateModel> _rateService;
        public RateController(IService<RateForm,RateModel> rateService)
        {
            _rateService = rateService;
        }

        public IActionResult Index()
        {
            return View(_rateService.Read());
        }

        public IActionResult Create(int id)
        {
            RateForm rateForm = new RateForm { ProfileId = id };
            return View(rateForm);
        }

        [HttpPost]
        public IActionResult Create([FromForm] RateForm rateForm)
        {
            if(ModelState.IsValid)
            {
                _rateService.Insert(rateForm);
                return RedirectToAction("Index");
            }
            return View(rateForm);
        }

        public IActionResult Details(int id)
        {
            return View(_rateService.ReadFromId(id));
        }
    }
}
