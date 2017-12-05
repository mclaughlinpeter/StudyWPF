using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace StudyDAL.Models
{
    [Table("Entry")]
    public partial class Entry : INotifyPropertyChanged
    {
        [Key]
        public int EntryID { get; set; }

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

        private string _subject;

        [StringLength(50)]
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
    }
}
