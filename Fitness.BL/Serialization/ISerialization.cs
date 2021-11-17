using System.Collections.Generic;


namespace Fitness.BL.Serialization
{
    public interface ISerialization
    {
        public void SaveData<T>(T items, string fileName);
        public IEnumerable<T> GetData<T>(string fileName);
    }
}
