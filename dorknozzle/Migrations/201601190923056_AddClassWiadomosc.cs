namespace dorknozzle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassWiadomosc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Wiadomosc",
                c => new
                    {
                        WiadomoscId = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 20),
                        Content = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.WiadomoscId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Wiadomosc");
        }
    }
}
