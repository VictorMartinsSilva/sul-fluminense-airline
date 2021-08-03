using AutoMapper;
using SFA.Business.Models;
using SFA.Site.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFA.Site.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Address, AddressViewModels>().ReverseMap();
            CreateMap<Passenger, PassengerViewModels>().ReverseMap();
            CreateMap<Seat, SeatViewModels>().ReverseMap();
            CreateMap<Scheduling, SchedulingViewModels>().ReverseMap();
            CreateMap<Flight, FlightViewModels>().ReverseMap();
            CreateMap<Airplane, AirplaneViewModels>().ReverseMap();
            CreateMap<Company, CompanyViewModels>().ReverseMap();
        }
    }
}
