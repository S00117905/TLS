using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace camera.Models
{
    //public enum Grade
    //{
    //    A, B, C, D, F
    //}

    //this data model holds the ticket information including:
    //userid, location
    public class Ticket
    {
        public int TicketID { get; set; }
        public int LocationID { get; set; }
        public int UserID { get; set; }
        //public Grade? Grade { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public double Total { get; set; }

        public virtual Location Location { get; set; }
        public virtual User User { get; set; }
    }
}