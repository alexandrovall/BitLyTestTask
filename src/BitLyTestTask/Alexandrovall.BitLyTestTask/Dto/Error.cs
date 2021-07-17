using System;
using System.Collections.Generic;
using System.Linq;

namespace Alexandrovall.BitLyTestTask.Dto
{
    /// <summary>
    /// Информация об ошибке
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Код ошибки
        /// </summary>
        public string Code { get; }
        
        /// <summary>
        /// Тип ошибки
        /// </summary>
        public string Type { get; }
        
        /// <summary>
        /// Сообщение, описывающее текущую ошибку
        /// </summary>
        public string Message { get; }
        
        // Скопипастил с https://docs.microsoft.com/ru-ru/dotnet/api/system.exception.stacktrace?view=net-5.0
        /// <summary>
        /// Строковое представление непосредственных кадров в стеке вызова
        /// </summary>
        public string StackTrace { get; }
        
        /// <summary>
        /// Возвращает коллекцию пар «ключ-значение», предоставляющую дополнительные сведения об исключении
        /// </summary>
        public object Data { get; }
        
        /// <summary>
        /// Информация о связанных ошибках
        /// </summary>
        public IReadOnlyCollection<Error> Details { get; }

        /// <summary>
        /// Конструктор для создания ошибки
        /// </summary>
        /// <param name="message">Сообщение об ошибке</param>
        /// <param name="code">Код ошибки</param>
        /// <param name="exception">Исключение, которое привело к ошибке</param>
        public Error(string message, string code, Exception exception)
        {
            Message = message;
            Code = code;

            if (exception is not null)
            {
                Details = new[] {new Error(exception)};
            }
        }

        private Error(Exception exception)
        {
            Type = exception.GetType().Name;
            Message = exception.Message;
            StackTrace = exception.StackTrace;
            Data = exception.Data.Keys.Count > 0 ? exception.Data : default;

            if (exception is AggregateException aex && aex.InnerExceptions.Any())
            {
                Details = aex.InnerExceptions.Select(p => new Error(p)).ToList();
            }
            else if (exception.InnerException != null)
            {
                Details = new[] {new Error(exception.InnerException)};
            }
        }
    }
}