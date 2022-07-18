using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;
using System.Linq;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(destination => destination.PhotoUrl,
                            options => options.MapFrom(source => source.Photos.FirstOrDefault(x => x.IsMain).Url)) //I am mapping profile picture from phtodto object
                .ForMember(destination => destination.Age,
                            options => options.MapFrom(source => source.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
        }
    }
}
