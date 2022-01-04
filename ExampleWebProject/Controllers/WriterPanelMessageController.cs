using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class WriterPanelMessageController : Controller
    {
        MessageManager Mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        // GET: WriterPanelMessage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Inbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageListIn = Mm.GetListInbox(mail);
            return View(messageListIn);
        }
        public ActionResult Sendbox()
        {
            string mail = (string)Session["WriterMail"];
            var messageListSend = Mm.GetListSendbox(mail);
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
            string sender = (string)Session["WriterMail"];

            if (results.IsValid)
            {
                p.SenderMail = sender;
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
        public PartialViewResult WriterPanelPartial()
        {
            
            var contentValues2 = Mm.GetListByUnreadMessages2();
            int M_number_of_unread_messages = contentValues2.Count();
            ViewBag.Messages = M_number_of_unread_messages;
            return PartialView();
        }
        
    }
}