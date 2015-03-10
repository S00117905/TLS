using camera.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace camera.DAL
{
    public class TLSInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TLSContext>
    {
        protected override void Seed(TLSContext context)
        {
            var Users = new List<User>
            {
            new User{Name="John Lyons"},
            new User{Name="Sarah Tunt"},
            new User{Name="Mary Black"},
            new User{Name="Mark Morris"},
            new User{Name="Yan Loe"},
            new User{Name="Samantha Bloes"},
            new User{Name="Laura Williams"},
            new User{Name="Nina Simone"}
            };

            Users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
            var Locations = new List<Location>
            {
            new Location{LocationID=1050,Title="Lower Main Street",Price=.50,},
            new Location{LocationID=4022,Title="Main Street",Price=2.50,},
            new Location{LocationID=4041,Title="Upper Main Street",Price=1,},
            new Location{LocationID=1045,Title="Square",Price=2,},
            new Location{LocationID=3141,Title="Industrial",Price=.30,},
            new Location{LocationID=2021,Title="Docks",Price=.40,},
            new Location{LocationID=2042,Title="Shopping District",Price=1.20,}
            };
            Locations.ForEach(s => context.Locations.Add(s));
            context.SaveChanges();
            var Tickets = new List<Ticket>
            {
            new Ticket{UserID=1,LocationID=1050,EntryTime=DateTime.Parse(System.DateTime.Now.ToString()),ExitTime=DateTime.Parse(System.DateTime.Now.AddHours(1).ToString())},
            new Ticket{UserID=1,LocationID=4022,EntryTime=DateTime.Parse(System.DateTime.Now.ToString()),ExitTime=DateTime.Parse(System.DateTime.Now.AddHours(1).ToString())},
            new Ticket{UserID=1,LocationID=4041,EntryTime=DateTime.Parse(System.DateTime.Now.ToString()),ExitTime=DateTime.Parse(System.DateTime.Now.AddHours(2).ToString())},
            new Ticket{UserID=2,LocationID=1045,EntryTime=DateTime.Parse(System.DateTime.Now.ToString()),ExitTime=DateTime.Parse(System.DateTime.Now.AddHours(3).ToString())},
            new Ticket{UserID=2,LocationID=3141,EntryTime=DateTime.Parse(System.DateTime.Now.ToString()),ExitTime=DateTime.Parse(System.DateTime.Now.AddHours(3).ToString())},
            new Ticket{UserID=2,LocationID=2021,EntryTime=DateTime.Parse(System.DateTime.Now.ToString()),ExitTime=DateTime.Parse(System.DateTime.Now.AddHours(4).ToString())},
            new Ticket{UserID=3,LocationID=1050,EntryTime=DateTime.Parse(System.DateTime.Now.ToString())},
            new Ticket{UserID=4,LocationID=1050,EntryTime=DateTime.Parse(System.DateTime.Now.ToString())},
            new Ticket{UserID=4,LocationID=4022,EntryTime=DateTime.Parse(System.DateTime.Now.ToString()),ExitTime=DateTime.Parse(System.DateTime.Now.AddHours(1).ToString())},
            new Ticket{UserID=5,LocationID=4041,EntryTime=DateTime.Parse(System.DateTime.Now.ToString()),ExitTime=DateTime.Parse(System.DateTime.Now.AddHours(2).ToString())},
            new Ticket{UserID=6,LocationID=1045,EntryTime=DateTime.Parse(System.DateTime.Now.ToString())},
            new Ticket{UserID=7,LocationID=3141,EntryTime=DateTime.Parse(System.DateTime.Now.ToString()),ExitTime=DateTime.Parse(System.DateTime.Now.AddHours(1).ToString())},
            };
            Tickets.ForEach(s => context.Tickets.Add(s));
            context.SaveChanges();
        }
    }
}