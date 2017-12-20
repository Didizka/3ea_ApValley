using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkTrack.Models.Resources
{
    public class SensorResource
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string Token { get; set; }
    }
}
