using Microsoft.AspNetCore.Mvc;
using ParkTrack.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using ParkTrack.Models;

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

        //////////////////////////////////// 
        ///     GET: api/Sensors    ////////
        //////////////////////////////////// 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var sensors = await context.Sensors.ToListAsync();

                if (sensors.Count > 0) return Ok(sensors);
                return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }

        ///////////////////////////////// 
        ///     GET: api/Sensors/5  /////
        /////////////////////////////////
        [HttpGet("{id}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {

                var sensor = await context.Sensors.FirstOrDefaultAsync(s => s.SensorID == id);

                if (sensor != null)
                {
                    return Ok(sensor);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        ///////////////////////////////// 
        ///     POST: api/Sensors   /////
        /// /////////////////////////////
        [HttpPost, ActionName("AddNewSensor")]
        public async Task<IActionResult> AddNewSensor([FromBody] Sensor sensor)
        {
            try
            {
                // check if form was filled in correctly
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                await context.Sensors.AddAsync(sensor);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        ///////////////////////////////// 
        ///    PUT: api/Sensors/1   /////
        /////////////////////////////////
        [HttpPut("{id}"), ActionName("EditSensorById")]
        public async Task<IActionResult> EditSensorById(int id, [FromBody] Sensor sensor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var sensorToEdit = await context.Sensors.FirstOrDefaultAsync(s => s.SensorID == id);


                if (sensorToEdit != null)
                {
                    sensorToEdit.longitude = sensor.longitude;
                    sensorToEdit.latitude = sensor.latitude;
                    context.Sensors.Update(sensorToEdit);
                    await context.SaveChangesAsync();
                    return Ok();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        ///////////////////////////////// 
        ///  DELETE: api/Sensors/5  /////
        /////////////////////////////////
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensorById(int id)
        {
            try
            {
                var sensor = await context.Sensors.FirstOrDefaultAsync(s => s.SensorID == id);

                if (sensor != null)
                {
                    context.Sensors.Remove(sensor);
                    await context.SaveChangesAsync();
                    return Ok();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
