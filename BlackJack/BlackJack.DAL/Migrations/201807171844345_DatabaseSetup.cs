namespace BlackJack.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Face = c.Int(nullable: false),
                        Suit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Score = c.Int(),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WinnerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(),
                        RoundId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rounds", t => t.RoundId)
                .Index(t => t.RoundId);
            
            CreateTable(
                "dbo.UserCards",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Card_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Card_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cards", t => t.Card_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.RoundUsers",
                c => new
                    {
                        Round_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Round_Id, t.User_Id })
                .ForeignKey("dbo.Rounds", t => t.Round_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Round_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoundUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.RoundUsers", "Round_Id", "dbo.Rounds");
            DropForeignKey("dbo.Games", "RoundId", "dbo.Rounds");
            DropForeignKey("dbo.UserCards", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.UserCards", "User_Id", "dbo.Users");
            DropIndex("dbo.RoundUsers", new[] { "User_Id" });
            DropIndex("dbo.RoundUsers", new[] { "Round_Id" });
            DropIndex("dbo.UserCards", new[] { "Card_Id" });
            DropIndex("dbo.UserCards", new[] { "User_Id" });
            DropIndex("dbo.Games", new[] { "RoundId" });
            DropTable("dbo.RoundUsers");
            DropTable("dbo.UserCards");
            DropTable("dbo.Games");
            DropTable("dbo.Rounds");
            DropTable("dbo.Users");
            DropTable("dbo.Cards");
        }
    }
}
