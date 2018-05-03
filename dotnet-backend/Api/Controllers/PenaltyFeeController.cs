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
    public class PenaltyFeeController : Controller
    {
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (DbStudentsContext db = new DbStudentsContext())
            {
                return Ok(await db.PenaltyFees
                          .Include(i => i.Owner)
                          .Include(i => i.Vehicle)
                          .ToListAsync());
            }
        }

      
        // POST api/PenaltyFee
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PenaltyFee data)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            using (DbStudentsContext db = new DbStudentsContext())
            {
                data.State = true;

                var result = await db.AddAsync(data);
                await db.SaveChangesAsync();

                var path = new Uri(HttpContext.Request.Path);
                return Created(path, data.Id);
            }
        }


        // GET: api/vehicle
        [HttpGet]
        [Route("{id}/paid")]
        public async Task<IActionResult> PayPenalty(int id)
        {
            using (DbStudentsContext db = new DbStudentsContext())
            {

                var penalty = await db.PenaltyFees.FindAsync(id);
                penalty.State = false;

                db.Update(penalty);

                await db.SaveChangesAsync();
                return Ok(); 
            }
        }
        /*
        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
