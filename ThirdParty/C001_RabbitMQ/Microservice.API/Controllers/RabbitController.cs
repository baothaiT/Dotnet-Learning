using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Microservice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RabbitController : ControllerBase
    {
        private const string QueueName = "test-queue";
        public RabbitController()
        {

        }

        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] string message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            var msgModel = new
            {
                id = 1, 
                msg = "msg",
                name = "name"
            };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();

            string msgJson = JsonSerializer.Serialize(msgModel);

            await channel.QueueDeclareAsync(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(msgJson);

            await channel.BasicPublishAsync(exchange: string.Empty, routingKey: "hello", body: body);

            return Ok(new { Message = "Message sent", Data = message });
        }
    }
}
