using AutoMapper;
using DatingApp_Server.DTOs;
using DatingApp_Server.Entities;

namespace DatingApp_Server.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl,
                opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url));
            //.ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<PhotoDto, Photo>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<AppUser, MemberUpdateDto>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, RegisterDto>();
            CreateMap<Message, MessageDto>()
                .ForMember(d => d.SenderPhotoUrl, o => o.MapFrom(s => s.Sender.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(d => d.RecipientPhotoUrl, o => o.MapFrom(s => s.Recipient.Photos.FirstOrDefault(x => x.IsMain).Url));
        }
    }
}
