using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ParkTrack.Data;
using ParkTrack.Models.HelperClasses;
using ParkTrack.Models.Resources;
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
        private readonly IMapper mapper;


        // Constructor
        public SensorRepository(SensorContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /////////////////////////////////// 
        /////   Public Methods        /////
        ///////////////////////////////////
        // Get sensor by Token
        public async Task<SensorResource> GetSensorByToken(string token)
        {
            try
            {
                //try to find the sensor
                var sensor = await context.Sensors
                    .SingleOrDefaultAsync(p => p.Token == token);

                //if the sensor exists, check if its token is still valid
                if (sensor != null)
                {
                    var result = mapper.Map<Sensor, SensorResource>(sensor);
                    return result;
                }
                return null;
            }
            catch
            {
                // Logger functions
                return null;
            }
        }

        public async Task<bool> IsSensorTokenStillValid(string token)
        {
            double maxTimeTokenValidInMinutes = 720;
            var sensor = await context.Sensors.SingleOrDefaultAsync(p => p.Token == token);

            TimeSpan span = DateTime.Now.Subtract(sensor.TokenAddedAt);
            return span.TotalMinutes <= maxTimeTokenValidInMinutes;
        }



        /////////////////////////////////// 
        /////   Admin Methods         /////
        ///////////////////////////////////
        // Get sensor by SerialNumber
        public async Task<Sensor> GetSensorBySerialNumber(string serialNumber)
        {
            try
            {
                var sensor = await context.Sensors
                    .SingleOrDefaultAsync(p => p.SerialNumber == serialNumber);
                return sensor;
            }
            catch
            {
                // Logger functions
                return null;
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

        // Add new sensor
        public async Task<bool> AddNewSensor(string token, Sensor sensor)
        {
            try
            {
                if (token == "c55add77fa7f6c27f7c5fa819b4752af1fc5af9cdb103452e")
                {
                    sensor.Token = TokenGenerator.generateToken();
                    sensor.TokenAddedAt = DateTime.Now;
                    await context.Sensors.AddAsync(sensor);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        // Edit sensor by Serial Number
        public async Task<bool> EditSensorBySerialNumber(string serialNumber, string token, Sensor sensorToEdit)
        {
            try
            {
                if (token == "c55add77fa7f6c27f7c5fa819b4752af1fc5af9cdb103452e")
                {
                    var sensor = await context.Sensors.SingleOrDefaultAsync(s => s.SerialNumber == serialNumber);

                    if (sensor != null)
                    {
                        sensor.longitude = sensorToEdit.longitude;
                        sensor.latitude = sensorToEdit.latitude;
                        if (sensorToEdit.TokenAddedAt == DateTime.MinValue)
                        {
                            sensor.TokenAddedAt = DateTime.Now;
                        }
                        else
                        {
                            sensor.TokenAddedAt = sensorToEdit.TokenAddedAt;
                        }
                        context.Sensors.Update(sensor);
                        await context.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        // Delete sensor by Serial Number
        public async Task<bool> DeleteSensorBySerialNumber(string serialNumber, string token)
        {
            try
            {
                if (token == "c55add77fa7f6c27f7c5fa819b4752af1fc5af9cdb103452e")
                {
                    var sensor = await context.Sensors.FirstOrDefaultAsync(s => s.SerialNumber == serialNumber);
                    if (sensor != null)
                    {
                        context.Sensors.Remove(sensor);
                        await context.SaveChangesAsync();
                        return true;
                    }

                    return false;
                }
                else
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

            
    