using Microsoft.CodeAnalysis;
using ParkTrack.Models;
using ParkTrack.Models.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

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
                new Sensor {latitude = (float) (51.2301299), longitude = (float) ( 4.4161723), Token = TokenGenerator.generateToken() },
                new Sensor {latitude = (float) (51.2469382), longitude =  (float) (4.45203781), Token = TokenGenerator.generateToken() },
                new Sensor {latitude = (float) (51.25596345), longitude =  (float) (4.42354202), Token = TokenGenerator.generateToken() },
                new Sensor {latitude = (float) (51.22931236), longitude =  (float) (4.50971604), Token = TokenGenerator.generateToken() },
                new Sensor {latitude = (float) (51.20221559), longitude =  (float) (4.5227623), Token = TokenGenerator.generateToken() },
                new Sensor {latitude = (float) (51.19597678), longitude =  (float) (4.48516846), Token = TokenGenerator.generateToken() },
                new Sensor {latitude = (float) (51.19092056), longitude =  (float) (4.45014954), Token = TokenGenerator.generateToken() },
                new Sensor {latitude = (float) (51.19565406), longitude =  (float) (4.41839218), Token = TokenGenerator.generateToken() },
                new Sensor {latitude = (float) (51.22178708), longitude =  (float) (4.46165085), Token = TokenGenerator.generateToken() }
            };

            foreach (var sensor in sensors)
            {
                context.Sensors.Add(sensor);
            }

            context.SaveChanges();
        }



    }
}
