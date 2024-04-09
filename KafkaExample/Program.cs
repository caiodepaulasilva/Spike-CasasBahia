using System;
using Confluent.Kafka;
using KafkaExample;

class Program
{
    static void Main()
    {
        var config = KafkaProducerConfig.GetConfig();

        using var producer = new ProducerBuilder<Null, string>(config).Build();
        string topic = "Estoque";
        string message = "Hello, Kafka!";
        var deliveryReport = producer.ProduceAsync(topic, new Message<Null, string> { Value = message }).Result;
        Console.WriteLine($"Produced message to {deliveryReport.Topic} partition {deliveryReport.Partition} @ offset {deliveryReport.Offset}");
    }
}