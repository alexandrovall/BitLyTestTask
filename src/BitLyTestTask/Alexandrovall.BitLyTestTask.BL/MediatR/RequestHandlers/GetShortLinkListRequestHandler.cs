using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Alexandrovall.BitLyTestTask.MediatR.Contracts;
using Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests;
using MediatR;

namespace Alexandrovall.BitLyTestTask.BL.MediatR.RequestHandlers
{
    public class GetShortLinkListRequestHandler : IRequestHandler<GetShortLinkListRequest, IReadOnlyCollection<ShortLink>>
    {
        public Task<IReadOnlyCollection<ShortLink>> Handle(GetShortLinkListRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}