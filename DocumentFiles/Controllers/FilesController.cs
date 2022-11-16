using System;
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
        public async Task<ActionResult<byte[]>> GetFile(string filename)
        {
            string path = Path.Combine(_configuration["FileStorage"], filename);

            byte[] fileInBytes = await IO.File.ReadAllBytesAsync(path);

            if (fileInBytes.Length == 0)
            {
                return NotFound();
            }

            return fileInBytes;
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
