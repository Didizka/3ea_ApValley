using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkTrack.Models.Repositories
{
    public interface ISensorRepository
    {
        Task<IEnumerable<Sensor>> GetAllSensors(string token);
        Task<Sensor> GetSensorById(int id, string token);
        Task<bool> AddNewSensor(string token, Sensor sensor);
        Task<bool> EditSensorById(int id, string token, Sensor sensor);
        Task<bool> DeleteSensorById(int id, string token);
    }
}