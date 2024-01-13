using FluentValidation;
using Template.Domain.Entities;
  
namespace Template.UnitTests.Validations
{
    public class OcorrenciaValidator : AbstractValidator<Ocorrencia>
    {
        public OcorrenciaValidator()
        {
            RuleFor(n => n.EnderecoCompleto)
                .NotEmpty().WithMessage("Endereço não pode ser vazio !")
                .MaximumLength(20).WithMessage("O endereço deve ter até 20 caracteres");

            RuleFor(n => n.QuantidadeVolumes)
                .NotNull().WithMessage("Quantidade de volumes não pode ser vazio !")
                .GreaterThan(0).WithMessage("Quantidade de volumes deve ser maior que 0 !");

            RuleFor(n => n.DtCriacao)
                .NotNull().WithMessage("Data não pode ser vazio !");
        }
    }
}
