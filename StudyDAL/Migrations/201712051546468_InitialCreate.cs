namespace StudyDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Entry",
                c => new
                    {
                        EntryID = c.Int(nullable: false, identity: true),
                        DateTimeStamp = c.DateTime(nullable: false),
                        Subject = c.String(maxLength: 50),
                        Duration = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.EntryID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Entry");
        }
    }
}
