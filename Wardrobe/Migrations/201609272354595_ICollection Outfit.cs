namespace Wardrobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ICollectionOutfit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accessories", "Outfit_OutfitID", "dbo.Outfits");
            DropIndex("dbo.Accessories", new[] { "Outfit_OutfitID" });
            CreateTable(
                "dbo.OutfitAccessories",
                c => new
                    {
                        Outfit_OutfitID = c.Int(nullable: false),
                        Accessory_AccessoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Outfit_OutfitID, t.Accessory_AccessoryID })
                .ForeignKey("dbo.Outfits", t => t.Outfit_OutfitID, cascadeDelete: true)
                .ForeignKey("dbo.Accessories", t => t.Accessory_AccessoryID, cascadeDelete: true)
                .Index(t => t.Outfit_OutfitID)
                .Index(t => t.Accessory_AccessoryID);
            
            DropColumn("dbo.Accessories", "Outfit_OutfitID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accessories", "Outfit_OutfitID", c => c.Int());
            DropForeignKey("dbo.OutfitAccessories", "Accessory_AccessoryID", "dbo.Accessories");
            DropForeignKey("dbo.OutfitAccessories", "Outfit_OutfitID", "dbo.Outfits");
            DropIndex("dbo.OutfitAccessories", new[] { "Accessory_AccessoryID" });
            DropIndex("dbo.OutfitAccessories", new[] { "Outfit_OutfitID" });
            DropTable("dbo.OutfitAccessories");
            CreateIndex("dbo.Accessories", "Outfit_OutfitID");
            AddForeignKey("dbo.Accessories", "Outfit_OutfitID", "dbo.Outfits", "OutfitID");
        }
    }
}
