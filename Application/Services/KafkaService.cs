using Domain.Services;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Domain.DTOs;
using Domain.Entities;
using System.Text.Json;

namespace Application.Services
{
    public class KafkaService: IKafkaService
    {
        private readonly IConfiguration _configuration;
        private readonly IProducer<string, string> _producer;

        public KafkaService(IConfiguration configuration)
        {
            _configuration = configuration;
            var producerconfig = new ProducerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"]
            };

            _producer = new ProducerBuilder<string, string>(producerconfig).Build();
        }

        public async Task ProduceAsync(string topic, ProductDto product)
        {            
            var kafkamessage = new Message<string, string> 
            {                
                Value = JsonSerializer.Serialize(product)
            };

            await _producer.ProduceAsync(topic, kafkamessage);
        }

    }
}
