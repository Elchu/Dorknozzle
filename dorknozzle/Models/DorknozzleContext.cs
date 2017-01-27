using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace dorknozzle.Models
{
    public class DorknozzleDbContext : IdentityDbContext
    {
        public DorknozzleDbContext()
            : base("DorknozzleConnection")
        {
        }

        public static DorknozzleDbContext Create()
        {
            return new DorknozzleDbContext();
        }

        public DbSet<Dzialy> Dzialy { get; set; }
        public DbSet<PomocTechniczna> PomocTechniczna { get; set; }
        public DbSet<PomocTechnicznaKategorie> PomocTechnicznaKategorie { get; set; }
        public DbSet<PomocTechnicznaTematy> PomocTechnicznaTematy { get; set; }
        public DbSet<Pracownicy> Pracownicy { get; set; }
        public DbSet<Wiadomosc> Wiadomosc { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //wylacza tworzenie tabel z liczba mnoga
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //wylacza kaskadowe usuwanie powiazan
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}