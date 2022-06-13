namespace Produtos.API.DTOs
{
    public class GetProdutoDto
    {
        public string? Nome_Prod { get; set; }
        public decimal Valor_unitario { get; set; }
        public int Qtde_estoque { get; set; }
    }
}
