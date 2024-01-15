using Microsoft.EntityFrameworkCore;
using Society.Data;
using Society.Models;

namespace Society.Repositories
{
    public class QuadrasRepository
    {
        private readonly OracleDbContext _dbContext;

        public QuadrasRepository(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private async Task<bool> QuadraExiste(int id)
        {
            var existente = await _dbContext.Quadras.FindAsync(id);
            if (existente is not null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<Quadra>> ListarQuadrasAsync() 
        {
            var query = await _dbContext.Quadras.ToListAsync();
            return query;
        }

        public async Task CriarQuadra(Quadra quadra) 
        {
            await _dbContext.AddAsync(quadra);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateQuadraAsync(int id , Quadra quadra) 
        {
            var existe = await QuadraExiste(id);

            if (existe)
            {
                _dbContext.Quadras.Update(quadra);
                await _dbContext.SaveChangesAsync();
            }
            else 
            {
                throw new ArgumentException("Quadra não encontrada");
            }
        }

        public async Task DeleteQuadraAsync(int id)
        {
            var existe = await QuadraExiste(id);
            if (existe is true)
            {
                var quadra = await _dbContext.Quadras.FindAsync(id);
                _dbContext.Quadras.Remove(quadra);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Quadra não encontrada");
            }
        }
    }
}
