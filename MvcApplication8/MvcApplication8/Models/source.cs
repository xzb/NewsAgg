using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication8.Models
{
    public class source
    {
        public int Id { get; set; }

        public string srcName { get; set; }
        public DateTime? newDate { get; set; }

        public source()
        {
        }
        public source(string s, DateTime d) {
            srcName = s;
            newDate = d;
        }

    }
}