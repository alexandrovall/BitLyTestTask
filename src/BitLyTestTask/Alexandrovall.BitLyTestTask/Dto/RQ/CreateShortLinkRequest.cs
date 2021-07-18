using System.ComponentModel.DataAnnotations;

namespace Alexandrovall.BitLyTestTask.Dto.RQ
{
    /// <summary>
    /// Запрос на создание сокращённой ссылки
    /// </summary>
    public class CreateShortLinkRequest
    {
        /// <summary>
        /// Ссылка для сокращения
        /// </summary>
        [Required]
        public string Link { get; set; }
    }
}