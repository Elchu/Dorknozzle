namespace dorknozzle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelacjaMiedzyKategoriaApomocaTechniczna : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.PomocTechniczna", "KategoriaId");
            AddForeignKey("dbo.PomocTechniczna", "KategoriaId", "dbo.PomocTechnicznaKategorie", "KategoriaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PomocTechniczna", "KategoriaId", "dbo.PomocTechnicznaKategorie");
            DropIndex("dbo.PomocTechniczna", new[] { "KategoriaId" });
        }
    }
}
