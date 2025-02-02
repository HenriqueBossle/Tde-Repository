using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Cliente> Clientes {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=clientes.db");
    }
}