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

        public DateTime NewDateTimeStamp { get; set; }

        private string _newSubject;
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

        public TimeSpan NewDuration { get; set; }
        
        //  INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        internal void OnPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //  IDataErrorInfo
        public string Error { get; }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(NewDateTimeStamp):
                        break;
                    case nameof(NewSubject):
                        if (NewSubject == "badSubject")
                        {
                            return "Bad Subject";
                        }
                        break;
                    case nameof(NewDuration):
                        break;
                }
                return string.Empty;
            }
        }
    }
}
