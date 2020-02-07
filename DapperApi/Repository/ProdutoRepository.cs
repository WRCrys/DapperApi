using Dapper;
using DapperApi.Interface;
using DapperApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApi.Repository
{
    public class ProdutoRepository : IProduto
    {
        IConfiguration _configuration;

        public ProdutoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DapperConnectionPagueMenos").Value;
            return connection;
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            var connectionString = this.GetConnection();
            List<Produto> produtos = new List<Produto>();

            using (var con = new SqlConnection(connectionString))
            {
                IEnumerable<Produto> result;
                try
                {
                    var sql = "SELECT * FROM Produtos";
                    result = await con.QueryAsync<Produto>(sql);

                }
                catch (Exception error)
                {
                    throw error;
                }
                return result.ToList();

            }
        }

        public async Task<Produto> GetProduto(int id)
        {
            var connectionString = this.GetConnection();
            Produto produto = new Produto();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var sql = "SELECT * FROM Produtos WHERE ProdutoId = @ID";
                    await con.QueryAsync<Produto>(sql, new { ID = id });
                    // return result.FirstOrDefault();
                }
                catch (Exception error)
                {
                    throw error;
                }
                finally
                {
                    con.Close();
                }
                return con.FirstOrDefault();

            }
        }

        public async Task Adicionar(Produto produto)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {

                try
                {
                    con.Open();
                    var sql = @"
                        INSERT INTO Produtos (Nome, Estoque, Preco)
                        VALUES (@Nome, @Estoque, @Preco);
                    ";
                    await con.ExecuteAsync(sql, produto);

                }
                catch (Exception error)
                {
                    throw error;
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public async Task Update(Produto produto)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var sql = "UPDATE Produtos SET Name = @Nome, Estoque = @Estoque, Preco = @Preco WHERE ProdutoId = " + produto.ProdutoId;
                    await con.ExecuteAsync(sql, produto);
                }
                catch (Exception error)
                {
                    throw error;
                }
                finally
                {
                    con.Close();
                }


            }

        }

        public async Task Delete(int id)
        {
            var connectionString = this.GetConnection();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var sql = "DELETE FROM Produtos WHERE ProdutoId = " + id;
                    await con.ExecuteAsync(sql);
                }
                catch (Exception error)
                {
                    throw error;
                }
                finally
                {
                    con.Close();
                }


            }
        }
    }
}
