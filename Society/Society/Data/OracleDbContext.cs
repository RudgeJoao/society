using Microsoft.EntityFrameworkCore;
using Society.Models;

namespace Society.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Quadra> Quadras { get; set; }

        public DbSet<Locacao> Locacoes { get; set; }
    }
}
