using Produtos.Data.Interfaces;
using Produtos.Data.Respositories;
using Produtos.Service.Interfaces;
using Produtos.Service.Services;

namespace Produtos.API.Extensions
{
    public static class DependenceInjectionExtensions
    {
        public static IServiceCollection AddDependenceInjection(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();

            return services;
        }
    }
}
