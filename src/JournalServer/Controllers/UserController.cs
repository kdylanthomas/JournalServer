﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using JournalServer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Entity;

namespace JournalServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [EnableCors("AllowDevelopmentEnvironment")]
    public class UserController : Controller
    {
        private JournalContext _context;

        public UserController(JournalContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get([FromQuery] string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IQueryable<User> users = from user in _context.User
                                       select new User
                                       {
                                           UserId = user.UserId,
                                           Username = user.Username,
                                           FirstName = user.FirstName,
                                           LastName = user.LastName,
                                           DateRegistered = user.DateRegistered,
                                           Entries = "Entry?UserId=" + user.UserId,
                                           EntryAnalyses = "EntryAnalysis?UserId=" + user.UserId
                                       };

            if (username != null) {
                users = users.Where(u => u.Username == username);
            }

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           User user = _context.User.Single(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = from u in _context.User
                               where u.Username == user.Username
                               select u;

            if (existingUser.Count<User>() > 0)
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            };

            _context.User.Add(user);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Username))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("GetUser", new { id = user.UserId }, user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Username))
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

            User user = _context.User.Single(u => u.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            _context.SaveChanges();

            return Ok(user);
        }

        private bool UserExists(string username)
        {
            return _context.User.Count(u => u.Username == username) > 0;
        }
    }
}
