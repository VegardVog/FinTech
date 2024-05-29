namespace FinTech.Mappers
{
    using AutoMapper;
    using FinTech.Models;
    using FinTech.Models.DTOs;

    public class MappingProfile : Profile
    {

        public MappingProfile() {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
