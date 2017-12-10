using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

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

                    while ((line = sr.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return lines;
        }
    }
}
