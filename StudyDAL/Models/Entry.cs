using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyDAL.Models
{
    [Table("Entry")]
    public partial class Entry
    {
        [Key]
        public int EntryID { get; set; }

        [StringLength(50)]
        public string Subject { get; set; }

        public int Duration { get; set; }
    }
}
