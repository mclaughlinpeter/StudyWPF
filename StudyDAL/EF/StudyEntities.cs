namespace StudyDAL.EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using StudyDAL.Models;

    public class StudyEntities : DbContext
    {
        public StudyEntities() : base("name=StudyConnection")
        {
        }

        public virtual DbSet<Entry> Entries { get; set; }
    }
}