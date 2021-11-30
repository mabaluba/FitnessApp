using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fitness.BL.Serialization
{
    class JsonSerializationAsync
    {
        public async Task<List<T>> GetDataAsync<T>()
        {
            using FileStream openStream = File.OpenRead("dataAsync.json");
            return await JsonSerializer.DeserializeAsync<List<T>>(openStream);
        }

        public async Task SaveDataAsync<T>(List<T> users)
        {
            using FileStream createStream = File.Create("dataAsync.json");
            await JsonSerializer.SerializeAsync(createStream, users) ;
        }
    }
}
