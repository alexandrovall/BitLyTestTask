using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alexandrovall.BitLyTestTask.DataAccess.MongoDb.Models;
using Alexandrovall.BitLyTestTask.MediatR.Contracts;
using Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests;
using AutoMapper;
using MediatR;
using MongoDB.Driver;

namespace Alexandrovall.BitLyTestTask.BL.MediatR.RequestHandlers
{
    public class GetShortLinkListRequestHandler : IRequestHandler<GetShortLinkListRequest, IReadOnlyCollection<ShortLink>>
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMapper _mapper;

        public GetShortLinkListRequestHandler(IMongoDatabase mongoDatabase, IMapper mapper)
        {
            _mongoDatabase = mongoDatabase;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<ShortLink>> Handle(GetShortLinkListRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var sort = Builders<Link>.Sort.Descending(l => l.CreationDate);
            var filter = Builders<Link>.Filter.Eq(l => l.UserId, request.UserId);
            var linkCollection = _mongoDatabase.GetCollection<Link>(MongoCollections.Links);

            var links = await linkCollection
                .Find(filter)
                .Sort(sort)
                .Skip(request.Offset)
                .Limit(request.Limit)
                .ToListAsync(cancellationToken);

            return (links?.Select(l => _mapper.Map<ShortLink>(l)) ?? Enumerable.Empty<ShortLink>()).ToList();
        }
    }
}