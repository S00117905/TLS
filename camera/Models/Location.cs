using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace camera.Models
{
    //this model is to hold the location id and price of each individual carpark per hour
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocationID { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}