using Confluent.Kafka;

namespace KafkaExample
{
    public static class KafkaProducerConfig
    {
        public static ProducerConfig GetConfig()
        {
            return new ProducerConfig
            {
                BootstrapServers = "localhost:9092", // Replace with your Kafka broker address
                ClientId = "KafkaExampleProducer",
            };
        }
    }
}