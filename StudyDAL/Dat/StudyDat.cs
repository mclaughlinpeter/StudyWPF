using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using StudyDAL.Models;

namespace StudyDAL.Dat
{
    public class StudyDat
    {
        private static string path = @"C:\Users\Peter\OneDrive - Slurp\ABI\Projects\StudyWPF\StudyDAL\study_test.dat";

        public static void WriteText(string value)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                for (int i = 0; i < 10; i++)
                {
                    sw.WriteLine(value + " " + (i + 1));
                }
            }
        }

        public static IList<string> ReadText()
        {
            List<string> lines = null;

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string line;
                    lines = new List<string>();
                    
                    while (sr.EndOfStream == false)
                    {
                        if ((line = sr.ReadLine()) != null)
                        {
                            lines.Add(line);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return lines;
        }

        public static IList<Entry> ReadEntries()
        {
            List<Entry> entries = null;

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string line;
                    entries = new List<Entry>();

                    while (sr.EndOfStream != true)
                    {
                        Entry entry = new Entry();

                        //  read subject
                        entry.Subject = sr.ReadLine();

                        //  read duration
                        int minutes = Int32.Parse(sr.ReadLine());
                        entry.Duration = new TimeSpan(0, minutes, 0);

                        // read timestamp
                        int seconds_1970 = Int32.Parse(sr.ReadLine());
                        entry.DateTimeStamp = Time_TtoDateTime(seconds_1970).ToLocalTime();

                        // add entry to list
                        entries.Add(entry);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return entries;
        }

        private static DateTime Time_TtoDateTime(int time) => new DateTime(1970, 1, 1) + new TimeSpan(0, 0, time);
    }
}
