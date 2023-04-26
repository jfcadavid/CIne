using Cine.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cine.Shared.Entities;

namespace Stores.API.Controllers
{
    [ApiController]
    [Route("/api/colombia")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Colombia colombia)
        {
            _context.Add(colombia);
            await _context.SaveChangesAsync();
            return Ok(colombia);
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Colombia.ToListAsync());
        }

    }
}
