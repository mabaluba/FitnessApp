using Fitness.BL.Serialization;
using System.Collections.Generic;

namespace Fitness.BL.DataRepository
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

        protected IEnumerable<T> GetData<T>() where T: class
        {
            return _serializer.GetData<T>();
        }

        protected void SaveData<T>(IEnumerable<T> items)
        {
            _serializer.SaveData(items);
        }
    }
}
