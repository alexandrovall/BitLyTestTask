using Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests.Common;
using MediatR;

namespace Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests
{
    /// <summary>
    /// Запрос на создание сокращённой ссылки
    /// </summary>
    public class CreateShortLinkRequest : UserRequest, IRequest<string>
    {
        /// <summary>
        /// Ссылка для сокращения
        /// </summary>
        public string Link { get; set; }
    }
}