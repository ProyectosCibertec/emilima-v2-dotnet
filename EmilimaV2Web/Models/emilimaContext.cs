using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmilimaV2Web.Models;

public partial class EmilimaContext : DbContext
{
    public EmilimaContext()
    {
    }

    public EmilimaContext(DbContextOptions<EmilimaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentRequest> DocumentRequests { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<DocumentalSerie> DocumentalSeries { get; set; }

    public virtual DbSet<File> Files { get; set; }

    public virtual DbSet<HierarchicalDependency> HierarchicalDependencies { get; set; }

    public virtual DbSet<OrganicUnit> OrganicUnits { get; set; }

    public virtual DbSet<RequestState> RequestStates { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPosition> UserPositions { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionString:Connection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.SerialNumber).HasName("PK_document_serial_number");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DocumentSerieId).IsFixedLength();
            entity.Property(e => e.UploadDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.DocumentRequest).WithMany(p => p.Documents).HasConstraintName("document$fk_document_document_request");

            entity.HasOne(d => d.DocumentSerie).WithMany(p => p.Documents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document$fk_document_documental_serie");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Documents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document$fk_document_document_type");

            entity.HasOne(d => d.File).WithMany(p => p.Documents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document$fk_document_file");
        });

        modelBuilder.Entity<DocumentRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_document_request_id");

            entity.Property(e => e.CreationDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.OrganicUnit).WithMany(p => p.DocumentRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_request$fk_request_organic_unit");

            entity.HasOne(d => d.State).WithMany(p => p.DocumentRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_request$fk_request_request_state");

            entity.HasOne(d => d.User).WithMany(p => p.DocumentRequests)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("document_request$fk_request_user");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_document_type_id");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<DocumentalSerie>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK_documental_serie_code");

            entity.Property(e => e.Code).IsFixedLength();
            entity.Property(e => e.DocumentalSerieValue).IsFixedLength();
            entity.Property(e => e.IsPublic)
                .HasDefaultValueSql("(0x01)")
                .IsFixedLength();
            entity.Property(e => e.PhisicalFeatures).HasDefaultValueSql("(N'ND')");

            entity.HasOne(d => d.HierarchicalDependency).WithMany(p => p.DocumentalSeries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("documental_serie$fk_documental_serie_hierarchical_dependency");

            entity.HasOne(d => d.OrganicUnit).WithMany(p => p.DocumentalSeries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("documental_serie$fk_documental_serie_organic_unit");
        });

        modelBuilder.Entity<File>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_file_id");
        });

        modelBuilder.Entity<HierarchicalDependency>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_hierarchical_dependency_id");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<OrganicUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_organic_unit_id");
        });

        modelBuilder.Entity<RequestState>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_request_state_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK_user_username");

            entity.Property(e => e.PhotoId).HasDefaultValueSql("(N'c4042c2a-f106-11ec-8ea0-0242ac120002')");

            entity.HasOne(d => d.Photo).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user$fk_user_file");

            entity.HasOne(d => d.Position).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user$fk_user_user_position");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user$fk_user_user_role");
        });

        modelBuilder.Entity<UserPosition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_user_position_id");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.HierarchicalDependency).WithMany(p => p.UserPositions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_position$fk_user_position_hierarchical_dependency");

            entity.HasOne(d => d.OrganicUnit).WithMany(p => p.UserPositions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_position$fk_user_position_organic_unit");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_user_role_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
