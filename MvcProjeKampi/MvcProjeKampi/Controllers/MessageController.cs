using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class MessageController : Controller
    {
        private MessageManager _messageManager = new MessageManager(new EfMessageDal());
        private MessageValidator _validationRules = new MessageValidator();

        [Authorize]
        public ActionResult InBox()
        {
            var messageList = _messageManager.GetAllInBox();
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            var messageList = _messageManager.GetAllSendBox();
            return View(messageList);
        }
        public ActionResult GetMessageDetails(int id)
        {
            var result = _messageManager.GetById(id);
            return View(result);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var result = _messageManager.GetById(id);
            return View(result);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost,ValidateInput(false)]
        public ActionResult NewMessage(Message message, string button)
        {
            ValidationResult validationResult = _validationRules.Validate(message);
            if (button == "add")
            {
                if (validationResult.IsValid)
                {
                    message.SenderMail = "admin@gmail.com";
                    message.IsDraft = false;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    _messageManager.Add(message);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "draft")
            {
                if (true)
                {

                    message.SenderMail = "admin@gmail.com";
                    message.IsDraft = true;
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    _messageManager.Add(message);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var item in validationResult.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else if (button == "cancel")
            {
                return RedirectToAction("NewMessage");
            }

            return View();
        }
        public ActionResult DeleteMessage(int id)
        {
            var result = _messageManager.GetById(id);
            if (result.Trash == true)
            {
                result.Trash = false;
            }
            else
            {
                result.Trash = true;
            }
            _messageManager.Delete(result);
            return RedirectToAction("Inbox");

        }

        public ActionResult Draft()
        {
            var result = _messageManager.IsDraft();
            return View(result);
        }

        public ActionResult GetDraftDetails(int id)
        {
            var result = _messageManager.GetById(id);
            return View(result);
        }

        public ActionResult IsRead(int id)
        {
            var result = _messageManager.GetById(id);
            if (result.IsRead == false)
            {
                result.IsRead = true;
            }
            else
            {
                result.IsRead = false;
            }
            _messageManager.Update(result);
            return RedirectToAction("Inbox");
        }

        public ActionResult MessageRead()
        {
            var result = _messageManager.GetAllSendBox().Where(m => m.IsRead == true).ToList();
            return View(result);
        }

        public ActionResult MessageUnRead()
        {
            var result = _messageManager.GetAllRead();
            return View(result);
        }
    }
}