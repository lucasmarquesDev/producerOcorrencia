using Template.Domain.Common;

namespace Template.Application.UseCases.CreateOcorrencia
{
    public sealed class CreateOcorreniaResponse
    {
        public string EnderecoCompleto { get; set; }
        public int QuantidadeVolumes { get; set; }
    }
}