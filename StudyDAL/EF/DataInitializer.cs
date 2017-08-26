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
                new Entry {Subject = "C#", Duration = 30 },
                new Entry {Subject = "JS", Duration = 60 },
                new Entry {Subject = "C++", Duration = 45 },
                new Entry {Subject = "Linux", Duration = 75 },
                new Entry {Subject = "Azure", Duration = 90 },
                new Entry {Subject = "C#", Duration = 30 },
                new Entry {Subject = "HTML", Duration = 30 },
                new Entry {Subject = "ASP.NET", Duration = 120 }
            };
            entries.ForEach(x => context.Entries.Add(x));
            context.SaveChanges();
        }
    }
}
