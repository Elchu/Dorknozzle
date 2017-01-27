namespace dorknozzle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShortContent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Wiadomosc", "ShortContent", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Wiadomosc", "Content", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Wiadomosc", "Content", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Wiadomosc", "ShortContent");
        }
    }
}
