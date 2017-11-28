using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkTrack.Models
{
    [Table("Sensors")]
    public class Sensor
    {
        public int SensorID { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        
        [StringLength(64)]
        public string Token { get; set; }



    }
}
