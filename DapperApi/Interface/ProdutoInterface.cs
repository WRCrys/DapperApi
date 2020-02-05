using DapperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApi.Interface
{
    public interface ProdutoInterface
    {
        Task<int> Adicionar(Produto produto);
        Task <IEnumerable<Produto>> ObterTodos();
        Task<Produto> GetProduto(int id);
        Task<int> Update(Produto produto);
        Task<int> Delete(int id);
    }
}
