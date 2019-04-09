namespace GesperForms
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelGesper : DbContext
    {
        public ModelGesper()
            : base("name=ModelGesper")
        {
        }

        public virtual DbSet<diplome> diplomes { get; set; }
        public virtual DbSet<employe> employes { get; set; }
        public virtual DbSet<service> services { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<diplome>()
                .Property(e => e.dip_libelle)
                .IsUnicode(false);

            modelBuilder.Entity<diplome>()
                .HasMany(e => e.employes)
                .WithMany(e => e.diplomes)
                .Map(m => m.ToTable("posseder", "gesper").MapLeftKey("pos_diplome").MapRightKey("pos_employe"));

            modelBuilder.Entity<employe>()
                .Property(e => e.emp_nom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.emp_prenom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.emp_sexe)
                .IsUnicode(false);

            modelBuilder.Entity<service>()
                .Property(e => e.ser_designation)
                .IsUnicode(false);

            modelBuilder.Entity<service>()
                .Property(e => e.ser_type)
                .IsUnicode(false);

            modelBuilder.Entity<service>()
                .Property(e => e.ser_produit)
                .IsUnicode(false);

            modelBuilder.Entity<service>()
                .HasMany(e => e.employes)
                .WithOptional(e => e.service)
                .HasForeignKey(e => e.emp_service);
        }
    }
}
