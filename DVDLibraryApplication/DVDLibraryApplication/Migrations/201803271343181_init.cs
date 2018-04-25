namespace DVDLibraryApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DirectorEFs",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        DirectorName = c.String(),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.dvdEFs",
                c => new
                    {
                        dvdId = c.Int(nullable: false, identity: true),
                        directorId = c.Int(nullable: false),
                        ratingId = c.Int(),
                        title = c.String(),
                        realeaseYear = c.String(),
                        notes = c.String(),
                    })
                .PrimaryKey(t => t.dvdId)
                .ForeignKey("dbo.DirectorEFs", t => t.directorId, cascadeDelete: true)
                .ForeignKey("dbo.RatingEFs", t => t.ratingId)
                .Index(t => t.directorId)
                .Index(t => t.ratingId);
            
            CreateTable(
                "dbo.RatingEFs",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        RatingName = c.String(),
                    })
                .PrimaryKey(t => t.RatingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.dvdEFs", "ratingId", "dbo.RatingEFs");
            DropForeignKey("dbo.dvdEFs", "directorId", "dbo.DirectorEFs");
            DropIndex("dbo.dvdEFs", new[] { "ratingId" });
            DropIndex("dbo.dvdEFs", new[] { "directorId" });
            DropTable("dbo.RatingEFs");
            DropTable("dbo.dvdEFs");
            DropTable("dbo.DirectorEFs");
        }
    }
}
