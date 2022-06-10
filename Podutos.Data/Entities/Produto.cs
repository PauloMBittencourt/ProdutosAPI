using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podutos.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string? Nome { get; set; }
        public decimal Valor_unitario { get; set; }
        public int Qtde_estoque { get; set; }
    }
}
