using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EncurtadorLinks.Models;
using LinksEncurtador.Core.Entities;

namespace LinksEncurtador.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisicaoURLsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RequisicaoURLsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RequisicaoURLs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequisicaoURL>>> GetURLsEncurtadas()
        {
            return await _context.URLsEncurtadas.ToListAsync();
        }

        // DELETE: api/RequisicaoURLs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequisicaoURL(Guid id)
        {
            var requisicaoURL = await _context.URLsEncurtadas.FindAsync(id);
            if (requisicaoURL == null)
            {
                return NotFound();
            }

            _context.URLsEncurtadas.Remove(requisicaoURL);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
