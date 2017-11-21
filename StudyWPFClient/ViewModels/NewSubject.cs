using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPFClient.ViewModels
{
    public class NewSubject : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly IList<string> uniSub;

        public NewSubject(IList<string> uniqueSubjects)
        {
            uniSub = uniqueSubjects;
        }

        private string _newSubjectName = string.Empty;
        public string NewSubjectName
        {
            get { return _newSubjectName; }
            set
            {
                if (value == _newSubjectName)
                    return;
                _newSubjectName = value;
                OnPropertyChanged(nameof(NewSubjectName));
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
                    case nameof(NewSubjectName):
                        if (uniSub.Contains(NewSubjectName.Trim()))
                        {
                            return this.Error = "Subject already exists";
                        }
                        else if (String.IsNullOrWhiteSpace(NewSubjectName))
                        {
                            return this.Error = "New subject field is empty";
                        }
                        else
                            return this.Error = string.Empty;
                        // break;
                }
                return string.Empty;
            }
        }
    }
}
