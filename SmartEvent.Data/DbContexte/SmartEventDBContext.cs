using _1.SmartEvent.Core.Modèles;
using Microsoft.EntityFrameworkCore;

namespace _1.SmartEvent.Data.DbContexte
{
    public class SmartEventDBContext : DbContext
    {
        public SmartEventDBContext(DbContextOptions<SmartEventDBContext> options)
            : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Inscription> Inscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship between Utilisateur and Evenement through Inscription
            modelBuilder.Entity<Inscription>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Inscription>()
                .HasOne(i => i.Utilisateur)
                .WithMany(u => u.Inscriptions)  // Explicit navigation property
                .HasForeignKey(i => i.UtilisateurId);

            modelBuilder.Entity<Inscription>()
                .HasOne(i => i.Evenement)
                .WithMany(e => e.Inscriptions)  // Explicit navigation property
                .HasForeignKey(i => i.EvenementId);

            // Configure discriminator for Personne inheritance
            modelBuilder.Entity<Personne>()
                .HasDiscriminator<string>("Role")
                .HasValue<Utilisateur>("User")
                .HasValue<Admin>("Admin");
        }
    }
}
