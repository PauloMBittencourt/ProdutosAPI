using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Podutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Data.Mapping
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable(nameof(Produto));

            builder.HasKey(x => x.ProdutoId);
            builder.Property(x => x.ProdutoId)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome_Prod)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Valor_unitario)
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(x => x.Qtde_estoque)
                .IsRequired();
        }
    }
}
