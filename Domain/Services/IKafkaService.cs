using Domain.DTOs;
using Domain.Entities;

namespace Domain.Services;

public interface IKafkaService
{
    Task ProduceAsync(string topic, ProductDto product);
}