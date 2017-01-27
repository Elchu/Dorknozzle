namespace dorknozzle.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dzialy",
                c => new
                    {
                        DzialId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DzialId);
            
            CreateTable(
                "dbo.Pracownicy",
                c => new
                    {
                        PracownicyId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Adres = c.String(nullable: false),
                        Miasto = c.String(nullable: false),
                        Wojewodztwo = c.Int(nullable: false),
                        KodPocztowy = c.String(),
                        TelefonDomowy = c.String(),
                        TelefonKomorkowy = c.String(),
                        Newsletter = c.Boolean(nullable: false),
                        DzialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PracownicyId)
                .ForeignKey("dbo.Dzialy", t => t.DzialId)
                .Index(t => t.DzialId);
            
            CreateTable(
                "dbo.PomocTechniczna",
                c => new
                    {
                        PomocTechnicznaId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        NunerStanowiska = c.String(nullable: false),
                        AdresIp = c.String(),
                        DataZgloszenia = c.DateTime(nullable: false),
                        Opis = c.String(nullable: false),
                        KategoriaId = c.Int(nullable: false),
                        TematId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PomocTechnicznaId)
                .ForeignKey("dbo.PomocTechnicznaTematy", t => t.TematId)
                .Index(t => t.TematId);
            
            CreateTable(
                "dbo.PomocTechnicznaTematy",
                c => new
                    {
                        TematId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        KategoriaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TematId)
                .ForeignKey("dbo.PomocTechnicznaKategorie", t => t.KategoriaId)
                .Index(t => t.KategoriaId);
            
            CreateTable(
                "dbo.PomocTechnicznaKategorie",
                c => new
                    {
                        KategoriaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KategoriaId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PomocTechnicznaTematy", "KategoriaId", "dbo.PomocTechnicznaKategorie");
            DropForeignKey("dbo.PomocTechniczna", "TematId", "dbo.PomocTechnicznaTematy");
            DropForeignKey("dbo.Pracownicy", "DzialId", "dbo.Dzialy");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PomocTechnicznaTematy", new[] { "KategoriaId" });
            DropIndex("dbo.PomocTechniczna", new[] { "TematId" });
            DropIndex("dbo.Pracownicy", new[] { "DzialId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PomocTechnicznaKategorie");
            DropTable("dbo.PomocTechnicznaTematy");
            DropTable("dbo.PomocTechniczna");
            DropTable("dbo.Pracownicy");
            DropTable("dbo.Dzialy");
        }
    }
}
