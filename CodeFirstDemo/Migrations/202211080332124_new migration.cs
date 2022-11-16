namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Ruc = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Mail = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.SellerID);
            
            AddColumn("dbo.Products", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "SellerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "SellerID");
            AddForeignKey("dbo.Products", "SellerID", "dbo.Sellers", "SellerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SellerID", "dbo.Sellers");
            DropIndex("dbo.Products", new[] { "SellerID" });
            DropColumn("dbo.Products", "SellerID");
            DropColumn("dbo.Products", "Price");
            DropTable("dbo.Sellers");
        }
    }
}
