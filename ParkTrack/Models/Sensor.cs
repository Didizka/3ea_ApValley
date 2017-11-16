using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParkTrack.Models
{
    [Table("Sensors")]
    public class Sensor
    {
        public int SensorID { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
    }
}
