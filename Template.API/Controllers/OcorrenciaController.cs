using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Application.UseCases.CreateOcorrencia;
using Template.Domain.Common;

namespace Template.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OcorrenciaController : ControllerBase
    {
        IMediator _mediator;
        public OcorrenciaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary> 
        /// Endpoint criar uma ocorrencia
        /// </summary>
        [HttpPost("create")]
        [ProducesResponseType(typeof(Response<dynamic>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response<>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response<>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateOcorrenciaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var ocorrenciaId = await _mediator.Send(request);

                return ocorrenciaId.Status switch
                {
                    500 => StatusCode(StatusCodes.Status500InternalServerError, ocorrenciaId),
                    200 => Ok(ocorrenciaId),
                    204 => NoContent(),
                    400 => BadRequest(ocorrenciaId),
                    401 => Unauthorized(ocorrenciaId)
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
