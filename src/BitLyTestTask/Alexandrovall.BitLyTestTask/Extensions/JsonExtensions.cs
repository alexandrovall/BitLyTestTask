using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Alexandrovall.BitLyTestTask.Extensions
{
    internal static class JsonExtensions
    {
        private static readonly JsonSerializerSettings JsonSerializerSettings = new()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy(),
            },
        };

        public static string ToJson<T>(this T item)
        {
            return item is null ? null : JsonConvert.SerializeObject(item, JsonSerializerSettings);
        }
    }
}