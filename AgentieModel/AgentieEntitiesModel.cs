using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AgentieModel
{
   

    public partial class AgentieEntitiesModel : DbContext
    {
        public AgentieEntitiesModel()
            : base("name=AgentieEntitiesModel")
        {
        }

        public virtual DbSet<Activitati> Activitatis { get; set; }
        public virtual DbSet<Cereri> Cereris { get; set; }
        public virtual DbSet<Contacte> Contactes { get; set; }
        public virtual DbSet<Facturi> Facturis { get; set; }
        public virtual DbSet<Proprietati> Proprietatis { get; set; }
         
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activitati>()
                .Property(e => e.descriere)
                .IsUnicode(false);

            modelBuilder.Entity<Cereri>()
                .Property(e => e.descriere)
                .IsUnicode(false);

            modelBuilder.Entity<Contacte>()
                .Property(e => e.nume)
                .IsUnicode(false);

            modelBuilder.Entity<Contacte>()
                .Property(e => e.nr_tel)
                .IsUnicode(false);

            modelBuilder.Entity<Contacte>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<Contacte>()
                .HasMany(e => e.Activitatis)
                .WithRequired(e => e.Contacte)
                .HasForeignKey(e => e.id_contact);

            modelBuilder.Entity<Contacte>()
                .HasMany(e => e.Cereris)
                .WithRequired(e => e.Contacte)
                .HasForeignKey(e => e.id_contact);

            modelBuilder.Entity<Contacte>()
                .HasMany(e => e.Facturis)
                .WithRequired(e => e.Contacte)
                .HasForeignKey(e => e.id_contact);

            modelBuilder.Entity<Proprietati>()
                .Property(e => e.tip_oferta)
                .IsUnicode(false);

            modelBuilder.Entity<Proprietati>()
                .Property(e => e.zona)
                .IsUnicode(false);

            modelBuilder.Entity<Proprietati>()
                .Property(e => e.amplasament)
                .IsUnicode(false);

            modelBuilder.Entity<Proprietati>()
                .Property(e => e.adresa)
                .IsUnicode(false);

            modelBuilder.Entity<Proprietati>()
                .HasMany(e => e.Activitatis)
                .WithOptional(e => e.Proprietati)
                .HasForeignKey(e => e.id_proprietate)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Proprietati>()
                .HasMany(e => e.Facturis)
                .WithRequired(e => e.Proprietati)
                .HasForeignKey(e => e.id_proprietate);
        }
    }
}
