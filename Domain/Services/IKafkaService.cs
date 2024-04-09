namespace Domain.Services;

public interface IKafkaService
{
    Object SendToKafka(string topic, string message);
}