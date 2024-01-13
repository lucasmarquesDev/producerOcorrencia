using AutoMapper;
using Template.Domain.Entities;

namespace Template.Application.UseCases.CreateOcorrencia
{
    public sealed class CreateOcorrenciaMapper : Profile
    {
        public CreateOcorrenciaMapper()
        {
            CreateMap<CreateOcorrenciaRequest, Ocorrencia>();
            CreateMap<Ocorrencia, CreateOcorreniaResponse>();
        }
    }
}
