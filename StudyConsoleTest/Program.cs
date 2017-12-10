using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyDAL.Repos;
using StudyDAL.Models;
using StudyDAL.Dat;
using StudyDAL.EF;
using System.Data.Entity;

namespace StudyConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new DataInitializer());
            //PrintAllEntries();
            //PrintSubjects();

            //IList<string> entries = StudyDat.ReadText();
            //if (entries != null)
            //{
            //    foreach (string line in entries)
            //    {
            //        Console.WriteLine(line);
            //    }
            //}
            //else
            //    Console.WriteLine("No data");

            IList<Entry> entries = StudyDat.ReadEntries();
            if (entries != null)
            {
                foreach (Entry entry in entries)
                {
                    Console.WriteLine(entry.ToString());
                }
            }
            else
                Console.WriteLine("No data");
        }

        static void PrintAllEntries()
        {
            using (var repo = new EntryRepo())
            {
                foreach (Entry e in repo.GetAll())
                {
                    Console.WriteLine(e.ToString());
                }
                Console.WriteLine();
            }
        }

        static void PrintSubjects()
        {
            using (var repo = new EntryRepo())
            {
                IList<Entry> entries = repo.GetAll();
                HashSet<string> subjects = new HashSet<string>(from e in entries select e.Subject);
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
