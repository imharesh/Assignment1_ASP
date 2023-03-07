using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_1.Data;
using Assignment_1.Models;

namespace Assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueKeysController : ControllerBase
    {
        private readonly Assignment_1Context _context;

        public ValueKeysController(Assignment_1Context context)
        {
            _context = context;
        }

        // GET: api/ValueKeys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValueKey>>> GetValueKey()
        {
            return await _context.ValueKey.ToListAsync();
        }

        // GET: api/ValueKeys/5
        [HttpGet("{key}")]
        public async Task<ActionResult<ValueKey>> GetValueKey(string key)
        {
            var valueKey = await _context.ValueKey.FindAsync(key);

            if (valueKey == null)
            {
                return NotFound();
            }

            return valueKey;
        }

        // PUT: api/ValueKeys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{key}")]
        public async Task<IActionResult> PutValueKey(string key, ValueKey valueKey)
        {
            if (key == valueKey.Key)
            {
                return Conflict();
            }

            _context.Entry(valueKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValueKeyExists(key))
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
        [HttpPatch("{key}/{value}")]
        public async Task<IActionResult> PatchValueKey(string key, ValueKey valueKey)
        {
            if (key != valueKey.Key)
            {
                return BadRequest();
            }

            _context.Entry(valueKey).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ValueKeyExists(key))
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

        // POST: api/ValueKeys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ValueKey>> PostValueKey(ValueKey valueKey)
        {
            _context.ValueKey.Add(valueKey);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ValueKeyExists(valueKey.Key))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetValueKey", new { id = valueKey.Key }, valueKey);
        }

        // DELETE: api/ValueKeys/5
        [HttpDelete("{key}")]
        public async Task<IActionResult> DeleteValueKey(string key)
        {
            var valueKey = await _context.ValueKey.FindAsync(key);
            if (valueKey == null)
            {
                return NotFound();
            }

            _context.ValueKey.Remove(valueKey);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ValueKeyExists(string id)
        {
            return _context.ValueKey.Any(e => e.Key == id);
        }
    }
}
