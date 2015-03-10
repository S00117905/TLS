using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace camera.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }

        //public string Email { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}