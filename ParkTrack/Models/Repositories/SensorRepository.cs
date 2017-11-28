using Microsoft.EntityFrameworkCore;
using ParkTrack.Data;
using ParkTrack.Models.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkTrack.Models.Repositories
{
    public class SensorRepository : ISensorRepository
    {
        // Context
        private readonly SensorContext context;


        // Constructor
        public SensorRepository(SensorContext context)
        {
            this.context = context;
        }

        /////////////////////////////////// 
        /////        Methods          /////
        ///////////////////////////////////
        // Add new sensor
        public async Task<bool> AddNewSensor(string token, Sensor sensor)
        {
            try
            {
                if (token == "c55add77fa7f6c27f7c5fa819b4752af1fc5af9cdb103452e")
                {
                    sensor.Token = TokenGenerator.generateToken();
                    await context.Sensors.AddAsync(sensor);
                    await context.SaveChangesAsync();
                    return true;
                } else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }


        // Get all sensors
        public async Task<IEnumerable<Sensor>> GetAllSensors(string token)
        {
            try
            {
                if (token == "c55add77fa7f6c27f7c5fa819b4752af1fc5af9cdb103452e")
                {
                    return await context.Sensors.ToListAsync();
                } 
                else
                {
                    return null;
                }                
            }
            catch 
            {
                // Logger functions
                return null;
            }
        }

        // Get sensor by ID
        public async Task<Sensor> GetSensorById(int id, string token)
        {
            try
            {
                return await context.Sensors
                    .SingleOrDefaultAsync(p => p.SensorID == id && p.Token == token);
            }
            catch 
            {
                // Logger functions
                return null;
            }
        }

        // Edit sensor by ID
        public async Task<bool> EditSensorById(int id, string token, Sensor sensorToEdit)
        {
            try
            {
                if (token == "c55add77fa7f6c27f7c5fa819b4752af1fc5af9cdb103452e")
                {
                    var sensor = await context.Sensors.SingleOrDefaultAsync(s => s.SensorID == id);

                    if (sensor != null)
                    {
                        sensor.longitude = sensorToEdit.longitude;
                        sensor.latitude = sensorToEdit.latitude;
                        context.Sensors.Update(sensor);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                } else
                {
                    return false;
                }
                    
            }
            catch
            {
                return false;
            }
        }

        // Delete sensor by ID
        public async Task<bool> DeleteSensorById(int id, string token)
        {
            try
            {
                if (token == "c55add77fa7f6c27f7c5fa819b4752af1fc5af9cdb103452e")
                {
                    var sensor = await context.Sensors.FirstOrDefaultAsync(s => s.SensorID == id);
                    if (sensor != null)
                    {
                        context.Sensors.Remove(sensor);
                        await context.SaveChangesAsync();
                        return true;
                    }

                    return false;
                } else
                {
                    return false;
                }
                    
            }
            catch
            {
                return false;
            }
        }
    }
}
