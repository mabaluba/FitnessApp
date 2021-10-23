using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Text.Json;
using Fitness.BL.Model;
using System.IO;

namespace Fitness.BL.Serialization
{
    public class JsonSerialization:ISerialization
    {
        public async Task<List<T>> GetData<T>()
        {
            /*var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream("users.dat", FileMode.Open))*/
            using FileStream openStream = File.OpenRead("data.json");
            return await JsonSerializer.DeserializeAsync<List<T>>(openStream);
            
        }

        public async void Save<T>(List<T> users)
        {
            using FileStream createStream = File.OpenWrite("data.json");
            await JsonSerializer.SerializeAsync(createStream, users);
        }

        /*public void Save<T>(List<T> users)
        {
            throw new NotImplementedException();
        }*/
    }
}
