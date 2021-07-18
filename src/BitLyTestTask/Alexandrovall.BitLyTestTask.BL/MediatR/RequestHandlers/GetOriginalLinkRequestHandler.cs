using System.Threading;
using System.Threading.Tasks;
using Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests;
using MediatR;

namespace Alexandrovall.BitLyTestTask.BL.MediatR.RequestHandlers
{
    public class GetOriginalLinkRequestHandler : IRequestHandler<GetOriginalLinkRequest, string>
    {
        public Task<string> Handle(GetOriginalLinkRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}