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
        public string? Nome_Prod { get; set; }
        public decimal Valor_unitario { get; set; }
        public int Qtde_estoque { get; set; }
        public DateTime? Data_Ultima_Venda { get; set; } = null;
        public decimal? Valor_Ultima_Venda { get; set; } = null;

        public void SetData()
        {
            Data_Ultima_Venda = DateTime.Now.Date;
        }

        public void DecreaseEstoque(int valor)
        {
            Qtde_estoque -= valor;
        }
    }
}
