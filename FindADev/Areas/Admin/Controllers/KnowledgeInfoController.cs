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
    public class KnowledgeInfoController : Controller
    {
        IService<KnowledgeInfoForm, KnowledgeInfoModel> _knowledgeInfoService;

        public KnowledgeInfoController(IService<KnowledgeInfoForm, KnowledgeInfoModel> knowledgeInfoService)
        {
            _knowledgeInfoService = knowledgeInfoService;
        }
        public IActionResult Index()
        {
            return View(_knowledgeInfoService.Read());
        }

        public IActionResult Create(int id)
        {
            KnowledgeInfoForm form = new KnowledgeInfoForm { KnowledgeId = id };
            return View(form);
        }

        [HttpPost]
        public IActionResult Create([FromForm] KnowledgeInfoForm form)
        {
            if (ModelState.IsValid)
            {
                _knowledgeInfoService.Insert(form);
                return RedirectToAction("Index");
            }
            return View(form);
        }
    }
}
