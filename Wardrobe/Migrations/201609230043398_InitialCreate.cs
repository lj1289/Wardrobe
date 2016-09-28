namespace Wardrobe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accessories",
                c => new
                    {
                        AccessoryID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Photo = c.String(),
                        ColorID = c.Int(),
                        SeasonID = c.Int(),
                        OccasionID = c.Int(),
                        Outfit_OutfitID = c.Int(),
                    })
                .PrimaryKey(t => t.AccessoryID)
                .ForeignKey("dbo.Colors", t => t.ColorID)
                .ForeignKey("dbo.Occasions", t => t.OccasionID)
                .ForeignKey("dbo.Outfits", t => t.Outfit_OutfitID)
                .ForeignKey("dbo.Seasons", t => t.SeasonID)
                .Index(t => t.ColorID)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID)
                .Index(t => t.Outfit_OutfitID);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorID = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                    })
                .PrimaryKey(t => t.ColorID);
            
            CreateTable(
                "dbo.Occasions",
                c => new
                    {
                        OccasionID = c.Int(nullable: false, identity: true),
                        OccasionName = c.String(),
                    })
                .PrimaryKey(t => t.OccasionID);
            
            CreateTable(
                "dbo.Outfits",
                c => new
                    {
                        OutfitID = c.Int(nullable: false, identity: true),
                        OutfitName = c.String(),
                        TopID = c.Int(nullable: false),
                        BottomID = c.Int(nullable: false),
                        ShoeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OutfitID)
                .ForeignKey("dbo.Bottoms", t => t.BottomID, cascadeDelete: true)
                .ForeignKey("dbo.Shoes", t => t.ShoeID, cascadeDelete: true)
                .ForeignKey("dbo.Tops", t => t.TopID, cascadeDelete: true)
                .Index(t => t.TopID)
                .Index(t => t.BottomID)
                .Index(t => t.ShoeID);
            
            CreateTable(
                "dbo.Bottoms",
                c => new
                    {
                        BottomID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Photo = c.String(),
                        ColorID = c.Int(),
                        SeasonID = c.Int(),
                        OccasionID = c.Int(),
                    })
                .PrimaryKey(t => t.BottomID)
                .ForeignKey("dbo.Colors", t => t.ColorID)
                .ForeignKey("dbo.Occasions", t => t.OccasionID)
                .ForeignKey("dbo.Seasons", t => t.SeasonID)
                .Index(t => t.ColorID)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
            CreateTable(
                "dbo.Seasons",
                c => new
                    {
                        SeasonID = c.Int(nullable: false, identity: true),
                        SeasonName = c.String(),
                    })
                .PrimaryKey(t => t.SeasonID);
            
            CreateTable(
                "dbo.Shoes",
                c => new
                    {
                        ShoeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Photo = c.String(),
                        ColorID = c.Int(),
                        SeasonID = c.Int(),
                        OccasionID = c.Int(),
                    })
                .PrimaryKey(t => t.ShoeID)
                .ForeignKey("dbo.Colors", t => t.ColorID)
                .ForeignKey("dbo.Occasions", t => t.OccasionID)
                .ForeignKey("dbo.Seasons", t => t.SeasonID)
                .Index(t => t.ColorID)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
            CreateTable(
                "dbo.Tops",
                c => new
                    {
                        TopID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Photo = c.String(),
                        ColorID = c.Int(),
                        SeasonID = c.Int(),
                        OccasionID = c.Int(),
                    })
                .PrimaryKey(t => t.TopID)
                .ForeignKey("dbo.Colors", t => t.ColorID)
                .ForeignKey("dbo.Occasions", t => t.OccasionID)
                .ForeignKey("dbo.Seasons", t => t.SeasonID)
                .Index(t => t.ColorID)
                .Index(t => t.SeasonID)
                .Index(t => t.OccasionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accessories", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Outfits", "TopID", "dbo.Tops");
            DropForeignKey("dbo.Tops", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Tops", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Tops", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Outfits", "ShoeID", "dbo.Shoes");
            DropForeignKey("dbo.Shoes", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Shoes", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Shoes", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Outfits", "BottomID", "dbo.Bottoms");
            DropForeignKey("dbo.Bottoms", "SeasonID", "dbo.Seasons");
            DropForeignKey("dbo.Bottoms", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Bottoms", "ColorID", "dbo.Colors");
            DropForeignKey("dbo.Accessories", "Outfit_OutfitID", "dbo.Outfits");
            DropForeignKey("dbo.Accessories", "OccasionID", "dbo.Occasions");
            DropForeignKey("dbo.Accessories", "ColorID", "dbo.Colors");
            DropIndex("dbo.Tops", new[] { "OccasionID" });
            DropIndex("dbo.Tops", new[] { "SeasonID" });
            DropIndex("dbo.Tops", new[] { "ColorID" });
            DropIndex("dbo.Shoes", new[] { "OccasionID" });
            DropIndex("dbo.Shoes", new[] { "SeasonID" });
            DropIndex("dbo.Shoes", new[] { "ColorID" });
            DropIndex("dbo.Bottoms", new[] { "OccasionID" });
            DropIndex("dbo.Bottoms", new[] { "SeasonID" });
            DropIndex("dbo.Bottoms", new[] { "ColorID" });
            DropIndex("dbo.Outfits", new[] { "ShoeID" });
            DropIndex("dbo.Outfits", new[] { "BottomID" });
            DropIndex("dbo.Outfits", new[] { "TopID" });
            DropIndex("dbo.Accessories", new[] { "Outfit_OutfitID" });
            DropIndex("dbo.Accessories", new[] { "OccasionID" });
            DropIndex("dbo.Accessories", new[] { "SeasonID" });
            DropIndex("dbo.Accessories", new[] { "ColorID" });
            DropTable("dbo.Tops");
            DropTable("dbo.Shoes");
            DropTable("dbo.Seasons");
            DropTable("dbo.Bottoms");
            DropTable("dbo.Outfits");
            DropTable("dbo.Occasions");
            DropTable("dbo.Colors");
            DropTable("dbo.Accessories");
        }
    }
}
