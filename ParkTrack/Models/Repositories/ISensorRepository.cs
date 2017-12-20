using ParkTrack.Models.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkTrack.Models.Repositories
{
    public interface ISensorRepository
    {
        // Public, for customers
        Task<SensorResource> GetSensorByToken(string token);
        Task<bool> IsSensorTokenStillValid(string sensor);

        // Admin
        Task<IEnumerable<Sensor>> GetAllSensors(string token);
        Task<Sensor> GetSensorBySerialNumber(string serialNumber);
        Task<bool> AddNewSensor(string token, Sensor sensor);
        Task<bool> EditSensorBySerialNumber(string serialNumber, string token, Sensor sensor);
        Task<bool> DeleteSensorBySerialNumber(string serialNumber, string token);
    }
}