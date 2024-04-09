using Domain.Services;
using Confluent.Kafka;

namespace Application.Services
{
    public class KafkaService(): IKafkaService
    {
        private readonly ProducerConfig config = new ProducerConfig { BootstrapServers = "localhost:9093" };        

        public Object SendToKafka(string topic, string message)
        {
            using (var producer =
                 new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    return producer.ProduceAsync(topic, new Message<Null, string> { Value = message })
                        .GetAwaiter()
                        .GetResult();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Oops, something went wrong: {e}");
                }
            }
            return null;
        }

    }
}
