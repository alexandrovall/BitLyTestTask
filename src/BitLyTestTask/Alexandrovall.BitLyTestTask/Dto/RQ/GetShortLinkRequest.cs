using System.ComponentModel.DataAnnotations;

namespace Alexandrovall.BitLyTestTask.Dto.RQ
{
    /// <summary>
    /// Запрос на сокращение ссылки
    /// </summary>
    public class GetShortLinkRequest
    {
        /// <summary>
        /// Ссылка для сокращения
        /// </summary>
        [Required]
        public string Link { get; set; }
    }
}