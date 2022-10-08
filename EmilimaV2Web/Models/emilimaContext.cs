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
        public virtual DbSet<UserPosition> UserPositions { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

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

                entity.ToTable("document", "emilima");

                entity.HasIndex(e => e.Name, "document$name_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.DocumentRequestId, "fk_documentation_document_request_idx");

                entity.HasIndex(e => e.DocumentSerieId, "fk_documentation_documental_serie_idx");

                entity.HasIndex(e => e.DocumentTypeId, "fk_documentation_documentation_type_idx");

                entity.HasIndex(e => e.FileId, "fk_documentation_file1_idx");

                entity.Property(e => e.SerialNumber).HasColumnName("serial_number");

                entity.Property(e => e.CreationDate)
                    .HasPrecision(0)
                    .HasColumnName("creation_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.DocumentRequestId).HasColumnName("document_request_id");

                entity.Property(e => e.DocumentSerieId)
                    .HasMaxLength(6)
                    .HasColumnName("document_serie_id")
                    .IsFixedLength();

                entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");

                entity.Property(e => e.FileId)
                    .HasMaxLength(48)
                    .HasColumnName("file_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.UploadDate)
                    .HasPrecision(0)
                    .HasColumnName("upload_date")
                    .HasDefaultValueSql("(getdate())");

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
                entity.ToTable("document_request", "emilima");

                entity.HasIndex(e => e.OrganicUnitId, "fk_request_organic_unit_idx");

                entity.HasIndex(e => e.StateId, "fk_request_request_state_idx");

                entity.HasIndex(e => e.UserId, "user_id_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreationDate)
                    .HasPrecision(0)
                    .HasColumnName("creation_date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.OrganicUnitId).HasColumnName("organic_unit_id");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.Property(e => e.UserId)
                    .HasMaxLength(45)
                    .HasColumnName("user_id");

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
                entity.ToTable("document_type", "emilima");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<DocumentalSerie>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_documental_serie_code");

                entity.ToTable("documental_serie", "emilima");

                entity.HasIndex(e => e.Name, "documental_serie$name_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.HierarchicalDependencyId, "fk_documental_serie_hierarchical_dependency_idx");

                entity.HasIndex(e => e.OrganicUnitId, "fk_documental_serie_organic_unit_idx");

                entity.Property(e => e.Code)
                    .HasMaxLength(6)
                    .HasColumnName("code")
                    .IsFixedLength();

                entity.Property(e => e.Definition).HasColumnName("definition");

                entity.Property(e => e.DocumentalSerieValue)
                    .HasMaxLength(1)
                    .HasColumnName("documental_serie_value")
                    .IsFixedLength();

                entity.Property(e => e.ElaborationDate)
                    .HasPrecision(0)
                    .HasColumnName("elaboration_date");

                entity.Property(e => e.HierarchicalDependencyId).HasColumnName("hierarchical_dependency_id");

                entity.Property(e => e.IsPublic)
                    .HasMaxLength(1)
                    .HasColumnName("is_public")
                    .HasDefaultValueSql("(0x01)")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.NormativeScope).HasColumnName("normative_scope");

                entity.Property(e => e.OrganicUnitId).HasColumnName("organic_unit_id");

                entity.Property(e => e.PhisicalFeatures)
                    .HasMaxLength(45)
                    .HasColumnName("phisical_features")
                    .HasDefaultValueSql("(N'ND')");

                entity.Property(e => e.ServiceFrequency)
                    .HasMaxLength(45)
                    .HasColumnName("service_frequency");

                entity.Property(e => e.YearsInCentralArchive).HasColumnName("years_in_central_archive");

                entity.Property(e => e.YearsInManagementArchive).HasColumnName("years_in_management_archive");

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

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("file", "emilima");

                entity.Property(e => e.Id)
                    .HasMaxLength(48)
                    .HasColumnName("id");

                entity.Property(e => e.Filename).HasColumnName("filename");
            });

            modelBuilder.Entity<HierarchicalDependency>(entity =>
            {
                entity.ToTable("hierarchical_dependency", "emilima");

                entity.HasIndex(e => e.Name, "hierarchical_dependency$name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<OrganicUnit>(entity =>
            {
                entity.ToTable("organic_unit", "emilima");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RequestState>(entity =>
            {
                entity.ToTable("request_state", "emilima");

                entity.HasIndex(e => e.Name, "request_state$name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("User");

                entity.Property(e => e.Email).HasMaxLength(10);

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .IsFixedLength();

                entity.Property(e => e.PhotoId)
                    .HasMaxLength(45)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .IsFixedLength();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK_user_username");

                entity.ToTable("user", "emilima");

                entity.HasIndex(e => e.PositionId, "fk_user_user_position_idx");

                entity.HasIndex(e => e.PhotoId, "photo_idx");

                entity.HasIndex(e => e.RoleId, "role_idx");

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .HasColumnName("username");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.Property(e => e.PhotoId)
                    .HasMaxLength(48)
                    .HasColumnName("photo_id")
                    .HasDefaultValueSql("(N'c4042c2a-f106-11ec-8ea0-0242ac120002')");

                entity.Property(e => e.PositionId).HasColumnName("position_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

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
                entity.ToTable("user_position", "emilima");

                entity.HasIndex(e => e.HierarchicalDependencyId, "fk_user_position_hierarchical_dependency_idx");

                entity.HasIndex(e => e.OrganicUnitId, "fk_user_position_organic_unit_idx");

                entity.HasIndex(e => e.Name, "user_position$name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.HierarchicalDependencyId).HasColumnName("hierarchical_dependency_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.OrganicUnitId).HasColumnName("organic_unit_id");

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

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role", "emilima");

                entity.HasIndex(e => e.Name, "user_role$name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
