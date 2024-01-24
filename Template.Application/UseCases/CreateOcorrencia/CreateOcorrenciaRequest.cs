using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Domain.Common;

namespace Template.Application.UseCases.CreateOcorrencia
{
    public sealed class CreateOcorrenciaRequest : IRequest<Response<CreateOcorreniaResponse>>
    {
        public string EnderecoCompleto { get; set; }
        public int QuantidadeVolumes { get; set; }
    }
}
