namespace FilmStore.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrder2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            AddColumn("dbo.Films", "Order_OrderId", c => c.Int());
            CreateIndex("dbo.Films", "Order_OrderId");
            AddForeignKey("dbo.Films", "Order_OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Films", new[] { "Order_OrderId" });
            DropColumn("dbo.Films", "Order_OrderId");
            DropTable("dbo.Orders");
        }
    }
}
