using System.Collections.Generic;

namespace Fitness.BL.Serialization
{
    public interface ISerialization
    {
        public void SaveData<T>(IEnumerable<T> items) where T : class;
        public IEnumerable<T> GetData<T>() where T: class;
    }
}
