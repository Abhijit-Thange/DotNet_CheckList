namespace CRUD_Operations_Product_and_Category.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreatedByColumnToProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CreatedBy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "CreatedBy");
        }
    }
}
