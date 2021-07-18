using System;
using System.Linq;
using System.Threading.Tasks;
using Alexandrovall.BitLyTestTask.Dto.RQ;
using Alexandrovall.BitLyTestTask.Dto.RS;
using Alexandrovall.BitLyTestTask.Dto.RS.Common;
using AutoMapper;
using MediatR;
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
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LinksController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Создание сокращённой ссылки
        /// </summary>
        /// <param name="request">Запрос на создание сокращённой ссылки</param>
        /// <returns>Ответ с сокращённой ссылкой</returns>
        [HttpPost]
        [ProducesResponseType(typeof(CreateShortLinkResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<CreateShortLinkResponse> CreateShortLink([FromBody] CreateShortLinkRequest request)
        {
            var mediatrRequest = _mapper.Map<MediatR.Contracts.Requests.CreateShortLinkRequest>(request);
            var shortLink = await _mediator.Send(mediatrRequest);
            return new CreateShortLinkResponse(shortLink);
        }

        /// <summary>
        /// Получение списка сокращённых ссылок
        /// </summary>
        /// <param name="request">Запрос на получение списка ссылок пользователя</param>
        /// <returns>Ответ со списком сокращённых ссылок</returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetShortLinkListResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<GetShortLinkListResponse> GetShortLinkList([FromQuery] GetShortLinkListRequest request)
        {
            var mediatrRequest = _mapper.Map<MediatR.Contracts.Requests.GetShortLinkListRequest>(request);
            var shortLinkList = await _mediator.Send(mediatrRequest);
            return new GetShortLinkListResponse(shortLinkList.Select(_mapper.Map<Dto.ShortLink>).ToList());
        }

        /// <summary>
        /// Получение оригинальной ссылки. Увеличивает счётчик переходов
        /// </summary>
        /// <param name="linkId">Id сокращённой ссылки</param>
        /// <returns>Ответ с оригинальной ссылки</returns>
        [HttpGet("{link_id}")]
        [ProducesResponseType(typeof(GetOriginalLinkResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<GetOriginalLinkResponse> GetOriginalLink([FromRoute(Name = "link_id")] Guid linkId)
        {
            var mediatrRequest = new MediatR.Contracts.Requests.GetOriginalLinkRequest {LinkId = linkId,};
            var originalLink = await _mediator.Send(mediatrRequest);
            return new GetOriginalLinkResponse(originalLink);
        }
    }
}