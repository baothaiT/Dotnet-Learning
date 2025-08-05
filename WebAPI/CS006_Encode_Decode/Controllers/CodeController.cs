using System.Text;
using CS006_Encode_Decode.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS006_Encode_Decode.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : ControllerBase
    {
        [HttpPost("encode")]
        public IActionResult Encode([FromBody] TextRequest request)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(request.Text);
            var encoded = Convert.ToBase64String(plainTextBytes);
            return Ok(new { encoded });
        }

        [HttpPost("decode")]
        public IActionResult Decode([FromBody] TextRequest request)
        {
            try
            {
                var decodedBytes = Convert.FromBase64String(request.Text);
                var decoded = Encoding.UTF8.GetString(decodedBytes);
                return Ok(new { decoded });
            }
            catch
            {
                return BadRequest("Invalid Base64 input.");
            }
        }
    }
}
