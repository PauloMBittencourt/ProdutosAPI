using FluentValidation;
using Produtos.API.DTOs;

namespace Produtos.API.Validator
{
    public class CreateProdutoDtoValidator : AbstractValidator<CreateProdutoDto>
    {
        public CreateProdutoDtoValidator()
        {
            RuleFor(x => x.Nome_Prod)
                .NotEmpty().WithMessage("O {PropertyName} não pode ser vazio")
                .Length(20, 100).WithMessage("O {PropertyName} não pode ser menor que 20 ou maior que 100 caracteres");

            RuleFor(x => x.Qtde_estoque)
                .NotEmpty().WithMessage("O {PropertyName} não pode ser vazio")
                .LessThan(0).WithMessage("O {PropertyName} não pode ser menor que 0");

            RuleFor(x => x.Valor_unitario)
                .NotEmpty().WithMessage("O {PropertyName} não pode ser vazio")
                .LessThan(0).WithMessage("O {PropertyName} não pode ser menor que 0");
        }
    }
}
