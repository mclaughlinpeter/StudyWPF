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
        }

        static void PrintAllEntries()
        {
            using (var repo = new EntryRepo())
            {
                foreach (Entry e in repo.GetAll())
                {
                    Console.WriteLine($"ID: {e.EntryID}\tSubject: {e.Subject}\tDuration: {e.Duration.ToString()}\tDTS: {e.DateTimeStamp.ToString()}");
                }
            }
        }
    }
}
