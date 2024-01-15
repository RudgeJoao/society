using Microsoft.EntityFrameworkCore;
using Society.Data;
using Society.Migrations;
using Society.Models;
using System.Runtime.InteropServices;

namespace Society.Services
{
    public class ClientesRepository : IClientesRepository
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

        public async Task CriarClienteAsync(Cliente cliente) 
        {
            await _dbContext.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(int id,Cliente cliente)
        {
            var existe = await ClienteExiste(id);
            if (existe is true) 
            {
                _dbContext.Clientes.Update(cliente);
                await _dbContext.SaveChangesAsync();
            }
            else 
            {
                throw new ArgumentException("Cliente nao encontrado");
            }
        }

        public async Task DeleteClienteAsync(int id)
        { 
            var existe = await ClienteExiste(id);
            if (existe is true)
            {
                var cliente =  await _dbContext.Clientes.FindAsync(id);
                _dbContext.Clientes.Remove(cliente);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Cliente nao encontrado");
            }
        }



        private async Task<bool> ClienteExiste(int id)
        {
            var existente = await _dbContext.Clientes.FindAsync(id);
            if (existente is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
