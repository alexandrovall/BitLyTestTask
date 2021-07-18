using System;
using Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests.Common;
using MediatR;

namespace Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests
{
    /// <summary>
    /// Запрос на получение оригинальной ссылки по сокращённой
    /// </summary>
    public class GetOriginalLinkRequest : UserRequest, IRequest<string>
    {
        /// <summary>
        /// Id сокращённой ссылки
        /// </summary>
        public string LinkId { get; set; }
    }
}