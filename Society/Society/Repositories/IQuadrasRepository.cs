using Society.Models;

namespace Society.Repositories
{
    public interface IQuadrasRepository
    {
        Task<List<Quadra>> ListarQuadrasAsync();
        Task CriarQuadra(Quadra quadra);
        Task UpdateQuadraAsync(int id, Quadra quadra);
        Task DeleteQuadraAsync(int id);
    }
}