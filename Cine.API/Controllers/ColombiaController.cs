using Cine.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cine.Shared.Entities;
using System.Diagnostics.Metrics;

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

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var colombia = await _context.Colombia.FirstOrDefaultAsync(x => x.Id == id);
            if (colombia is null)
            {
                return NotFound();
            }

            return Ok(colombia);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Colombia colombia)
        {
            _context.Update(colombia);
            await _context.SaveChangesAsync();
            return Ok(colombia);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await _context.Colombia
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (afectedRows == 0)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}
