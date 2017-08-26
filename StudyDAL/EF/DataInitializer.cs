using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StudyDAL.Models;

namespace StudyDAL.EF
{
    public class DataInitializer : DropCreateDatabaseAlways<StudyEntities>
    {
        protected override void Seed(StudyEntities context)
        {
            var entries = new List<Entry>
            {
                new Entry {Subject = "C#", Duration = 30, DateTimeStamp = DateTime.Now.AddHours(1) },
                new Entry {Subject = "JS", Duration = 60, DateTimeStamp = DateTime.Now.AddMinutes(30) },
                new Entry {Subject = "C++", Duration = 45, DateTimeStamp = DateTime.Now.AddDays(2) },
                new Entry {Subject = "Linux", Duration = 75, DateTimeStamp = DateTime.Now.AddMonths(1) }
            };
            entries.ForEach(x => context.Entries.Add(x));
            context.SaveChanges();
        }
    }
}
