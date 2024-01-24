using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Validate.Validations;

namespace Template.Application.UseCases.CreateOcorrencia
{
    public sealed class CreateOcorrenciaValidador : AbstractValidator<CreateOcorrenciaRequest>
    {
        public CreateOcorrenciaValidador()
        {
            RuleFor(n => n.EnderecoCompleto)
               .NotEmpty().WithMessage(ErrorMessages.EnderecoObrigatorio)
               .MinimumLength(3).WithMessage(ErrorMessages.EnderecoTamanhoMinimo)
               .MaximumLength(30).WithMessage(ErrorMessages.EnderecoTamanhoMaximo);

            RuleFor(n => n.QuantidadeVolumes)
                .NotNull().WithMessage(ErrorMessages.QuantidadeVolumesObrigatorio)
                .GreaterThan(0).WithMessage(ErrorMessages.QuantidadeVolumesMinimo)
                .LessThanOrEqualTo(10).WithMessage(ErrorMessages.QuantidadeVolumesMaximo);
        }
    }
}
