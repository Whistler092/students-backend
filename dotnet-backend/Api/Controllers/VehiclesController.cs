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
    public class VehiclesController : Controller
    {
        // GET: api/vehicle
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (DbStudentsContext db = new DbStudentsContext())
            {
                return Ok(await db.Vehicles.ToListAsync());
            }
        }

        // GET: api/vehicle
        [HttpGet]
        [Route("{id}/owner")]
        public async Task<IActionResult> GetByUser(int id)
        {
            using (DbStudentsContext db = new DbStudentsContext())
            {
                return Ok(await db.Vehicles.Where(i => i.IdOwner == id).ToListAsync());
            }
        }


        // GET api/vehicle/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            using (DbStudentsContext db = new DbStudentsContext())
            {
                var vehicle = await db.Vehicles.FindAsync(id);
                return Ok(vehicle);
            }
        }

        // POST api/vehicle
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Vehicle data)
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
    }
}
