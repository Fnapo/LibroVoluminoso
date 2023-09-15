
using LibroVoluminoso.Models;
using Microsoft.EntityFrameworkCore;

namespace LibroVoluminoso.Data
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions<AppDbContext> opciones) : base(opciones)
        {
            
        }

        public DbSet<Categoria> Categorias { get; set; }
    }
}
