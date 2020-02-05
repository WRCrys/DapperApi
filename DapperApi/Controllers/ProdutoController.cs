using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperApi.Interface;
using DapperApi.Models;
using DapperApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace DapperApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        ProdutoService _produto;
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{id}")]
        public ActionResult<Produto> ObterProduto(int id)
        {
            var produto = _produto.ObterProduto(id);

            if (produto == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        public ActionResult<Produto> Adicionar(Produto produto)
        {
            var result = _produto.Adicionar(produto);

            if(result > 1)
        }
    }
}