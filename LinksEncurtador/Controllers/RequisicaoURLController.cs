using EncurtadorLinks.Models;
using EncurtadorLinks.Services;
using LinksEncurtador.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LinksEncurtador.Core.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RequisicaoURLController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly HttpContext _httpContext;
        private readonly URLShortening _shortener;
        public RequisicaoURLController(AppDbContext context, URLShortening shortener)
        {
            _context = context;
            _shortener = shortener;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string request)
        {
            if (!Uri.TryCreate(request, UriKind.Absolute, out _)) return BadRequest("Formato Inválido");

            var code = await _shortener.GenerateURL();

            var shortURL = new RequisicaoURL(
                request, 
                $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/RequisicaoURL/api/{code}", 
                code);

            _context.URLsEncurtadas.Add(shortURL);

            await _context.SaveChangesAsync();
            return Ok(shortURL.ShortenedURL);
        }

        [Route("api/{code}")]
        [HttpGet]
        public async Task<IActionResult> RedirectToURL(string code)
        {
            var shortURL = await _context.URLsEncurtadas.FirstOrDefaultAsync(s => s.Code == code);

            if (shortURL == null)
            {
                return NotFound();
            }

            return Redirect(shortURL.OriginalURL);
        }

    }
}
