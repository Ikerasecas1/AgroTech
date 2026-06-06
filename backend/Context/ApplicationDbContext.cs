using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Crew> Crews { get; set; }

    public virtual DbSet<CrewMember> CrewMembers { get; set; }

    public virtual DbSet<Crop> Crops { get; set; }

    public virtual DbSet<Incident> Incidents { get; set; }

    public virtual DbSet<QrToken> QrTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<TimeRecord> TimeRecords { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkCenter> WorkCenters { get; set; }

    public virtual DbSet<Worker> Workers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("Name=ConnectionStrings:PostgresConnection");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Crew>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_crews");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Status).HasDefaultValueSql("'Active'::character varying");

            entity.HasOne(d => d.ForemanWorker).WithMany(p => p.Crews)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_crews_foreman");
        });

        modelBuilder.Entity<CrewMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_crew_members");

            entity.Property(e => e.AssignedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasOne(d => d.Crew).WithMany(p => p.CrewMembers).HasConstraintName("fk_crew_members_crew");

            entity.HasOne(d => d.Worker).WithMany(p => p.CrewMembers).HasConstraintName("fk_crew_members_worker");
        });

        modelBuilder.Entity<Crop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_crops");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Status).HasDefaultValueSql("'Active'::character varying");

            entity.HasOne(d => d.Sector).WithMany(p => p.Crops).HasConstraintName("fk_crops_sector");
        });

        modelBuilder.Entity<Incident>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_incidents");

            entity.Property(e => e.Status).HasDefaultValueSql("'Open'::character varying");

            entity.HasOne(d => d.Crop).WithMany(p => p.Incidents).HasConstraintName("fk_incidents_crop");
        });

        modelBuilder.Entity<QrToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_qr_tokens");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.GeneratedByUser).WithMany(p => p.QrTokens).HasConstraintName("fk_qr_tokens_user");

            entity.HasOne(d => d.WorkCenter).WithMany(p => p.QrTokens).HasConstraintName("fk_qr_tokens_work_center");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_pkey");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_sectors");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
        });

        modelBuilder.Entity<TimeRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_time_records");

            entity.Property(e => e.QrType).HasDefaultValueSql("'STATIC_HQ'::character varying");
            entity.Property(e => e.ValidationStatus).HasDefaultValueSql("'VALID'::character varying");

            entity.HasOne(d => d.Crew).WithMany(p => p.TimeRecords).HasConstraintName("fk_time_records_crew");

            entity.HasOne(d => d.WorkCenter).WithMany(p => p.TimeRecords)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_time_records_work_center");

            entity.HasOne(d => d.Worker).WithMany(p => p.TimeRecords).HasConstraintName("fk_time_records_worker");
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_treatments");

            entity.HasOne(d => d.Crop).WithMany(p => p.Treatments).HasConstraintName("fk_treatments_crop");

            entity.HasOne(d => d.Incident).WithMany(p => p.Treatments)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_treatments_incident");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_users");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.RoleId).HasDefaultValue(4);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_user_role");
        });

        modelBuilder.Entity<WorkCenter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_work_centers");

            entity.Property(e => e.AllowedRadiusMeters).HasDefaultValue(50);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Worker>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_workers");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.Status).HasDefaultValueSql("'Active'::character varying");

            entity.HasOne(d => d.User).WithOne(p => p.Worker)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("fk_workers_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
