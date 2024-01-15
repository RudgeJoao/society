using Society.Models;

namespace Society.Services
{
    public interface IClientesRepository
    {
        Task<List<Cliente>> ListarClientesAsync();
        Task CriarClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(int id, Cliente cliente);
        Task DeleteClienteAsync(int id);
    }
}