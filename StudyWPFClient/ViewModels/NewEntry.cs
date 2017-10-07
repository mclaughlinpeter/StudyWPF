﻿using System;
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

        public DateTime DateTimeStamp { get; set; }

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
                OnPropertyChanged(nameof(Subject));
            }
        }

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
                        break;
                    case nameof(NewSubject):
                        if (uniSub.Contains(NewSubject.Trim()))
                        {
                            this.Error = "Subject already exists";
                            return "Subject already exists";
                        }
                        else if (String.IsNullOrWhiteSpace(NewSubject))
                        {
                            this.Error = "New subject field is empty";
                            return "New subject field is empty";
                        }
                        break;
                    case nameof(Subject):
                        if (String.IsNullOrEmpty(Subject))
                        {
                            this.Error = "No subject selected";
                            return "No subject selected";
                        }
                        break;
                    case nameof(Duration):
                        break;
                }
                this.Error = string.Empty;
                return string.Empty;
            }
        }
    }
}
