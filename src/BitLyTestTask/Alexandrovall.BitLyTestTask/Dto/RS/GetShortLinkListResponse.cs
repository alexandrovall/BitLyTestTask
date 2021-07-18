using System.Collections.Generic;
using Alexandrovall.BitLyTestTask.Dto.RS.Common;

namespace Alexandrovall.BitLyTestTask.Dto.RS
{
    /// <summary>
    /// Ответ со списком сокращённых ссылок
    /// </summary>
    public class GetShortLinkListResponse : PagingResponse<ShortLink>
    {
        public GetShortLinkListResponse(IReadOnlyCollection<ShortLink> data) : base(data)
        {
            
        }
    }
}