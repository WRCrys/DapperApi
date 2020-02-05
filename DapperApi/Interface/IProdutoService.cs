using DapperApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApi.Interface
{
    public interface IProdutoService
    {
        Task <IEnumerable<Produto>> ObterTodos();
        Task ObterProduto(int id);
        Task Adicionar(Produto produto);
        Task Update(Produto produto);
        Task Delete(int id);
    }
}
