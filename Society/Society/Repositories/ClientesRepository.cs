using Microsoft.EntityFrameworkCore;
using Society.Data;
using Society.Models;

namespace Society.Services
{
    public class ClientesRepository
    {
        private readonly OracleDbContext _dbContext;
        public ClientesRepository(OracleDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cliente>> ListarClientesAsync() 
        {
            var query = await _dbContext.Clientes.ToListAsync();
            return query;
        }
    }
}
