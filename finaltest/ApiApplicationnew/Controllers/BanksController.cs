using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiApplicationnew.Data;
using ApiApplicationnew.Models;

namespace ApiApplicationnew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly ContextClass _context;

        public BanksController(ContextClass context)
        {
            _context = context;
        }

        // GET: api/Banks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banks>>> Getbanks()
        {
            return await _context.banks.ToListAsync();
        }

        // GET: api/Banks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Banks>> GetBanks(int id)
        {
            var banks = await _context.banks.FindAsync(id);

            if (banks == null)
            {
                return NotFound();
            }

            return banks;
        }

        // PUT: api/Banks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBanks(int id, Banks banks)
        {
            if (id != banks.BankId)
            {
                return BadRequest();
            }

            _context.Entry(banks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Banks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Banks>> PostBanks(Banks banks)
        {
            _context.banks.Add(banks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBanks", new { id = banks.BankId }, banks);
        }

        // DELETE: api/Banks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Banks>> DeleteBanks(int id)
        {
            var banks = await _context.banks.FindAsync(id);
            if (banks == null)
            {
                return NotFound();
            }

            _context.banks.Remove(banks);
            await _context.SaveChangesAsync();

            return banks;
        }

        private bool BanksExists(int id)
        {
            return _context.banks.Any(e => e.BankId == id);
        }
    }
}
