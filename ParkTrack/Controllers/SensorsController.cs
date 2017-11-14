using Microsoft.AspNetCore.Mvc;
using ParkTrack.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace ParkTrack.Controllers
{
    [Produces("application/json")]
    [Route("api/Sensors")]
    public class SensorsController : Controller
    {
        private readonly SensorContext context;

        public SensorsController(SensorContext _context)
        {
            context = _context;
        }

        // GET: api/Sensors
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var sensors = await context.Sensors.ToListAsync();

                return Ok(sensors);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }

        // GET: api/Sensors/5
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var sensor = await context.Sensors.FirstOrDefaultAsync(s => s.SensorID == id);

                return Ok(sensor);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        
        // POST: api/Sensors
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Sensors/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
