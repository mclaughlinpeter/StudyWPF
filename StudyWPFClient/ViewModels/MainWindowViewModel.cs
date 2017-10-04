using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyDAL.Models;
using StudyDAL.Repos;
using StudyWPFClient.Cmds;
using System.Windows;
using System.Windows.Input;

namespace StudyWPFClient.ViewModels
{
    public class MainWindowViewModel
    {
        readonly IList<Entry> _entries;

        public ObservableCollection<string> uniqueSubjects { get; set; }

        public NewEntry newEntry { get; set; }

        private ICommand _addSubjectCmd = null;
        public ICommand AddSubjectCmd => _addSubjectCmd ?? (_addSubjectCmd = new AddSubjectCommand(this));

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

            uniqueSubjects = new ObservableCollection<string>(_entries.Select(e => e.Subject).Distinct().OrderBy(s => s));

            newEntry = new NewEntry(uniqueSubjects);
        }
    }
}
