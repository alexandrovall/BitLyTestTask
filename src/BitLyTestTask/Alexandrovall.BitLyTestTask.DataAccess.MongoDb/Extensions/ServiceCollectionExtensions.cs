using System;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Alexandrovall.BitLyTestTask.DataAccess.MongoDb.Extensions
{
    /// <summary>
    /// Метод расширения для регистрации MongoDB
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Добавление сервисов для работы с MongoDB
        /// </summary>
        /// <param name="services">Коллекция, в которую добавляются сервисы</param>
        /// <param name="connectionString">Строка подключения</param>
        public static void AddMongoDb(this IServiceCollection services, string connectionString)
        {
            if (services is null)
            {
                return;
            }

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            services.AddSingleton<IMongoClient>(_ => new MongoClient(connectionString));
        }
    }
}