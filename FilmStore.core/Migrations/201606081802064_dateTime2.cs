namespace FilmStore.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateTime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Released", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Films", "Released", c => c.DateTime(nullable: false));
        }
    }
}
