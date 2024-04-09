using Application.Services;
using Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Spike_CasasBahia.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KafkaController(ILogger<KafkaController> logger, IKafkaService kafkaService) : ControllerBase
    {
        private readonly ILogger<KafkaController> _logger = logger;
        private readonly IKafkaService _kafkaService = kafkaService;
        private readonly string topic = "Estoque";

        [HttpPost]
        public IActionResult Post([FromQuery] string message)
        {
            var result = _kafkaService.SendToKafka(topic, message);
            _logger.LogInformation(result.ToString());

            return Created(string.Empty, result);
        }
    }
}

