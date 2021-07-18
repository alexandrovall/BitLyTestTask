using System.Threading;
using System.Threading.Tasks;
using Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests;
using MediatR;

namespace Alexandrovall.BitLyTestTask.BL.MediatR.RequestHandlers
{
    public class CreateShortLinkRequestHandler : IRequestHandler<CreateShortLinkRequest, string>
    {
        public Task<string> Handle(CreateShortLinkRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}