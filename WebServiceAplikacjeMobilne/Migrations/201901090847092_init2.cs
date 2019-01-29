namespace WebServiceAplikacjeMobilne.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Competitions", newName: "Events");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Events", newName: "Competitions");
        }
    }
}
