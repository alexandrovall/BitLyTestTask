using System;
using System.Threading.Tasks;
using Alexandrovall.BitLyTestTask.Dto.RQ;
using Alexandrovall.BitLyTestTask.Dto.RS;
using Alexandrovall.BitLyTestTask.Dto.RS.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alexandrovall.BitLyTestTask.Controllers
{
    /// <summary>
    /// Контроллер для работы со ссылками
    /// </summary>
    [ApiController]
    [AllowAnonymous]
    [Route("api/links")]
    public class LinksController : ControllerBase
    {
        /// <summary>
        /// Получение сокращённой ссылки
        /// </summary>
        /// <param name="request">Запрос на получение сокращённой ссылки</param>
        /// <returns>Ответ с сокращённой ссылкой</returns>
        [HttpPost]
        [ProducesResponseType(typeof(GetShortLinkResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public Task<GetShortLinkResponse> GetShortLink([FromBody] GetShortLinkRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Получение списка сокращённых ссылок
        /// </summary>
        /// <param name="request">Запрос на получение списка ссылок пользователя</param>
        /// <returns>Ответ со списком сокращённых ссылок</returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetShortLinkResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public Task<GetShortLinkListResponse> GetShortLinkList([FromQuery] GetShortLinkListRequest request)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Получение оригинальной ссылки. Увеличивает счётчик переходов
        /// </summary>
        /// <param name="linkId">Id сокращённой ссылки</param>
        /// <returns>Ответ с оригинальной ссылки</returns>
        [HttpGet("{link_id}")]
        [ProducesResponseType(typeof(GetShortLinkResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public Task<GetOriginalLinkResponse> GetOriginalLink([FromRoute(Name = "link_id")] Guid linkId)
        {
            throw new NotImplementedException();
        }
    }
}