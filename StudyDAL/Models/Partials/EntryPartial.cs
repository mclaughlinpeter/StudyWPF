using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyDAL.Models
{
    public partial class Entry : IDataErrorInfo
    {
        public override string ToString()
        {
            return $"Id: {this.EntryID}\tSubject: {this.Subject}\tDuration: {this.Duration.ToString()}\tDTS: {this.DateTimeStamp.ToString()}";
        }

        public void ClearEntry()
        {
            this.DateTimeStamp = DateTime.Today;
            this.Subject = null;
        }

        //  IDataErrorInfo
        [NotMapped]
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
