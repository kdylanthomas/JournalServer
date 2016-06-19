using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JournalServer.Models;
using Microsoft.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using JournalServer.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace JournalServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class EntryAnalysisController : Controller
    {
        private JournalContext _context;

        public EntryAnalysisController(JournalContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get([FromQuery]int? UserId, [FromQuery]int? EntryId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<EntryInsight> entryInsight = from ea in _context.EntryAnalysis
                                                      join e in _context.JournalEntry
                                                      on ea.EntryId equals e.EntryId
                                                      select new EntryInsight
                                                      {
                                                          EntryAnalysisId = ea.EntryAnalysisId,
                                                          UserId = ea.UserId,
                                                          EntryId = ea.EntryId,
                                                          Anger = ea.Anger,
                                                          Joy = ea.Joy,
                                                          Sadness = ea.Sadness,
                                                          Surprise = ea.Surprise,
                                                          Fear = ea.Fear,
                                                          Sentiment = ea.Sentiment,
                                                          DateStarted = e.DateStarted,
                                                          DateSubmitted = e.DateSubmitted,
                                                          WordCount = e.WordCount
                                                      };

            // if a user ID is passed as param, return only their analyses
            if (UserId != null)
            {
                entryInsight = entryInsight.Where(ea => ea.UserId == UserId);
            }

            // if an entry ID is passed as param, return only that entry's analyses
            if (EntryId != null)
            {
                entryInsight = entryInsight.Where(ea => ea.EntryId == EntryId);
            }
            if (entryInsight == null)
            {
                return NotFound();
            }

            return Ok(entryInsight);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetEntryAnalysis")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EntryAnalysis entryAnalysis = _context.EntryAnalysis.Single(e => e.EntryAnalysisId == id);

            if (entryAnalysis == null)
            {
                return NotFound();
            }

            return Ok(entryAnalysis);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]EntryAnalysis entryAnalysis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EntryAnalysis.Add(entryAnalysis);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EntryAnalysisExists(entryAnalysis.EntryAnalysisId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetEntryAnalysis", new { id = entryAnalysis.EntryAnalysisId }, entryAnalysis);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EntryAnalysis entryAnalysis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entryAnalysis.EntryId)
            {
                return BadRequest();
            }

            _context.Entry(entryAnalysis).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryAnalysisExists(id))
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

            EntryAnalysis entryAnalysis = _context.EntryAnalysis.Single(ea => ea.EntryAnalysisId == id);
            if (entryAnalysis == null)
            {
                return NotFound();
            }

            _context.EntryAnalysis.Remove(entryAnalysis);
            _context.SaveChanges();

            return Ok(entryAnalysis);
        }

        private bool EntryAnalysisExists(int id)
        {
            return _context.EntryAnalysis.Count(ea => ea.EntryAnalysisId == id) > 0;
        }
    }
}
