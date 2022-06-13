namespace Produtos.Service.DTOs
{
    public class GetProdutoDto
    {
        public int Id { get; set; }
        public string? Nome_Prod { get; set; }
        public decimal Valor_unitario { get; set; }
        public int Qtde_estoque { get; set; }
    }
}
