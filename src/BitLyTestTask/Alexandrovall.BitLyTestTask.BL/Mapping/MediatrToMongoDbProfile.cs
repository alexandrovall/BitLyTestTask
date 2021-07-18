using System;
using Alexandrovall.BitLyTestTask.DataAccess.MongoDb.Models;
using Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests;
using AutoMapper;

namespace Alexandrovall.BitLyTestTask.BL.Mapping
{
    public class MediatrToMongoDbProfile : Profile
    {
        public MediatrToMongoDbProfile()
        {
            CreateMap<CreateShortLinkRequest, Link>()
                .ForMember(d => d.Id, opts => opts.Ignore())
                .ForMember(d => d.TransitionCount, opts => opts.Ignore())
                .ForMember(d => d.OriginalLink, opts => opts.MapFrom(s => s.Link))
                .ForMember(d => d.CreationDate, opts => opts.MapFrom(s => DateTime.UtcNow));
        }
    }
}