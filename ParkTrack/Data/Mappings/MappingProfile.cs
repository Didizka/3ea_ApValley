using AutoMapper;
using ParkTrack.Models;
using ParkTrack.Models.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkTrack.Data.Mappings
{
    public class MappingProfile : Profile
    {
       public MappingProfile()
        {
            CreateMap<Sensor, SensorResource>();
        }
    }
}
