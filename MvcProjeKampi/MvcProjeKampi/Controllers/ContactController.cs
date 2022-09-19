using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        private ContactManager _contactManager = new ContactManager(new EfContactDal());
        private MessageManager _messageManager = new MessageManager(new EfMessageDal());
        ContactValidator validationRules = new ContactValidator();
        public ActionResult Index()
        {
            var contactValues = _contactManager.GetAll();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = _contactManager.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult MessageListMenu()
        {
            var contact = _contactManager.GetAll().Count();
            ViewBag.contact = contact;

            var sendMail = _messageManager.GetAllSendBox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = _messageManager.GetAllInBox().Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = _messageManager.GetAllSendBox().Where(m => m.IsDraft == true).Count();
            ViewBag.draftMail = draftMail;

            var readMessage = _messageManager.GetAllInBox().Where(m => m.IsRead == true).Count();
            ViewBag.readMessage = readMessage;

            var unreadMessage = _messageManager.GetAllRead().Count();
            ViewBag.unreadMessage = unreadMessage;
            return PartialView();
        }
    }
}