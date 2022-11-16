namespace CodeFirstDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Dni = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Mail = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.InvoiceDetails",
                c => new
                    {
                        InvoiceDetailID = c.Int(nullable: false, identity: true),
                        InvoiceID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        SellerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceDetailID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Sellers", t => t.SellerID, cascadeDelete: true)
                .Index(t => t.InvoiceID)
                .Index(t => t.CustomerID)
                .Index(t => t.SellerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDetails", "SellerID", "dbo.Sellers");
            DropForeignKey("dbo.InvoiceDetails", "InvoiceID", "dbo.Invoices");
            DropForeignKey("dbo.InvoiceDetails", "CustomerID", "dbo.Customers");
            DropIndex("dbo.InvoiceDetails", new[] { "SellerID" });
            DropIndex("dbo.InvoiceDetails", new[] { "CustomerID" });
            DropIndex("dbo.InvoiceDetails", new[] { "InvoiceID" });
            DropTable("dbo.InvoiceDetails");
            DropTable("dbo.Customers");
        }
    }
}
