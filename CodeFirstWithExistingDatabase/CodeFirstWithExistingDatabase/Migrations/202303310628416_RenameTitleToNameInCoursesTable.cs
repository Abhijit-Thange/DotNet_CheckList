namespace CodeFirstWithExistingDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameTitleToNameInCoursesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Name", c => c.String());
            Sql("UPDATE Courses SET Name=Title");
            DropColumn("dbo.Courses", "Title");

          //  RenameColumn("dbo.Courses", "Title", "Name"); //if we not writing Sql or RenameColumn Method we loss all data of Title Column
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Title", c => c.String());
            Sql("UPDATE Courses SET Title=Name");
            DropColumn("dbo.Courses", "Name");
        }
    }
}
