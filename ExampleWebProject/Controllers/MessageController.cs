using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleWebProject.Controllers
{
    public class MessageController : Controller
    {
        MessageManager Mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        // GET: Message
        public ActionResult Inbox(string p)
        {
            var messageListIn = Mm.GetListInbox(p);
            return View(messageListIn);
        }

        public ActionResult Sendbox(string p)
        {
            var messageListSend = Mm.GetListSendbox(p);
            return View(messageListSend);
        }

        public ActionResult GetInBoxMessageDetails(int id) // gelen mesaj detay sayfasi
        {
            var values = Mm.GetByID(id);
            if (values.MessageStatus == true)
            {
                values.MessageStatus = false;
            }
            Mm.MessageUpdate(values);
            return View(values);

        }

        public ActionResult GetSendBoxMessageDetails(int id) // gelen mesaj detay sayfasi
        {
            var values = Mm.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if(results.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                Mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}