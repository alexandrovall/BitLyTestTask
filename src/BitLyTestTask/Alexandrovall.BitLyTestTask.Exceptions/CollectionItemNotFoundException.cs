using System;

namespace Alexandrovall.BitLyTestTask.Exceptions
{
    public class CollectionItemNotFoundException : Exception
    {
        public CollectionItemNotFoundException(string collectionName, string id) : base(
            $"Не удалось найти элемент в коллекции {collectionName} по id {id}")
        {
            if (string.IsNullOrEmpty(collectionName)) throw new ArgumentNullException(nameof(collectionName));
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
        }
    }
}