using Microsoft.EntityFrameworkCore;

namespace KutuphanMVC.Models {
    public class KutuphanContext : DbContext
    {
        public KutuphanContext() { }
        public KutuphanContext(DbContextOptions<KutuphanContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Kutuphandb.db");
        }

        public DbSet<Admin> admins { get; set; }
        public DbSet<Kullanici> kullanicis { get; set; }
        public DbSet<Kitap> kitaps { get; set; }
        public DbSet<EmanetKitap> emanetKitaps { get; set; }
        public DbSet<Mesaj> mesajs { get; set; }
      

    }
}