namespace Alexandrovall.BitLyTestTask.Dto.RS.Common
{
    /// <summary>
    /// Ответ, содержащий информацию о результате выполнения запроса
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Индикатор статуса обработки запроса
        /// </summary>
        public virtual bool Success => true;
    }

    /// <summary>
    /// Ответ, содержащий информацию о результате выполнения запроса и тело ответа
    /// </summary>
    public class Response<T> : Response
    {
        /// <summary>
        /// Тело ответа
        /// </summary>
        public T Data { get; }

        public Response(T data)
        {
            Data = data;
        }
    }
}