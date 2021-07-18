using AutoMapper;

namespace Alexandrovall.BitLyTestTask.Mapping.Profiles
{
    public class MediatrToDtoProfile : Profile
    {
        public MediatrToDtoProfile()
        {
            CreateMap<MediatR.Contracts.ShortLink, Dto.ShortLink>();
        }
    }
}