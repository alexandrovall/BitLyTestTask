using System.Collections.Generic;

namespace Alexandrovall.BitLyTestTask.Dto.RS.Common
{
    /// <summary>
    /// Ответ с информацией для постраничного отображения элементов
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagingResponse<T> : Response<IReadOnlyCollection<T>>
    {
        /// <summary>
        /// Флаг для проверки наличия следующих элементов
        /// </summary>
        public bool HasNext => Data?.Count > 0;
    }
}