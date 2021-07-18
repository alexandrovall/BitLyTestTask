using AutoMapper;

namespace Alexandrovall.BitLyTestTask.Mapping.Profiles
{
    public class DtoToMediatrProfile : Profile
    {
        public DtoToMediatrProfile()
        {
            CreateMap<Dto.ShortLink, MediatR.Contracts.ShortLink>();
            CreateMap<Dto.RQ.CreateShortLinkRequest, MediatR.Contracts.Requests.CreateShortLinkRequest>();
            CreateMap<Dto.RQ.GetShortLinkListRequest, MediatR.Contracts.Requests.GetShortLinkListRequest>();
        }
    }
}