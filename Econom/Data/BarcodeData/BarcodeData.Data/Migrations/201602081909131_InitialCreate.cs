namespace BarcodeData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UPCs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Barcode = c.String(maxLength: 25),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.Barcode)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        ImageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.ImageId, cascadeDelete: true)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.Binary(),
                        FileExtension = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UPCs", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ImageId", "dbo.Images");
            DropIndex("dbo.Products", new[] { "ImageId" });
            DropIndex("dbo.UPCs", new[] { "ProductId" });
            DropIndex("dbo.UPCs", new[] { "Barcode" });
            DropTable("dbo.Images");
            DropTable("dbo.Products");
            DropTable("dbo.UPCs");
        }
    }
}
