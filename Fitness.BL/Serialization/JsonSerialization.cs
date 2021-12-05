using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Fitness.BL.Serialization
{
    /// <summary>
    /// Provides methods with Serialization to and from json file format.
    /// </summary>
    public class JsonSerialization : ISerialization
    {
        
        public void SaveData<T>(IEnumerable<T> items) where T : class
        {
            var fileName = typeof(T).Name;
            var itemJson = JsonSerializer.Serialize(items);
            File.WriteAllText(fileName, itemJson);
        }

        public IEnumerable<T> GetData<T>() where T: class
        {
            var fileName = typeof(T).Name;
            try
            {
                var itemsStringJson = File.ReadAllText(fileName);
                var itemsList = JsonSerializer.Deserialize<IEnumerable<T>>(itemsStringJson);
                return itemsList;
            }
            catch (FileNotFoundException)
            {
                return new List<T>();
            }
        }
    }
}
