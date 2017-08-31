using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDAL.Models
{
    public partial class Entry
    {
        public override string ToString()
        {
            return $"Id: {this.EntryID}\tSubject: {this.Subject}\tDuration: {this.Duration.ToString()}\tDTS: {this.DateTimeStamp.ToString()}";
        }
    }
}
