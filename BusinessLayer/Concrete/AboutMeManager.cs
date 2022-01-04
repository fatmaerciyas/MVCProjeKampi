using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutMeManager : IAboutMeService
    {
        IAboutMeDal _aboutMeDal;

        public AboutMeManager(IAboutMeDal aboutMeDal)
        {
            _aboutMeDal = aboutMeDal;
        }

        public List<AboutMe> GetList()
        {
            return _aboutMeDal.List();
        }
    }
}
