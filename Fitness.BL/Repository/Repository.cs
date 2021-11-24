using Fitness.BL.Serialization;
using System.Collections.Generic;

namespace Fitness.BL
{
    /// <summary>
    /// Provides methods for save and get objects collection
    /// </summary>
    public class Repository
    {
        /// <summary>
        /// Provides serialization type
        /// </summary>
        private ISerialization _serializer = new JsonSerialization();

        protected IEnumerable<T> GetData<T>(string dataFileName)
        {
            return _serializer.GetData<T>(dataFileName);
        }

        protected void SaveData<T>(T items, string dataFileName)
        {
            _serializer.SaveData(items, dataFileName);
        }
    }
}
