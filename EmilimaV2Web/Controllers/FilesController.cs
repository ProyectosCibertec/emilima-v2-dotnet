using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmilimaV2Web.Models;
using File = EmilimaV2Web.Models.File;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;

namespace EmilimaV2Web.Controllers
{
    [Authorize]
    public class FilesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly EmilimaContext _context;
        private readonly ILogger<FilesController> _logger;
        private readonly IConfiguration _configuration;

        public FilesController(
            EmilimaContext context, 
            IHttpClientFactory httpClientFactory, 
            ILogger<FilesController> logger, 
            IConfiguration configuration)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<IActionResult> DownloadPdf(string fileName)
        {
            using HttpClient client = _httpClientFactory.CreateClient();

            try
            {
                _logger.Log(LogLevel.Information, "--- {0}.{1} ---", GetType(), MethodBase.GetCurrentMethod() ?? null);

                HttpResponseMessage httpResponse = await client.GetAsync($"{_configuration["ApiDomains:DocumentFiles"]}/api/files/{fileName}");
                MemoryStream memoryStream = (MemoryStream)await httpResponse.Content.ReadAsStreamAsync();

                Response.Headers.Add("Content-Disposition", $"attachment; filename={fileName}");

                return new FileStreamResult(memoryStream, "application/pdf");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, "Exception: {0}", ex.StackTrace);
            }

            return StatusCode(500);
        }
    }
}
