using Alexandrovall.BitLyTestTask.DataAccess.MongoDb.Models;
using Alexandrovall.BitLyTestTask.MediatR.Contracts;
using AutoMapper;

namespace Alexandrovall.BitLyTestTask.BL.Mapping
{
    public class MongoDbToMediatrProfile : Profile
    {
        public MongoDbToMediatrProfile()
        {
            CreateMap<Link, ShortLink>()
                .ForMember(d => d.Link, opts => opts.MapFrom(s => s.Id));
        }
    }
}