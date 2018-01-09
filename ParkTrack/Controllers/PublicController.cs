using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using ParkTrack.Models.Repositories;

namespace ParkTrack.Controllers
{
    [Produces("application/json")]
    [Route("api/public")]
    public class PublicController : Controller
    {
        private readonly ISensorRepository sensors;

        public PublicController(ISensorRepository sensorsRepository)
        {
            this.sensors = sensorsRepository;
        }
        



        ///////////////////////////////// 
        /// GET: api/public/token  /////
        /////////////////////////////////
        [HttpGet("{token}", Name = "GetSensorByToken/{token}")]
        public async Task<IActionResult> GetSensorByToken(string token)
        {
            try
            {

                var sensor = await sensors.GetSensorByToken(token);

                if (sensor == null)
                {
                    return NotFound("Sensor with token: " + token + " not found");                    
                }

                var isSensorTokenStillValid = sensors.IsSensorTokenStillValid(token).Result;

                if (isSensorTokenStillValid == true) return Ok(sensor);

                return NotFound("The sensor token has been expired, please ask the admin for a new token");

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }      
    }
}
