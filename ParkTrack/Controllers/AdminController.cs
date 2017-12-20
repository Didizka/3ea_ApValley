using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ParkTrack.Models.Repositories;
using ParkTrack.Models;

namespace ParkTrack.Controllers
{
    [Produces("application/json")]
    [Route("api/Admin")]
    public class AdminController : Controller
    {
        private readonly ISensorRepository sensors;

        public AdminController(ISensorRepository sensorsRepository)
        {
            this.sensors = sensorsRepository;
        }

        //////////////////////////////////////////
        ///    GET: api/admin/admintoken  ////////
        ////////////////////////////////////////// 
        [HttpGet("{token}", Name = "GetAllSensors/{token}")]
        public async Task<IActionResult> GetAllSensors(string token)
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
        ///     POST: api/admin     /////
        /// /////////////////////////////
        [HttpPost("{token}"), ActionName("AddNewSensor")]
        public async Task<IActionResult> AddNewSensorOrEditEnExistingSensor(string token, [FromBody] Sensor sensor)
        {
            try
            {
                // check if form was filled in correctly
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //try to get the sensor from the database
                var foundSensor = await sensors.GetSensorBySerialNumber(sensor.SerialNumber);

                //if the sensor with given serial number exists, update its coordinates and refresh the token
                if (foundSensor != null)
                {
                    var isSensorTokenStillValid = sensors.IsSensorTokenStillValid(foundSensor.Token).Result;

                    if (isSensorTokenStillValid == true)
                    {
                        var result = await sensors.EditSensorBySerialNumber(sensor.SerialNumber, token, sensor);
                        if (result == true) return Ok($"Sensor with serial number {sensor.SerialNumber} has successfully been updated");
                        return NotFound($"Sensor with serial number { sensor.SerialNumber} could not be found");
                    } else
                    {                        
                        var result = await sensors.DeleteSensorBySerialNumber(sensor.SerialNumber, token);
                        var isSensorRecreated = await sensors.AddNewSensor(token, sensor);
                        if (result == true && isSensorRecreated == true) return Ok($"Sensor with serial number {sensor.SerialNumber} has successfully been updated and its token has been refreshed");
                        return NotFound($"Sensor with serial number { sensor.SerialNumber} could not be updated");
                    }
                    


                } else
                //if the sensor with given serial number doesnt exists, create a new sensor
                {
                    var sensorAdded = await sensors.AddNewSensor(token, sensor);
                    if (sensorAdded) return Ok("New sensor has been successfully added");
                    return BadRequest("There was an error while creating a new sensor. Please try again later");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        //////////////////////////////////////////
        ///    PUT: api/admin/serial/token   /////
        //////////////////////////////////////////
        [HttpPut("{serialNumber}/{token}"), ActionName("EditSensorBySerialNumber")]
        public async Task<IActionResult> EditSensorBySerialNumber(string serialNumber, string token, [FromBody] Sensor sensor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await sensors.EditSensorBySerialNumber(serialNumber, token, sensor);

                if (result) return Ok("Sensor with serial number: " + serialNumber + " has been successfully updated");


                return NotFound("Sensor with serial number: " + serialNumber + " not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        ////////////////////////////////////////// 
        ///  DELETE: api/admin/serial/token  /////
        //////////////////////////////////////////
        [HttpDelete("{serialNumber}/{token}")]
        public async Task<IActionResult> DeleteSensorBySerialNumber(string serialNumber, string token)
        {
            try
            {
                var result = await sensors.DeleteSensorBySerialNumber(serialNumber, token);

                if (result) return Ok("Sensor with serial number: " + serialNumber + " has been successfully deleted");

                return NotFound("Sensor with serial number: " + serialNumber + " not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
