using Microsoft.AspNetCore.Mvc;
using MinioWebApi.Services;

namespace MinioWebApi.Controllers
{
    public class MinioController : Controller
    {
        private readonly MinioService _minioService;

        public MinioController(MinioService minioService)
        {
            _minioService = minioService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File is empty");

            await _minioService.UploadFileAsync(file);
            return Ok($"File {file.FileName} uploaded successfully.");
        }

        [HttpGet("files")]
        public async Task<IActionResult> ListFiles()
        {
            var files = await _minioService.ListFilesAsync();
            return Ok(files);
        }

        [HttpGet("download/{fileName}")]
        public async Task<IActionResult> DownloadFile(string fileName)
        {
            var fileStream = await _minioService.DownloadFileAsync(fileName);
            return File(fileStream, "application/octet-stream", fileName);
        }
    }
}
