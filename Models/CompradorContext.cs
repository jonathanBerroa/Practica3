
using Microsoft.EntityFrameworkCore;

namespace Practica3.Models
{
    public class CompradorContext : DbContext
    {
        public DbSet<Comprador> Compradores { get; set; }

        public DbSet<Categoria> Categorias { get; set; }


        public CompradorContext(DbContextOptions dco) : base(dco)
        {

        }
    }
}