using Microsoft.EntityFrameworkCore;

namespace donglers.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Models.Autentifikacija> Autentifikacija { get; set; }
    public DbSet<Models.Admin> Admin { get; set; }
    public DbSet<Models.Korisnik> Korisnik { get; set; }
    public DbSet<Models.Lekcija> Lekcija { get; set; }
    public DbSet<Models.Level> Level { get; set; }
    public DbSet<Models.Kurs> Kurs { get; set; }
    public DbSet<Models.Poruka> Poruka { get; set; }
    public DbSet<Models.KorisnikLekcija> KorisnikLekcija { get; set; }

    
}