// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Students.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Students.Entities;

    [Route("api/[controller]")]
    public class PeoplesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using(DbStudentsContext db = new DbStudentsContext())
            {
                var peoples = await db.Peoples.ToListAsync();
                return Ok(peoples);
            }
            //return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using(DbStudentsContext db = new DbStudentsContext())
            {
                var people = await db.Peoples.FindAsync(id);
                return Ok(people);
                
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]People data)
        {
            if (!ModelState.IsValid)
               return BadRequest();

            using(DbStudentsContext db = new DbStudentsContext())
            {
                var result = await db.AddAsync(data);
                await db.SaveChangesAsync();

                //        msg.Headers.Location = new Uri(Request.RequestUri + newCust.ID.ToString());

                var path = new Uri(HttpContext.Request.Path);
                return Created(path,data.Id);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
