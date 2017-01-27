namespace dorknozzle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsuniecieStatusuZKategorii : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PomocTechniczna", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.PomocTechnicznaKategorie", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PomocTechnicznaKategorie", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.PomocTechniczna", "Status");
        }
    }
}
