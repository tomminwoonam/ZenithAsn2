using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZenithWebsite.Models;

namespace ZenithWebsite.Data
{
    public class SeedData
    {
        public static void Initialize(ApplicationDbContext db)
        {

            // Adds activities
            if (!db.Activity.Any())
            {
                db.Activity.Add(new Activity { ActivityDescription = "League of Legends Tournament", CreationDate = new DateTime(2009, 10, 27) });
                db.Activity.Add(new Activity { ActivityDescription = "Dota Tournament", CreationDate = new DateTime(2013, 7, 9) });
                db.Activity.Add(new Activity { ActivityDescription = "CSGo Tournament", CreationDate = new DateTime(2012, 8, 21) });
                db.Activity.Add(new Activity { ActivityDescription = "Battlerite Tournament", CreationDate = new DateTime(2016, 9, 20) });

                db.SaveChanges();
            }

            // Adds Events
            if (!db.Event.Any())
            {
                db.Event.Add(new Event { DateFrom = new DateTime(2017, 3, 24, 6, 0, 0), DateTo = new DateTime(2017, 3, 24, 10, 30, 0), EventMadeBy = "a", IsActive = true, ActivityId = 1, CreationDate = new DateTime(2017, 1, 25) });
                db.Event.Add(new Event { DateFrom = new DateTime(2017, 3, 24, 6, 0, 0), DateTo = new DateTime(2017, 3, 24, 10, 30, 0), EventMadeBy = "a", IsActive = true, ActivityId = 2, CreationDate = new DateTime(2017, 1, 25) });
                db.Event.Add(new Event { DateFrom = new DateTime(2017, 3, 24, 6, 0, 0), DateTo = new DateTime(2017, 3, 24, 10, 30, 0), EventMadeBy = "a", IsActive = true, ActivityId = 3, CreationDate = new DateTime(2017, 1, 25) });
                db.Event.Add(new Event { DateFrom = new DateTime(2017, 3, 28, 17, 30, 0), DateTo = new DateTime(2017, 3, 28, 20, 30, 0), EventMadeBy = "a", IsActive = true, ActivityId = 4, CreationDate = new DateTime(2017, 1, 25) });
                db.Event.Add(new Event { DateFrom = new DateTime(2017, 4, 30, 15, 0, 0), DateTo = new DateTime(2017, 4, 30, 21, 0, 0), EventMadeBy = "a", IsActive = true, ActivityId = 1, CreationDate = new DateTime(2017, 2, 28) });

                db.SaveChanges();
            }

        }
    }
}
