using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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

        public Entry NewEntry { get; set; } = new Entry();
        private Timer DurationTimer;
        private bool DurationTimerRunning;

        public NewSubject newSubject { get; set; }

        private ICommand _addSubjectCmd = null;
        public ICommand AddSubjectCmd => _addSubjectCmd ?? (_addSubjectCmd = new AddSubjectCommand(this));

        private ICommand _submitNewEntryCmd = null;
        public ICommand SubmitNewEntryCmd => _submitNewEntryCmd ?? (_submitNewEntryCmd = new SubmitNewEntryCommand(this));

        private ICommand _clearNewEntryFromCmd = null;
        public ICommand ClearNewEntryFormCmd => _clearNewEntryFromCmd ?? (_clearNewEntryFromCmd = new ClearNewEntryFormCommand(this));

        private ICommand _toggleTimerCmd = null;
        public ICommand ToggleTimerCmd => _toggleTimerCmd ?? (_toggleTimerCmd = new ToggleTimerCommand(this));

        private ICommand _resetTimerCmd = null;
        public ICommand ResetTimerCmd => _resetTimerCmd ?? (_resetTimerCmd = new ResetTimerCommand(this));

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

            newSubject = new NewSubject(uniqueSubjects);

            DurationTimer = new Timer(state => DurationTimer_Tick(), null, Timeout.Infinite, 1000);
            DurationTimerRunning = false;
        }

        private void DurationTimer_Tick()
        {
            NewEntry.Duration += TimeSpan.FromSeconds(1);
        }

        //  timer methods
        public void ToggleTimer()
        {
            if (DurationTimerRunning)
            {
                DurationTimer.Change(Timeout.Infinite, Timeout.Infinite);
                DurationTimerRunning = false;
            }                
            else
            {
                DurationTimer.Change(1000, 1000);
                DurationTimerRunning = true;
            }                
        }

        public void ResetTimer()
        {
            DurationTimer.Change(Timeout.Infinite, Timeout.Infinite);
            DurationTimerRunning = false;

            NewEntry.Duration = TimeSpan.Zero;
        }

        public void SaveEntry()
        {
            try
            {
                using (var repo = new EntryRepo())
                {
                    repo.Add(this.NewEntry);
                }
            }
            catch (Exception)
            {
                //  TO DO: determine how to handle this
                return;
            }
        }
    }
}
