using ppedv.HalloTaco.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ppedv.HalloTaco.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<BestellItem> BestellItems { get; set; }
        public DbSet<Taco> Tacos { get; set; }

        public EfContext(string conString) : base(conString)
        { }

        public EfContext() : this("Server=.;Database=Taco;Trusted_Connection=true;")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Artikel>().Property(x => x.Preis).HasColumnName("Price").IsRequired();

            modelBuilder.Entity<Artikel>().ToTable(nameof(this.Artikel));
            modelBuilder.Entity<Taco>().ToTable(nameof(this.Tacos));


        }
    }
}
