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
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDal());
        // GET: About
        public ActionResult Index()
        {
            var aboutvalues = abm.GetList();
            return View(aboutvalues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            abm.AboutAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView(); // ayni anda 2 islemi birden yapmak istemedigimiz icin yaptik
        }

        public ActionResult EditAbout(int id)
        {
            var aboutvalue = abm.GetByID(id);
            if (aboutvalue.AboutStatus == false)
            {
                aboutvalue.AboutStatus = true;
            }

            abm.AboutDelete(aboutvalue);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id) //aslinda guncelleme yapacak true-false
        {
            var aboutvalue = abm.GetByID(id);
            if (aboutvalue.AboutStatus == true)
            {
                aboutvalue.AboutStatus = false;
            }
            
            abm.AboutDelete(aboutvalue);
            return RedirectToAction("Index");
        }
    }
}