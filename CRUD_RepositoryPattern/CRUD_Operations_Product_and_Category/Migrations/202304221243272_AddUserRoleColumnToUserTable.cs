namespace CRUD_Operations_Product_and_Category.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserRoleColumnToUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserRole");
        }
    }
}
