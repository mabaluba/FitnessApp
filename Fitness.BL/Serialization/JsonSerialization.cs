using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace Fitness.BL.Serialization
{
    /// <summary>
    /// Provides methods with Serialization to and from json file format.
    /// </summary>
    public class JsonSerialization : ISerialization
    {
        public void SaveData<T> (T items,string fileName)
        {
            var itemJson = JsonSerializer.Serialize(items);
            File.WriteAllText(fileName, itemJson);
        }

        public IEnumerable<T> GetData<T>(string fileName)
        {
            try
            {
                var itemsStringJson = File.ReadAllText(fileName);
                var itemsList = JsonSerializer.Deserialize<IEnumerable<T>>(itemsStringJson);
                return itemsList;
            }
            catch(FileNotFoundException)
            {
                return new List<T>();
            }
        }
    }
}
