using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class AboutMe
    {
        [Key]
        public int ID { get; set; }
        [StringLength(30)]
        public String Skill { get; set; }
        public int SkillLevel { get; set; }
    }
}
