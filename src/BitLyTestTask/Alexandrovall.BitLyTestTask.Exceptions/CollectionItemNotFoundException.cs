using System;

namespace Alexandrovall.BitLyTestTask.Exceptions
{
    /// <summary>
    /// Иключение при отсутствии элемента в коллекции
    /// </summary>
    public class CollectionItemNotFoundException : Exception
    {
        /// <summary>
        /// Конструктор для создания экземпляра по названию коллекции и id элемента
        /// </summary>
        /// <param name="collectionName">Название коллекции</param>
        /// <param name="id">Id элемента</param>
        public CollectionItemNotFoundException(string collectionName, string id) : base(
            $"Не удалось найти элемент в коллекции {collectionName} по id {id}")
        {
            if (string.IsNullOrEmpty(collectionName)) throw new ArgumentNullException(nameof(collectionName));
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
        }
    }
}