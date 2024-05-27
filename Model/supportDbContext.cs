using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace soporte_back_dotnet.Model
{
    public partial class supportDbContext : DbContext
    {
        public supportDbContext()
        {
        }

        public supportDbContext(DbContextOptions<supportDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Supportticket> Supporttickets { get; set; } = null!;
        public virtual DbSet<Typesupport> Typesupports { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=roundhouse.proxy.rlwy.net;port=29569;database=supportDb;user=root;password=tnWxRBtDhjhhASYnwGRHWPgRpYonGeru", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.4.0-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb3_general_ci")
                .HasCharSet("utf8mb3");

            modelBuilder.Entity<Supportticket>(entity =>
            {
                entity.ToTable("supporttickets");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answer)
                    .HasMaxLength(45)
                    .HasColumnName("answer");

                entity.Property(e => e.Companyid).HasColumnName("companyid");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasColumnName("description");

                entity.Property(e => e.Hour)
                    .HasMaxLength(45)
                    .HasColumnName("hour");

                entity.Property(e => e.Status)
                    .HasMaxLength(45)
                    .HasColumnName("status");

                entity.Property(e => e.Ticketdate)
                    .HasMaxLength(15)
                    .HasColumnName("ticketdate");

                entity.Property(e => e.Tittle)
                    .HasMaxLength(45)
                    .HasColumnName("tittle");

                entity.Property(e => e.Typesupportid).HasColumnName("typesupportid");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<Typesupport>(entity =>
            {
                entity.ToTable("typesupport");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasMaxLength(45)
                    .HasColumnName("description");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
