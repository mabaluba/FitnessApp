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
            using FileStream openStream = File.OpenRead("data.json");
            var usersList = await JsonSerializer.DeserializeAsync<List<T>>(openStream);
            return usersList;
        }
        public async void SaveDataAsync<T>(List<T> users)
        {
            using FileStream createStream = File.Create("data.json");
            await JsonSerializer.SerializeAsync(createStream, users);
        }
    }
}
