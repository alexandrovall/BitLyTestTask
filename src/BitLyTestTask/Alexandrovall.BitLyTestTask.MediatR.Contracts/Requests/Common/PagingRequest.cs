namespace Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests.Common
{
    /// <summary>
    /// Запрос для постраничного отображения элементов
    /// </summary>
    public class PagingRequest : UserRequest
    {
        /// <summary>
        /// Число пропускаемых элементов
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Число возвращаемых элементов
        /// </summary>
        public int Limit { get; set; }
    }
}