namespace Game.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HeroesMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Level = c.Int(nullable: false),
                        FreePoints = c.Int(nullable: false),
                        Experience = c.Int(nullable: false),
                        Health = c.Int(nullable: false),
                        Protection = c.Int(nullable: false),
                        Attack = c.Int(nullable: false),
                        Evasion = c.Int(nullable: false),
                        Crit = c.Int(nullable: false),
                        Picture = c.String(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Heroes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Heroes", new[] { "UserId" });
            DropTable("dbo.Heroes");
        }
    }
}
