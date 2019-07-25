using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
    public class SamuraiContext:DbContext
    {
        public SamuraiContext()
        {
        }

        public SamuraiContext(DbContextOptions<SamuraiContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        

        public DbSet<Samurai> Samurais { get; set; }

        public DbSet<Quote> Quotes { get; set; }

        public DbSet<Battle> Battles { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<SecretIdentity> SecretIdentities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>()
                .HasKey(s => new { s.BattleId, s.SamuraiId });

            modelBuilder.Entity<SamuraiBattle>()
                .HasOne(sb => sb.Battle)
                .WithMany(b => b.SamuraiBattles)
                .HasForeignKey(sb => new { sb.BattleId });

            modelBuilder.Entity<SamuraiBattle>()
                .HasOne(sb => sb.Samurai)
                .WithMany(s => s.SamuraiBattles)
                .HasForeignKey(sb => new { sb.SamuraiId });

            modelBuilder.Entity<Teacher>()
                .ToTable("Teachers")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Samurai>()
                .HasOne(e => e.Teacher)
                .WithMany(e => e.Samurais)
                .IsRequired();

            modelBuilder.Entity<SecretIdentity>()
                .ToTable("SecretIdentities");

            modelBuilder.Entity<SecretIdentity>()
                .HasOne(e => e.Samurai)
                .WithOne(e => e.SecretIdentity) 
                .HasForeignKey<Samurai>()
                .IsRequired(false);

            modelBuilder.Entity<Quote>()
                .HasOne(e => e.Samurai)
                .WithMany(e => e.Quotes);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=SamuraiApplicationCore;User ID=sa;pwd=123");
        }
    }
}
