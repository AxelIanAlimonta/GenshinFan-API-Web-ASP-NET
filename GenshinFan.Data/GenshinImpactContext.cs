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
    public DbSet<Personaje> Personajes { get; set; }
    public DbSet<Arma> Armas { get; set; }
    public DbSet<PersonajeArmaRecomendada> PersonajeArmaRecomendada { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Elemento>().ToTable("Elemento");
        modelBuilder.Entity<Region>().ToTable("Region");
        modelBuilder.Entity<TipoDeArma>().ToTable("TipoDeArma");
        modelBuilder.Entity<Personaje>().ToTable("Personaje");
        modelBuilder.Entity<Arma>().ToTable("Armas");
        modelBuilder.Entity<PersonajeArmaRecomendada>().ToTable("PersonajeArmaRecomendada");

        // Configurar la relación uno a muchos entre Personaje y Elemento
        modelBuilder.Entity<Personaje>()
            .HasOne(p => p.Elemento)
            .WithMany(e => e.Personajes)
            .HasForeignKey(p => p.Id_Elemento);

        // Configurar la relación uno a muchos entre Personaje y Region
        modelBuilder.Entity<Personaje>()
            .HasOne(p => p.Region)
            .WithMany(r => r.Personajes)
            .HasForeignKey(p => p.Id_Region);

        // Configurar la relación uno a muchos entre Personaje y TipoDeArma
        modelBuilder.Entity<Personaje>()
            .HasOne(p => p.TipoDeArma)
            .WithMany(t => t.Personajes)
            .HasForeignKey(p => p.Id_TipoDeArma);

        // Configurar la clave compuesta para PersonajeArmaRecomendada
        modelBuilder.Entity<PersonajeArmaRecomendada>()
            .HasKey(par => new { par.PersonajeId, par.ArmaId });

        // Configurar las relaciones de claves foráneas para PersonajeArmaRecomendada
        modelBuilder.Entity<PersonajeArmaRecomendada>()
            .HasOne<Personaje>()
            .WithMany()
            .HasForeignKey(par => par.PersonajeId);

        modelBuilder.Entity<PersonajeArmaRecomendada>()
            .HasOne<Arma>()
            .WithMany()
            .HasForeignKey(par => par.ArmaId);
    }
}