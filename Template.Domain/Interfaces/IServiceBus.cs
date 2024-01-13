using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    public interface IServiceBus
    {
        Task SendMessageToQueue(Ocorrencia ocorrencia);
    }
}
