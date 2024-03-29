﻿using Microsoft.EntityFrameworkCore;
using Society.Data;
using Society.Models;

namespace Society.Repositories
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly OracleDbContext _dbContext;

        public LocacaoRepository(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Locacao>> ListarLocacoesAsync() 
        {
            var query = await _dbContext.Locacoes.Include(locacao => locacao.Quadra).Include(locacao => locacao.Cliente).ToListAsync();
            return query;
        }

        public async Task CriarLocacao(Locacao locacao) 
        {

            //bool inicioExiste = await _dbContext.Locacoes.AnyAsync(x => x.Inicio == locacao.Inicio);
            //if (inicioExiste)
            //{
            //    throw new InvalidOperationException("A locacao com o mesmo 'inicio' já existe.");
            //}
            //else 
            //{
            //    await _dbContext.AddAsync(locacao);
            //    await _dbContext.SaveChangesAsync();
            //}

            await _dbContext.AddAsync(locacao);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateLocacao(int id, Locacao locacao) 
        {
            var existe = await LocacaoExiste(id);
            if (existe) 
            {
                _dbContext.Locacoes.Update(locacao);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Locacao nao encontrada");
            }
        }

        public async Task DeleteLocacao(int id)
        {
            var existe = await LocacaoExiste(id);
            if (existe)
            {
                var locacao = await _dbContext.Locacoes.FindAsync(id);
                _dbContext.Locacoes.Remove(locacao);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException("Locacao nao encontrada");
            }
        }

        public async Task<bool> LocacaoExiste(int id) 
        {
            var existe = await _dbContext.Locacoes.FindAsync(id);
            return existe is not null ? true : false;
        }
    }
}
