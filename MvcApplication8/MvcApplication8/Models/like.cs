﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcApplication8.Models
{
    public class like
    {
        //public int Id { get; set; }
        [Key]
        [Column(Order = 0)]
        public int UserId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int ItemId { get; set; }

        //public virtual UserProfile UserProfile { get; set; }      //cannot link to the UserProfile?

        public like()
        {
        }
        public like(int uid, int iid) {
            UserId = uid;      //foreign key can't use
            ItemId = iid;
        }
    }

}