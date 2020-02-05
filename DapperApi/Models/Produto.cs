using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApi.Models
{
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "O nome deve ter de 1 até 100 caracteres")]
        public string Nome { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "O valor deve ser maior ou igual a 1")]
        public int Estoque { get; set; }

        [Required]
        public float Preco { get; set; }
    }
}
