using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmilimaV2Web.Models
{
    public partial class emilimaContext : DbContext
    {
        public emilimaContext()
        {
        }

        public emilimaContext(DbContextOptions<emilimaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<DocumentRequest> DocumentRequests { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public virtual DbSet<DocumentalSerie> DocumentalSeries { get; set; } = null!;
        public virtual DbSet<File> Files { get; set; } = null!;
        public virtual DbSet<HierarchicalDependency> HierarchicalDependencies { get; set; } = null!;
        public virtual DbSet<OrganicUnit> OrganicUnits { get; set; } = null!;
        public virtual DbSet<RequestState> RequestStates { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<User1> Users1 { get; set; } = null!;
        public virtual DbSet<UserPosition> UserPositions { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionString:Connection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.SerialNumber)
                    .HasName("PK_document_serial_number");

                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DocumentSerieId).IsFixedLength();

                entity.Property(e => e.UploadDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.DocumentRequest)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.DocumentRequestId)
                    .HasConstraintName("document$fk_document_document_request");

                entity.HasOne(d => d.DocumentSerie)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.DocumentSerieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("document$fk_document_documental_serie");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("document$fk_document_document_type");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("document$fk_document_file");
            });

            modelBuilder.Entity<DocumentRequest>(entity =>
            {
                entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.OrganicUnit)
                    .WithMany(p => p.DocumentRequests)
                    .HasForeignKey(d => d.OrganicUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("document_request$fk_request_organic_unit");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.DocumentRequests)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("document_request$fk_request_request_state");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DocumentRequests)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("document_request$fk_request_user");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DocumentalSerie>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_documental_serie_code");

                entity.Property(e => e.Code).IsFixedLength();

                entity.Property(e => e.DocumentalSerieValue).IsFixedLength();

                entity.Property(e => e.IsPublic)
                    .HasDefaultValueSql("(0x01)")
                    .IsFixedLength();

                entity.Property(e => e.PhisicalFeatures).HasDefaultValueSql("(N'ND')");

                entity.HasOne(d => d.HierarchicalDependency)
                    .WithMany(p => p.DocumentalSeries)
                    .HasForeignKey(d => d.HierarchicalDependencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("documental_serie$fk_documental_serie_hierarchical_dependency");

                entity.HasOne(d => d.OrganicUnit)
                    .WithMany(p => p.DocumentalSeries)
                    .HasForeignKey(d => d.OrganicUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("documental_serie$fk_documental_serie_organic_unit");
            });

            modelBuilder.Entity<HierarchicalDependency>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password).IsFixedLength();

                entity.Property(e => e.PhotoId).IsFixedLength();

                entity.Property(e => e.Username).IsFixedLength();
            });

            modelBuilder.Entity<User1>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK_user_username");

                entity.Property(e => e.PhotoId).HasDefaultValueSql("(N'c4042c2a-f106-11ec-8ea0-0242ac120002')");

                entity.HasOne(d => d.Photo)
                    .WithMany(p => p.User1s)
                    .HasForeignKey(d => d.PhotoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user$fk_user_file");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.User1s)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user$fk_user_user_position");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User1s)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user$fk_user_user_role");
            });

            modelBuilder.Entity<UserPosition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.HierarchicalDependency)
                    .WithMany(p => p.UserPositions)
                    .HasForeignKey(d => d.HierarchicalDependencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_position$fk_user_position_hierarchical_dependency");

                entity.HasOne(d => d.OrganicUnit)
                    .WithMany(p => p.UserPositions)
                    .HasForeignKey(d => d.OrganicUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_position$fk_user_position_organic_unit");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
