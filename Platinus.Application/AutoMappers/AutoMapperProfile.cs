using AutoMapper;
using Platinus.Application.DTOs.Requests;
using Platinus.Application.DTOs.Response;
using Platinus.Domain.Entities;

namespace Platinus.Application.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<RequestUser, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<User, ResponseShortUser>();

        }
    }
}
