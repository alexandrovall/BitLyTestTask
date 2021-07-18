using System;

namespace Alexandrovall.BitLyTestTask.MediatR.Contracts.Requests.Common
{
    /// <summary>
    /// Базовый запрос с информацией о пользователе
    /// </summary>
    public class UserRequest
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}