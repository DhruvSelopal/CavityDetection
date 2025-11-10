using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CavityDetection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebController : Controller
    {
        private DentalCheckUpContext _context;
        public WebController(DentalCheckUpContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public ActionResult<string> Login(Login login)
        {
            return Ok($"Logged in successfully using {login.username}");
        }
    }
}
