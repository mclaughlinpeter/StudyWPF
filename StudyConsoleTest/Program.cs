using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyDAL.Repos;
using StudyDAL.Models;
using StudyDAL.EF;
using System.Data.Entity;

namespace StudyConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DataInitializer());
            PrintAllEntries();
            var ent1 = new Entry() { DateTimeStamp = DateTime.Now.AddHours(3), Duration = new TimeSpan(1, 0, 0), Subject = "C++" };
            DeleteRecord(6);
            PrintAllEntries();
            PrintSubjects();
        }

        static void PrintAllEntries()
        {
            using (var repo = new EntryRepo())
            {
                foreach (Entry e in repo.GetAll())
                {
                    Console.WriteLine($"ID: {e.EntryID}\tSubject: {e.Subject}\tDuration: {e.Duration.ToString()}\tDTS: {e.DateTimeStamp.ToString()}");
                }
                Console.WriteLine();
            }
        }

        static void PrintSubjects()
        {
            using (var repo = new EntryRepo())
            {
                IList<Entry> entries = repo.GetAll();
                IList<string> subjects = (from e in entries where e.Subject.Contains("C") select e.Subject).ToList();
                foreach (string s in subjects)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }
        }

        static void AddNewRecord(Entry entry)
        {
            using (var repo = new EntryRepo())
            {
                repo.Add(entry);
            }
        }

        static void UpdateRecord(int entryId)
        {
            using (var repo = new EntryRepo())
            {
                var entryToUpdate = repo.GetOne(entryId);
                if (entryToUpdate != null)
                {
                    entryToUpdate.Subject = "New";
                    repo.Save(entryToUpdate);
                }
            }
        }

        static void DeleteRecord(int entryId)
        {
            using (var repo = new EntryRepo())
            {
                var entryToDelete = repo.GetOne(entryId);
                if (entryToDelete != null)
                {
                    repo.Delete(entryToDelete);
                }
            }
        }
    }
}
