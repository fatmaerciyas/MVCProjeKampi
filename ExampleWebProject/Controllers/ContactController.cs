using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleWebProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDal());
        ContactValidator cv = new ContactValidator();
        MessageManager Mm = new MessageManager(new EfMessageDal());
        // GET: Contact
        
        public ActionResult Index()
        {
            var contactvalues = cm.GetList();
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
          
            var contactvalues = cm.GetByID(id);
            if (contactvalues.ContactMessageStatus == true)
            {
                contactvalues.ContactMessageStatus = false;
            }
            cm.ContactUpdate(contactvalues);
            return View(contactvalues);
        }
      
        public PartialViewResult ContactPartial()
        {
            var contentValues = cm.GetListByUnreadMessages();
            var contentValues2 = Mm.GetListByUnreadMessages2();

            int C_number_of_unread_messages = contentValues.Count();
            int M_number_of_unread_messages = contentValues2.Count();
            ViewBag.ContactMessages = C_number_of_unread_messages;
            ViewBag.Messages = M_number_of_unread_messages; 
            return PartialView();
        }
    }
}