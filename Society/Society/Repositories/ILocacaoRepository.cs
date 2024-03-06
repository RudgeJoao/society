using Society.Models;

namespace Society.Repositories
{
    public interface ILocacaoRepository
    {
        Task<List<Locacao>> ListarLocacoesAsync();

        Task CriarLocacao(Locacao locacao);

        Task UpdateLocacao(int id, Locacao locacao);

        Task DeleteLocacao(int id);

    }
}