using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkTrack.Models
{
    [Table("Sensors")]
    public class Sensor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(15)]
        public string SerialNumber { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        
        [StringLength(32)]
        public string Token { get; set; }
        public DateTime TokenAddedAt { get; set; }
    }
}
