namespace Wardrobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableIDs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Outfits", "BottomID", "dbo.Bottoms");
            DropForeignKey("dbo.Outfits", "ShoeID", "dbo.Shoes");
            DropForeignKey("dbo.Outfits", "TopID", "dbo.Tops");
            DropIndex("dbo.Outfits", new[] { "TopID" });
            DropIndex("dbo.Outfits", new[] { "BottomID" });
            DropIndex("dbo.Outfits", new[] { "ShoeID" });
            AlterColumn("dbo.Outfits", "TopID", c => c.Int());
            AlterColumn("dbo.Outfits", "BottomID", c => c.Int());
            AlterColumn("dbo.Outfits", "ShoeID", c => c.Int());
            CreateIndex("dbo.Outfits", "TopID");
            CreateIndex("dbo.Outfits", "BottomID");
            CreateIndex("dbo.Outfits", "ShoeID");
            AddForeignKey("dbo.Outfits", "BottomID", "dbo.Bottoms", "BottomID");
            AddForeignKey("dbo.Outfits", "ShoeID", "dbo.Shoes", "ShoeID");
            AddForeignKey("dbo.Outfits", "TopID", "dbo.Tops", "TopID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Outfits", "TopID", "dbo.Tops");
            DropForeignKey("dbo.Outfits", "ShoeID", "dbo.Shoes");
            DropForeignKey("dbo.Outfits", "BottomID", "dbo.Bottoms");
            DropIndex("dbo.Outfits", new[] { "ShoeID" });
            DropIndex("dbo.Outfits", new[] { "BottomID" });
            DropIndex("dbo.Outfits", new[] { "TopID" });
            AlterColumn("dbo.Outfits", "ShoeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Outfits", "BottomID", c => c.Int(nullable: false));
            AlterColumn("dbo.Outfits", "TopID", c => c.Int(nullable: false));
            CreateIndex("dbo.Outfits", "ShoeID");
            CreateIndex("dbo.Outfits", "BottomID");
            CreateIndex("dbo.Outfits", "TopID");
            AddForeignKey("dbo.Outfits", "TopID", "dbo.Tops", "TopID", cascadeDelete: true);
            AddForeignKey("dbo.Outfits", "ShoeID", "dbo.Shoes", "ShoeID", cascadeDelete: true);
            AddForeignKey("dbo.Outfits", "BottomID", "dbo.Bottoms", "BottomID", cascadeDelete: true);
        }
    }
}
