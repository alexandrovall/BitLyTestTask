using System.Collections.Generic;
using Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests.Common;
using MediatR;

namespace Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests
{
    /// <summary>
    /// Запрос на получение списка ссылок пользователя
    /// </summary>
    public class GetShortLinkListRequest : PagingRequest, IRequest<IReadOnlyCollection<ShortLink>>
    {
        
    }
}