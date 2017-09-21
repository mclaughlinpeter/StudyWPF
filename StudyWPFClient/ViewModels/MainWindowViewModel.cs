using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyDAL.Models;
using StudyDAL.Repos;
using System.Windows;

namespace StudyWPFClient.ViewModels
{
    public class MainWindowViewModel
    {
        readonly IList<Entry> _entries;

        public ObservableCollection<string> uniqueSubjects { get; set; }

        public string newSubject { get; set; }

        public MainWindowViewModel()
        {
            try
            {
                using (var repo = new EntryRepo())
                {
                    _entries = new List<Entry>(repo.GetAll());
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to connect to data source", "Study Application");
                Environment.Exit(1);
            }

            uniqueSubjects = new ObservableCollection<string>((new HashSet<string>(from e in _entries orderby e.Subject select e.Subject)).ToList());
        }
    }
}
