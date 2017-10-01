using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mm.Api.Models
{
    public partial class mmContext : DbContext
    {
        public virtual DbSet<ObjProperties> ObjProperties { get; set; }

        public mmContext(DbContextOptions<mmContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjProperties>(entity =>
            {
                entity.HasKey(e => e.PropertyId);

                entity.ToTable("ObjProperties", "main");

                entity.HasIndex(e => e.PropertyName)
                    .HasName("idxPropertyName")
                    .IsUnique();

                entity.Property(e => e.PropertyId)
                    .HasColumnName("PropertyID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Marked)
                    .IsRequired()
                    .HasColumnType("binary(1)");

                entity.Property(e => e.PropertyName)
                    .IsRequired()
                    .HasMaxLength(100);
            });
        }
    }
}
