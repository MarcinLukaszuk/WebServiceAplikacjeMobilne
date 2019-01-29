namespace WebServiceAplikacjeMobilne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addShoot : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shoots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShooterEventCompetitionId = c.Int(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShooterEventCompetitions", t => t.ShooterEventCompetitionId, cascadeDelete: false)
                .Index(t => t.ShooterEventCompetitionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shoots", "ShooterEventCompetitionId", "dbo.ShooterEventCompetitions");
            DropIndex("dbo.Shoots", new[] { "ShooterEventCompetitionId" });
            DropTable("dbo.Shoots");
        }
    }
}
