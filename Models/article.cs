using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class article
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string guid { get; set; }
        public string pubDate { get; set; }

        public ICollection<user> users { get; set; }

    }


}
