using AutoMapper;
using WebApplication4.DTO;

namespace WebApplication4
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Apartment, ApartmentDTO>();
            CreateMap<House, HouseDTO>();
            CreateMap<Resident, ResidentDTO>();

            CreateMap<ApartmentDTO, Apartment>();
            CreateMap<HouseDTO, House>();
            CreateMap<ResidentDTO, Resident>();
        }
    }
}

