using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Alexandrovall.BitLyTestTask.DataAccess.MongoDb.Models
{
    /// <summary>
    /// Информация о ссылке
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Id ссылки
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Оригинальная ссылка
        /// </summary>
        [BsonElement("originalLink")]
        public string OriginalLink { get; set; }
        
        /// <summary>
        /// Id пользователя
        /// </summary>
        [BsonElement("userId")]
        public string UserId { get; set; }
        
        /// <summary>
        /// Количество переходов
        /// </summary>
        [BsonElement("transitionCount")]
        public int TransitionCount { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        [BsonElement("creationDate")]
        public DateTime CreationDate { get; set; }
    }
}