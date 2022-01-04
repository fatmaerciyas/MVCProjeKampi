using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleWebProject.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentByHeading(int id) //basliklarin icerigi
        {
            var contentValues = cm.GetListByHeadingID(id);
            return View(contentValues);
        }

        public ActionResult GetAllContent(string p)
        {
            if (p == null)
            {
                var vls = cm.GetList();
                return View(vls.ToList());
            }
            else
            {
                var values = cm.GetList(p);
                return View(values);
            }
        }
    }
}