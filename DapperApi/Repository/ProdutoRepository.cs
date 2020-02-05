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
    public class ProdutoRepository : ProdutoInterface
    {
        IConfiguration _configuration;

        public ProdutoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DapperConnection").Value;
            return connection;
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            var connectionString = this.GetConnection();
            List<Produto> produtos = new List<Produto>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var sql = "SELECT * FROM Produtos";
                    var result = await con.QueryAsync<Produto>(sql);
                    return result.ToList();
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
                    var result = await con.QueryAsync<Produto>(sql, new { ID = id });
                    return result.FirstOrDefault();
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

        public async Task<int> Adicionar(Produto produto)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var sql = "INSERT INTO Produtos (Nome, Estoque, Preco) VALUES (@Nome, @Estoque, @Preco);" +
                        "SELECT CAST (SCOPE_IDENTITY() AS INT);";
                    count = await con.ExecuteAsync(sql, produto);
                    
                }
                catch (Exception error)
                {
                    throw error;
                }
                finally
                {
                    con.Close();
                }
                return count;

            }
        }

        public async Task<int> Update(Produto produto)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var sql = "UPDATE Produtos SET Name = @Nome, Estoque = @Estoque, Preco = @Preco WHERE ProdutoId = " + produto.ProdutoId;
                    count = await con.ExecuteAsync(sql, produto);
                }
                catch (Exception error)
                {
                    throw error;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }

        }

        public async Task<int> Delete(int id)
        {
            var connectionString = this.GetConnection();
            var count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var sql = "DELETE FROM Produtos WHERE ProdutoId = " + id;
                    count = await con.ExecuteAsync(sql);
                }
                catch (Exception error)
                {
                    throw error;
                }
                finally
                {
                    con.Close();
                }

                return count;
            }
        }
    }
}
