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
    /// <summary>
    /// Provides methods with Serialization to and from json file format.
    /// </summary>
    public class JsonSerialization : ISerialization
    {
        public void SaveData<T> (IEnumerable<T> users)
        {
            var usersJson = JsonSerializer.Serialize(users);
            File.WriteAllText("data.json", usersJson);
        }
        public List<T> GetData<T>()
        {
            var usersStringJson = File.ReadAllText("data.json");
            var usersList = JsonSerializer.Deserialize<IEnumerable<T>>(usersStringJson);
            return usersList.ToList();
        }
    }
}
