using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPFClient.ViewModels
{
    public class NewEntry : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly IList<string> uniSub;

        public NewEntry(IList<string> uniqueSubjects)
        {
            uniSub = uniqueSubjects;
        }

        public void ClearEntry()
        {
            this.DateTimeStamp = DateTime.Today;
            this.Subject = null;
        }

        private DateTime _dateTimeStamp = DateTime.Today;

        public DateTime DateTimeStamp
        {
            get { return _dateTimeStamp; }
            set
            {
                if (value == _dateTimeStamp)
                    return;
                _dateTimeStamp = value;
                OnPropertyChanged(nameof(DateTimeStamp));
            }
        }

        private string _newSubject = string.Empty;
        public string NewSubject
        {
            get { return _newSubject; }
            set
            {
                if (value == _newSubject)
                    return;
                _newSubject = value;
                OnPropertyChanged(nameof(NewSubject));
            }
        }

        public bool NewSubjectError { get; set; }

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

        private TimeSpan _duration;
        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                if (value == _duration)
                    return;
                _duration = value;
                OnPropertyChanged(nameof(Duration));
            }
        }
        
        //  INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
                
        //  IDataErrorInfo
        public string Error { get; set; }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(DateTimeStamp):
                        if (DateTimeStamp < DateTime.Today)
                        {
                            this.Error = "Date before today";
                            return "Date before today";
                        }
                        else
                            this.Error = string.Empty;
                        break;
                    case nameof(NewSubject):
                        if (uniSub.Contains(NewSubject.Trim()))
                        {
                            this.NewSubjectError = true;
                            return "Subject already exists";
                        }
                        else if (String.IsNullOrWhiteSpace(NewSubject))
                        {
                            this.NewSubjectError = true;
                            return "New subject field is empty";
                        }
                        else
                            this.NewSubjectError = false;
                        break;
                    case nameof(Subject):
                        if (String.IsNullOrEmpty(Subject))
                        {
                            this.Error = "No subject selected";
                            return "No subject selected";
                        }
                        else
                            this.Error = string.Empty;
                        break;
                    case nameof(Duration):
                        break;
                }                
                return string.Empty;
            }
        }
    }
}
