using System;

namespace Alexandrovall.BitLyTestTask.Dto.RS.Common
{
    /// <summary>
    /// Ответ с информацией об ошибке
    /// </summary>
    public class ErrorResponse : Response
    {
        /// <summary>
        /// <inheritdoc cref="Response"/>
        /// </summary>
        public override bool Success => false;

        /// <summary>
        /// Информация об ошибке
        /// </summary>
        public Error Error { get; }

        /// <summary>
        /// Конструктор для создания ответа с информацией об ошибке
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="code">Код ошибки</param>
        /// <param name="exception">Исключение, которое привело к ошибке</param>
        public ErrorResponse(string message, string code, Exception exception) =>
            Error = new Error(message, code, exception);
    }
}