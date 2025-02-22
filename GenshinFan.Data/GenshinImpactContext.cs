using Microsoft.EntityFrameworkCore;

namespace GenshinFan.Data;

public class GenshinImpactContext : DbContext
{
    public GenshinImpactContext(DbContextOptions<GenshinImpactContext> options)
        : base(options)
    {
    }

    public DbSet<Elemento> Elementos { get; set; }
    public DbSet<Region> Regiones { get; set; }
    public DbSet<TipoDeArma> TiposDeArma { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Elemento>().ToTable("Elemento");
        modelBuilder.Entity<Region>().ToTable("Region");
        modelBuilder.Entity<TipoDeArma>().ToTable("TipoDeArma");
    }
}