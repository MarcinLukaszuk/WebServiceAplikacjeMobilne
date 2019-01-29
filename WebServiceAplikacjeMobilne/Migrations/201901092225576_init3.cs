namespace WebServiceAplikacjeMobilne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Competitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EventCompetitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventId = c.Int(nullable: false),
                        CompetitionId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Competitions", t => t.CompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.CompetitionId);
            
            CreateTable(
                "dbo.Shooters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Nationality = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShooterEventCompetitions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventCompetitionId = c.Int(nullable: false),
                        ShooterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventCompetitions", t => t.EventCompetitionId, cascadeDelete: true)
                .ForeignKey("dbo.Shooters", t => t.ShooterId, cascadeDelete: true)
                .Index(t => t.EventCompetitionId)
                .Index(t => t.ShooterId);
            
            AddColumn("dbo.Events", "Name", c => c.String());
            DropColumn("dbo.Events", "Nazwa");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Nazwa", c => c.String());
            DropForeignKey("dbo.ShooterEventCompetitions", "ShooterId", "dbo.Shooters");
            DropForeignKey("dbo.ShooterEventCompetitions", "EventCompetitionId", "dbo.EventCompetitions");
            DropForeignKey("dbo.EventCompetitions", "EventId", "dbo.Events");
            DropForeignKey("dbo.EventCompetitions", "CompetitionId", "dbo.Competitions");
            DropIndex("dbo.ShooterEventCompetitions", new[] { "ShooterId" });
            DropIndex("dbo.ShooterEventCompetitions", new[] { "EventCompetitionId" });
            DropIndex("dbo.EventCompetitions", new[] { "CompetitionId" });
            DropIndex("dbo.EventCompetitions", new[] { "EventId" });
            DropColumn("dbo.Events", "Name");
            DropTable("dbo.ShooterEventCompetitions");
            DropTable("dbo.Shooters");
            DropTable("dbo.EventCompetitions");
            DropTable("dbo.Competitions");
        }
    }
}
