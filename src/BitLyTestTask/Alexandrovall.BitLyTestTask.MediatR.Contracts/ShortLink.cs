namespace Alexandrovall.BitLyTestTask.MediatR.Contracts
{
    /// <summary>
    /// Информация о сокращённой ссылке
    /// </summary>
    public class ShortLink
    {
        /// <summary>
        /// Сокращённая ссылка
        /// </summary>
        public string Link { get; set; }

        /// <summary>
        /// Количество переходов
        /// </summary>
        public int TransitionCount { get; set; }
    }
}