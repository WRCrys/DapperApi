using DapperApi.Interface;
using DapperApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApi.Service
{
    public class ProdutoService
    {
        ProdutoInterface _produto;

        public Task ObterProduto(int id)
        {
            var result = _produto.GetProduto(id);

            return result;
        }

        public Task<IEnumerable<Produto>> ObterTodos()
        {
            var result = _produto.ObterTodos();

            return result;
        }

        public Task<int> Adicionar(Produto produto)
        {
            var result = _produto.Adicionar(produto);

            return result;
        }
    }
}
