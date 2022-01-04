using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingID { get; set; }
        [StringLength(200)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        public bool HeadingStatus { get; set; }

        //CATEGORY
        public int CategoryID { get; set; }  //CATEGORYID SI HEADING TABLOMUZDA YER ALACAK
        public virtual Category Category { get; set; }

        //CONTENT
        public ICollection<Content> Contents { get; set; }  // HEADINGID, CONTENT TABLOSUNDA YER ALACAK

        //YAZAR
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
