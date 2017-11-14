using Microsoft.CodeAnalysis;
using ParkTrack.Models;
using System.Collections.Generic;
using System.Linq;

namespace ParkTrack.Data
{
    public class SensorDbInitializer
    {
        public static void Initialize(SensorContext context)
        {
            context.Database.EnsureCreated();

            if (context.Sensors.Any())
            {
                return;
            }

            var sensors = new List<Sensor>
            {
                new Sensor {latitude = (float) (51.2301299), longitude = (float) ( 4.4161723) },
                new Sensor {latitude = (float) (51.2469382), longitude =  (float) (4.45203781) },
                new Sensor {latitude = (float) (51.25596345), longitude =  (float) (4.42354202) },
                new Sensor {latitude = (float) (51.22931236), longitude =  (float) (4.50971604) },
                new Sensor {latitude = (float) (51.20221559), longitude =  (float) (4.5227623) },
                new Sensor {latitude = (float) (51.19597678), longitude =  (float) (4.48516846) },
                new Sensor {latitude = (float) (51.19092056), longitude =  (float) (4.45014954) },
                new Sensor {latitude = (float) (51.19565406), longitude =  (float) (4.41839218) },
                new Sensor {latitude = (float) (51.22178708), longitude =  (float) (4.46165085) }
            };

            foreach (var sensor in sensors)
            {
                context.Sensors.Add(sensor);
            }

            context.SaveChanges();
        }
            
    }
}
