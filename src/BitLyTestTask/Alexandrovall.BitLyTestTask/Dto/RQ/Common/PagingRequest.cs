using Microsoft.AspNetCore.Mvc;

namespace Alexandrovall.BitLyTestTask.Dto.RQ.Common
{
    /// <summary>
    /// Запрос для постраничного отображения элементов
    /// </summary>
    public class PagingRequest
    {
        /// <summary>
        /// Число пропускаемых элементов
        /// </summary>
        [BindProperty(Name = "offset")]
        public int Offset { get; set; } = 0;

        /// <summary>
        /// Число возвращаемых элементов
        /// </summary>
        [BindProperty(Name = "limit")]
        public int Limit { get; set; } = 20;
    }
}