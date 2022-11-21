using IO = System.IO;
using Microsoft.AspNetCore.Mvc;

namespace DocumentFiles.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : Controller
    {
        private IConfiguration _configuration;

        public FilesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{filename}")]
        public IActionResult GetFile(string filename)
        {
            string path = Path.Combine(_configuration["FileStorage"], filename);

            FileStream fileStream = new(path, FileMode.Open);

            return new FileStreamResult(fileStream, "application/octet-stream");
        }

        [HttpPost]
        public async Task<IActionResult> PostFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                string path = Path.Combine(_configuration["FileStorage"], file.FileName);

                using (var stream = IO.File.Create(path))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return Ok();
        }
    }
}
