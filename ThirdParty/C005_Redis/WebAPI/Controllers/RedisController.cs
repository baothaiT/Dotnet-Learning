using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace WebAPI.Controllers
{
    public class RedisController : Controller
    {
        private readonly IDatabase _database;

        public RedisController(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        [HttpPost("set")]
        public async Task<IActionResult> SetValue(string key, string value)
        {
            await _database.StringSetAsync(key, value);
            return Ok($"Key '{key}' set successfully!");
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetValue(string key)
        {
            var value = await _database.StringGetAsync(key);
            if (value.IsNullOrEmpty)
                return NotFound("Key not found");

            return Ok(value.ToString());
        }
    }
}
