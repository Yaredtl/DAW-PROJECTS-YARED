#nullable disable
using System;
using System.Collections.Generic;
using Jardineria_Gabriel.Models;
using Microsoft.EntityFrameworkCore;

namespace Jardineria_Gabriel.Data;

public partial class jardineriaContext : DbContext
{
    public jardineriaContext()
    {
    }

    public jardineriaContext(DbContextOptions<jardineriaContext> options)
        : base(options)
    {

    }

    public virtual DbSet<gama_producto> gama_productos { get; set; }

    public virtual DbSet<producto> productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<JardinUser>().ToTable(a => a.ExcludeFromMigrations());
        modelBuilder.Entity<gama_producto>().ToTable(a => a.ExcludeFromMigrations());
        modelBuilder.Entity<producto>().ToTable(a => a.ExcludeFromMigrations());
        modelBuilder.Entity<gama_producto>(entity =>
        {
            entity.HasKey(e => e.gama).HasName("PK__gama_pro__4877EEE42571FD22");
        });

        modelBuilder.Entity<producto>(entity =>
        {
            entity.HasKey(e => e.codigo_producto).HasName("PK__producto__105107A9B994E646");

            entity.Property(e => e.precio_proveedor).HasDefaultValueSql("(NULL)");
            entity.Property(e => e.proveedor).HasDefaultValueSql("(NULL)");

            entity.HasOne(d => d.gamaNavigation).WithMany(p => p.productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__producto__gama__3D5E1FD2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<Jardineria_Gabriel.Models.Review> Review { get; set; } = default!;
}