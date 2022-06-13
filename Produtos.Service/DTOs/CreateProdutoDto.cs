namespace Produtos.Service.DTOs
{
    public class CreateProdutoDto
    {
        public string? Nome_Prod { get; set; }
        public decimal Valor_unitario { get; set; }
        public int Qtde_estoque { get; set; }
    }
}
