namespace FilmStore.core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manyToMany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Films", new[] { "Order_OrderId" });
            CreateTable(
                "dbo.OrderFilms",
                c => new
                    {
                        Order_OrderId = c.Int(nullable: false),
                        Film_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Order_OrderId, t.Film_Id })
                .ForeignKey("dbo.Orders", t => t.Order_OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Film_Id);
            
            DropColumn("dbo.Films", "Order_OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Films", "Order_OrderId", c => c.Int());
            DropForeignKey("dbo.OrderFilms", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.OrderFilms", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderFilms", new[] { "Film_Id" });
            DropIndex("dbo.OrderFilms", new[] { "Order_OrderId" });
            DropTable("dbo.OrderFilms");
            CreateIndex("dbo.Films", "Order_OrderId");
            AddForeignKey("dbo.Films", "Order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
