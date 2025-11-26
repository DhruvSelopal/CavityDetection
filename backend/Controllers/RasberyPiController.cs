using CavityDetection.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace CavityDetection.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RasberyPiController : Controller
    {
        private DentalCheckUpContext _context;
        private RasberyPiService _rasberyPiService;
        public RasberyPiController(DentalCheckUpContext context,RasberyPiService rasberyPiService)
        {
            _context = context;
            _rasberyPiService = rasberyPiService;
        }

        [HttpPost]
        public async Task<IActionResult> SaveImageData(
            [FromForm] string username,
            [FromForm] double confidenceLevel,
            [FromForm] IFormFile imageFile
        )
            {
                if (imageFile == null || imageFile.Length == 0)
                    return BadRequest("No file uploaded.");

                await _rasberyPiService.SaveImageData(username, confidenceLevel, imageFile);
                return Ok("File uploaded successfully");
            }
    }
}
