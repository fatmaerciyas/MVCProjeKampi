using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleWebProject.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adm = new AdminManager(new EfAdminDal()); 
        // GET: Authorization
        public ActionResult Index()
        {
            var adminvalues = adm.GetList();
            return View(adminvalues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adm.AdminAdd(admin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> adminValue = (from x in adm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.AdminRole,
                                                      Value = x.AdminID.ToString()
                                                  }).ToList();
            ViewBag.vlc = adminValue;
           

            var adminValue2 = adm.GetByID(id);
            return View(adminValue2);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            adm.AdminUpdate(admin);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdmin(int id) //aslinda guncelleme yapacak true-false
        {
            var adminvalue = adm.GetByID(id);
            if (adminvalue.AdminStatus == true)
            {
                adminvalue.AdminStatus = false;
            }
           
            adm.AdminDelete(adminvalue);
            return RedirectToAction("Index");
        }
    }
}