using AutoMapper;
using MediatR;
using Template.Domain.Common;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Application.UseCases.CreateOcorrencia
{
    public class CreateOcorrenciaHandler :
       IRequestHandler<CreateOcorrenciaRequest, Response<CreateOcorreniaResponse>>
    {
        private readonly IServiceBus _serviceBus;
        private readonly IMapper _mapper;

        public CreateOcorrenciaHandler(IServiceBus serviceBus, IMapper mapper)
        {
            _serviceBus = serviceBus;
            _mapper = mapper;
        }

        public async Task<Response<CreateOcorreniaResponse>> Handle(CreateOcorrenciaRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var ocorrencia = _mapper.Map<Ocorrencia>(request);

                await _serviceBus.SendMessageToQueue(ocorrencia);

                var ocorrenciaResponse = _mapper.Map<CreateOcorreniaResponse>(ocorrencia);

                return new Response<CreateOcorreniaResponse> { Status = 200, Data = ocorrenciaResponse, IsSuccess = true, Title = "Ocorrencia cadastrada com sucesso !" };
            }
            catch (Exception)
            {
                return new Response<CreateOcorreniaResponse> { Status = 500, IsSuccess = false, Title = "Internal Server Error" };
            }
        }
    }
}
