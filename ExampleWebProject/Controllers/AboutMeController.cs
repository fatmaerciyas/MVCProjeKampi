using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleWebProject.Controllers
{
    public class AboutMeController : Controller
    {
        AboutMeManager aboutMe = new AboutMeManager(new EfAboutMeDal());
        // GET: AboutMe
        public ActionResult Index()
        {
            var aboutmevalues = aboutMe.GetList();
            return View(aboutmevalues);
            
        }
    }
}