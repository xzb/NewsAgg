using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication8.Models
{
    public class source
    {
        [Key]
        public string scrName { get; set; }
        public DateTime newestTime { get; set; }

        //public ICollection<item> items { get; set; }
    }
}