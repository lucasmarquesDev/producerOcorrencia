using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Text;
using System.Text.Json;
using Template.Application.UseCases.CreateOcorrencia;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Persistence.ServiceBus
{
    public class ServiceBus : IServiceBus
    {
        private readonly IConfiguration _configuration;

        public ServiceBus(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMessageToQueue(Ocorrencia ocorrencia)
        {
            IQueueClient client = new QueueClient(_configuration["AzureServiceBusConnectionString"], _configuration["QueueName"]);

            //Serialize car details object
            var messageBody = JsonSerializer.Serialize(ocorrencia);

            //Set content type and Guid
            var message = new Message(Encoding.UTF8.GetBytes(messageBody))
            {
                MessageId = Guid.NewGuid().ToString(),
                ContentType = "application/json"
            };

            await client.SendAsync(message);
        }
    }
}
