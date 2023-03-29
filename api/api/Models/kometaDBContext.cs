using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace api.Models
{
    public partial class kometaDBContext : DbContext
    {
        

        public kometaDBContext(DbContextOptions<kometaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NorthernPacific> NorthernPacifics { get; set; }
        public virtual DbSet<Phi> Phis { get; set; }
        public virtual DbSet<S1v1> S1v1s { get; set; }
        public virtual DbSet<S1v2> S1v2s { get; set; }
        public virtual DbSet<S2v1> S2v1s { get; set; }
        public virtual DbSet<S2v2> S2v2s { get; set; }
        public virtual DbSet<S3v1> S3v1s { get; set; }
        public virtual DbSet<S3v2> S3v2s { get; set; }
        public virtual DbSet<V> Vs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NorthernPacific>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("northern_pacific");

                entity.Property(e => e.S).HasColumnName("s");

                entity.Property(e => e.T).HasColumnName("t");

                entity.Property(e => e.Z).HasColumnName("z");
            });

            modelBuilder.Entity<Phi>(entity =>
            {
                entity.ToTable("phi");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Phi1).HasColumnName("phi");
            });

            modelBuilder.Entity<S1v1>(entity =>
            {
                entity.ToTable("s1v1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.H).HasColumnName("h");

                entity.Property(e => e.V).HasColumnName("v");
            });

            modelBuilder.Entity<S1v2>(entity =>
            {
                entity.ToTable("s1v2");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.H).HasColumnName("h");

                entity.Property(e => e.V).HasColumnName("v");
            });

            modelBuilder.Entity<S2v1>(entity =>
            {
                entity.ToTable("s2v1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.H).HasColumnName("h");

                entity.Property(e => e.V).HasColumnName("v");
            });

            modelBuilder.Entity<S2v2>(entity =>
            {
                entity.ToTable("s2v2");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.H).HasColumnName("h");

                entity.Property(e => e.V).HasColumnName("v");
            });

            modelBuilder.Entity<S3v1>(entity =>
            {
                entity.ToTable("s3v1");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.H).HasColumnName("h");

                entity.Property(e => e.V).HasColumnName("v");
            });

            modelBuilder.Entity<S3v2>(entity =>
            {
                entity.ToTable("s3v2");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.H).HasColumnName("h");

                entity.Property(e => e.V).HasColumnName("v");
            });

            modelBuilder.Entity<V>(entity =>
            {
                entity.ToTable("v");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.V1).HasColumnName("v");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
