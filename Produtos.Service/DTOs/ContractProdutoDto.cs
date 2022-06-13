using Podutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Service.DTOs
{
    public class ContractProdutoDto
    {
        public int ProdutoId { get; set; }
        public int Qtde_Comprada { get; set; } 
        public Cartao Cartoes { get; set; }
    }
}
