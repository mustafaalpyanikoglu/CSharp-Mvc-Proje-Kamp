using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        private ContentManager _contentManager = new ContentManager(new EfContentDal());
        public ActionResult MyContent()
        {
            var contentValues = _contentManager.GetAllByWriterId();
            return View(contentValues);
        }
    }
}