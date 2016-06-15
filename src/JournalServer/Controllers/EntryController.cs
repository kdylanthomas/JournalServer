using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using JournalServer.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JournalServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class EntryController : Controller
    {
        private JournalContext _context;

        public EntryController(JournalContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery]int? UserId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // select all entries from db
            IQueryable<Entry> entry = from e in _context.JournalEntry
                                      select e;

            // if a user ID is passed as param, return only their entries
            if (UserId != null)
            {
                entry = entry.Where(e => e.UserId == UserId);
            }

            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        // GET api/values/5
        [HttpGet("{id}", Name="GetEntry")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Entry entry = _context.JournalEntry.Single(e => e.EntryId == id);

            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.JournalEntry.Add(entry);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EntryExists(entry.EntryId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetEntry", new { id = entry.EntryId }, entry);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entry.EntryId)
            {
                return BadRequest();
            }

            _context.Entry(entry).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return new StatusCodeResult(StatusCodes.Status204NoContent);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Entry entry = _context.JournalEntry.Single(e => e.EntryId == id);
            if (entry == null)
            {
                return NotFound();
            }

            _context.JournalEntry.Remove(entry);
            _context.SaveChanges();

            return Ok(entry);
        }

        private bool EntryExists(int id)
        {
            return _context.JournalEntry.Count(e => e.EntryId == id) > 0;
        }
    }
}
