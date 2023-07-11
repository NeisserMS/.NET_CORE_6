using Microsoft.EntityFrameworkCore;
using WebAPIAutores.Entidades;

namespace WebAPIAutores
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        /* Crea una tabla en SQL server en base al esquema Autor (clase). */
        public DbSet<Autor> Autores { get; set; }
    
    
    }
}
