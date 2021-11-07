﻿using System;
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
    public class JsonSerialization// : ISerialization
    {
        public static void SaveData<T> (IEnumerable<T> items,string fileName)
        {
            var itemJson = JsonSerializer.Serialize(items);
            File.WriteAllText(fileName, itemJson);
        }

        public static List<T> GetData<T>(string fileName)
        {
            try
            {
                var itemsStringJson = File.ReadAllText(fileName);
                var itemsList = JsonSerializer.Deserialize<IEnumerable<T>>(itemsStringJson);
                return itemsList.ToList();
            }
            catch(FileNotFoundException)
            {
                return new List<T>();
            }
        }
    }
}
