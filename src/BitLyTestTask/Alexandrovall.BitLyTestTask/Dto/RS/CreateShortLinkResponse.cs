using Alexandrovall.BitLyTestTask.Dto.RS.Common;

namespace Alexandrovall.BitLyTestTask.Dto.RS
{
    /// <summary>
    /// Ответ с сокращённой ссылкой
    /// </summary>
    public class CreateShortLinkResponse : Response<string>
    {
        public CreateShortLinkResponse(string data) : base(data)
        {

        }
    }
}