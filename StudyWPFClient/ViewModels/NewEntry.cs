using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPFClient.ViewModels
{
    public class NewEntry : INotifyPropertyChanged
    {
        private readonly IList<string> uniSub;

        public NewEntry(IList<string> uniqueSubjects)
        {
            uniSub = uniqueSubjects;
        }

        public DateTime DateTimeStamp { get; set; }

        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set
            {
                if (value == _subject)
                    return;
                _subject = value;
                OnPropertyChanged(nameof(Subject));
            }
        }

        public TimeSpan Duration { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
