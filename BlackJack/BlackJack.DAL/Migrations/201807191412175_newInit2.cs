namespace BlackJack.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newInit2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CardViewModels", "UserViewModel_Id", "dbo.UserViewModels");
            DropForeignKey("dbo.RoundViewModels", "UserViewModel_Id", "dbo.UserViewModels");
            DropIndex("dbo.CardViewModels", new[] { "UserViewModel_Id" });
            DropIndex("dbo.RoundViewModels", new[] { "UserViewModel_Id" });
            DropTable("dbo.UserViewModels");
            DropTable("dbo.CardViewModels");
            DropTable("dbo.RoundViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RoundViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WinnerId = c.Int(),
                        UserViewModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CardViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Face = c.Int(nullable: false),
                        Suit = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        UserViewModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Score = c.Int(),
                        Result = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.RoundViewModels", "UserViewModel_Id");
            CreateIndex("dbo.CardViewModels", "UserViewModel_Id");
            AddForeignKey("dbo.RoundViewModels", "UserViewModel_Id", "dbo.UserViewModels", "Id");
            AddForeignKey("dbo.CardViewModels", "UserViewModel_Id", "dbo.UserViewModels", "Id");
        }
    }
}
