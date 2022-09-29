using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class TalentController : Controller
    {
        private TalentManager _talentManager = new TalentManager(new EfTalentDal());

        // GET: Talent
        public ActionResult Index()
        {
            var result = _talentManager.GetTalents();
            return View(result);
        }

        public ActionResult TalentCard()
        {
            var result = _talentManager.GetTalents();
            return View(result);
        }

        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTalent(Talent talent)
        {
            _talentManager.Insert(talent);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTalent(int id)
        {
            var result = _talentManager.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateTalent(Talent talent)
        {
            _talentManager.Update(talent);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTalent(int id)
        {
            var result = _talentManager.GetById(id);
            _talentManager.Delete(result);
            return RedirectToAction("Index");
        }
    }
}