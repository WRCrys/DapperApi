using DapperApi.Interface;
using DapperApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApi.Service
{
    public class ProdutoService : IProdutoService
    {
        IProduto repository;

        public ProdutoService(IProduto repository)
        {
            this.repository = repository;
        }

        public Task ObterProduto(int id)
        {
            var result = repository.GetProduto(id);

            return result;
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await repository.ObterTodos();
        }

        public async Task Adicionar(Produto produto)
        {
            await repository.Adicionar(produto);
        }

        public async Task Update(Produto produto)
        {
            await repository.Update(produto);

        }

        public async Task Delete(int id)
        {
            await repository.Delete(id);
        }
    }
}
