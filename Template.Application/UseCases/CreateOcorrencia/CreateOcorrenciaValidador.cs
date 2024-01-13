using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Application.UseCases.CreateOcorrencia
{
    public sealed class CreateOcorrenciaValidador : AbstractValidator<CreateOcorrenciaRequest>
    {
        public CreateOcorrenciaValidador()
        {
            RuleFor(x => x.EnderecoCompleto).NotEmpty().WithMessage("O Endereço não pode ser vazio !").MaximumLength(20).WithMessage("O endereço deve ter até 20 caracteres");
            RuleFor(x => x.QuantidadeVolumes).NotNull().WithMessage("A Quantidade de volumes não pode ser vazio !").GreaterThan(0).WithMessage("O volume deve ser maior que 0");
            RuleFor(n => n.DataSolicitacao).NotNull().WithMessage("Data não pode ser vazio !");
        }
    }
}
