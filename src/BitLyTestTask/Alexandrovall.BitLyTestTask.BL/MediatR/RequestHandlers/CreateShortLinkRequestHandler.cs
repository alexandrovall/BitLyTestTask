using System;
using System.Threading;
using System.Threading.Tasks;
using Alexandrovall.BitLyTestTask.DataAccess.MongoDb.Models;
using Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests;
using AutoMapper;
using MediatR;
using MongoDB.Driver;

namespace Alexandrovall.BitLyTestTask.BL.MediatR.RequestHandlers
{
    public class CreateShortLinkRequestHandler : IRequestHandler<CreateShortLinkRequest, string>
    {
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMapper _mapper;

        public CreateShortLinkRequestHandler(IMongoDatabase mongoDatabase, IMapper mapper)
        {
            _mongoDatabase = mongoDatabase;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateShortLinkRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var link = _mapper.Map<Link>(request);
            var linkCollection = _mongoDatabase.GetCollection<Link>(MongoCollections.Links);

            await linkCollection.InsertOneAsync(link, cancellationToken: cancellationToken);

            return link.Id;
        }
    }
}