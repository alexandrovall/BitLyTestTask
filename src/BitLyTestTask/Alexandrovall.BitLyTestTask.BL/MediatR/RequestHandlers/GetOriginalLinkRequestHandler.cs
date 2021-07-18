using System;
using System.Threading;
using System.Threading.Tasks;
using Alexandrovall.BitLyTestTask.DataAccess.MongoDb.Models;
using Alexandrovall.BitLyTestTask.Exceptions;
using Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests;
using MediatR;
using MongoDB.Driver;

namespace Alexandrovall.BitLyTestTask.BL.MediatR.RequestHandlers
{
    public class GetOriginalLinkRequestHandler : IRequestHandler<GetOriginalLinkRequest, string>
    {
        private readonly IMongoDatabase _mongoDatabase;

        public GetOriginalLinkRequestHandler(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task<string> Handle(GetOriginalLinkRequest request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var filter = Builders<Link>.Filter.Eq(l => l.Id, request.LinkId);
            var update = Builders<Link>.Update.Inc(l => l.TransitionCount, 1);
            var linkCollection = _mongoDatabase.GetCollection<Link>(MongoCollections.Links);

            var link = await linkCollection.FindOneAndUpdateAsync(filter, update, cancellationToken: cancellationToken);

            if (link is null)
            {
                throw new CollectionItemNotFoundException(MongoCollections.Links, request.LinkId);
            }

            return link.OriginalLink;
        }
    }
}