using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Students.Controllers
{
    [Route("api/[controller]")]
    public class OwnersController : Controller
    {
        // GET: api/owners
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]string identification)
        {
            using(DbStudentsContext db = new DbStudentsContext())
            {
                return Ok(await db.Owners
                          .Where(i => string.IsNullOrEmpty(identification) || i.Identification.Equals(identification))
                          .Include(i => i.Penalties)
                          .Include(i => i.Vehicles)
                          .ToListAsync());
            }
        }

        // GET api/owners/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using (DbStudentsContext db = new DbStudentsContext())
            {
                var owner = await db.Owners.FindAsync(id);
                return Ok(owner);

            }
        }


        // POST api/owners
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Owner data)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            using (DbStudentsContext db = new DbStudentsContext())
            {
                var result = await db.AddAsync(data);
                await db.SaveChangesAsync();

                var path = new Uri(HttpContext.Request.Path);
                return Created(path, data.Id);
            }
        }
        /*
        // PUT api/owners/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/owners/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
