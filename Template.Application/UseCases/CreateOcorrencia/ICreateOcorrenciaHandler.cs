using Template.Domain.Common;

namespace Template.Application.UseCases.CreateOcorrencia
{
    public interface ICreateOcorrenciaHandler
    {
        Task<Response<CreateOcorreniaResponse>> Handle(CreateOcorrenciaRequest request, CancellationToken cancellationToken);
    }
}