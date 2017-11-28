using Microsoft.AspNetCore.Mvc;
using ParkTrack.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using ParkTrack.Models;
using ParkTrack.Models.Repositories;

namespace ParkTrack.Controllers
{
    [Produces("application/json")]
    [Route("api/Sensors")]
    public class SensorsController : Controller
    {
        private readonly ISensorRepository sensors;

        public SensorsController(ISensorRepository sensorsRepository)
        {
            this.sensors = sensorsRepository;
        }

        ///////////////////////////////
        ///  GET: api/Sensors  ////////
        ///////////////////////////////
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok("Please provide admin token to access the sensor data");
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }

        //////////////////////////////////////////
        ///  GET: api/Sensors/admintoken  ////////
        ////////////////////////////////////////// 
        [HttpGet("{token}", Name = "GetById/{token}")]
        public async Task<IActionResult> GetAll(string token)
        {
            try
            {
                var result = await sensors.GetAllSensors(token);

                if (result == null) return NotFound("No sensors found");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }

        }

        ///////////////////////////////// 
        ///     GET: api/Sensors/5  /////
        /////////////////////////////////
        [HttpGet("{id:int}/{token}", Name = "GetById/{id:int}/{token}")]
        public async Task<IActionResult> GetById(int id, string token)
        {
            try
            {

                var result = await sensors.GetSensorById(id, token);

                if (result == null)
                {
                    return NotFound("Sensor with ID: " + id + " not found");                    
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        ///////////////////////////////// 
        ///     POST: api/Sensors   /////
        /// /////////////////////////////
        [HttpPost("{token}"), ActionName("AddNewSensor")]
        public async Task<IActionResult> AddNewSensor(string token, [FromBody] Sensor sensor)
        {
            try
            {
                // check if form was filled in correctly
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var sensorAdded = await sensors.AddNewSensor(token, sensor);
                if (sensorAdded) return Ok("New sensor has been successfully added");
                return BadRequest("There was an error while creating a new sensor. Please try again later");

                //return Ok("New sensor has been added to the database");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        ///////////////////////////////// 
        ///    PUT: api/Sensors/1   /////
        /////////////////////////////////
        [HttpPut("{id}/{token}"), ActionName("EditSensorById")]
        public async Task<IActionResult> EditSensorById(int id, string token, [FromBody] Sensor sensor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await sensors.EditSensorById(id, token, sensor);

                if (result) return Ok("Sensor with ID: " + id + " has been successfully updated");


                return NotFound("Sensor with ID: " + id + " not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        ///////////////////////////////// 
        ///  DELETE: api/Sensors/5  /////
        /////////////////////////////////
        [HttpDelete("{id}/{token}")]
        public async Task<IActionResult> DeleteSensorById(int id, string token)
        {
            try
            {
                var result = await sensors.DeleteSensorById(id, token);

                if (result) return Ok("Sensor with ID: " + id + " has been successfully deleted");

                return NotFound("Sensor with ID: " + id + " not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
