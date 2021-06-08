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
    public class KnowledgeController : Controller
    {
        private readonly IService<KnowledgeForm,KnowledgeModel> _knowledgeService;

        public KnowledgeController(IService<KnowledgeForm, KnowledgeModel> knowledgeService)
        {
            _knowledgeService = knowledgeService;
        }

        public IActionResult Index()
        {
            return View(_knowledgeService.Read());
        }
        
        public IActionResult Create(int id)
        {
            KnowledgeForm form = new KnowledgeForm { ProfileId = id };
            return View(form);
        }

        [HttpPost]
        public IActionResult Create([FromForm] KnowledgeForm form)
        {
            if(ModelState.IsValid)
            {
                _knowledgeService.Insert(form);
                return RedirectToAction("Index");
            }
            return View(form);
        }
    }
}
