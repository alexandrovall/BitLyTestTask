using Alexandrovall.BitLyTestTask.Dto.RS.Common;

namespace Alexandrovall.BitLyTestTask.Dto.RS
{
    /// <summary>
    /// Ответ с сокращённой ссылкой
    /// </summary>
    public class GetShortLinkResponse : Response
    {
        /// <summary>
        /// Сокращённая ссылка
        /// </summary>
        public string ShortLink { get; init; }
    }
}