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

        public ProdutoController(ProdutoService service)
        {
            _produto = service;
                
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult<Produto> Produto()
        {
            try
            {
                var produtos = _produto.ObterTodos();
                return Ok(produtos);
            }
            catch (Exception error)
            {
                return BadRequest($"{ error.Message } - { error.InnerException?.Message }");
            }

        }

        [HttpGet("{id}")]
        public ActionResult<Produto> ObterProduto(int id)
        {
            var produto = _produto.ObterProduto(id);

            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> Adicionar(Produto produto)
        {
            try
            {
                await _produto.Adicionar(produto);
                return Ok();
            }
            catch (Exception e)
            {
                //o ponto de interrogação é parar quando o InnerException for nulo
                return BadRequest($"{ e.Message } - { e.InnerException?.Message }");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(Produto produto)
        {
            try
            {
                await _produto.Update(produto);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest($"{ error.Message } - { error.InnerException?.Message }");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                await _produto.Delete(id);
                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest($"{ error.Message } - { error.InnerException?.Message}");
            }
        }
    }
}