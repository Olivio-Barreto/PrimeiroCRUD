using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Entities;

namespace PrimeiraApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Usuario> Usuarios { get; set; }
}
