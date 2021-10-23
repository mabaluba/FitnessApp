using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Serialization
{
    public class BFSerialization:ISerialization
    {
        public List<T> GetData<T>()
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream("users.dat", FileMode.Open))
            {
                if (formatter.Deserialize(fileStream) is List<T> users)
                {
                    return users;
                }
                else
                {
                    return new List<T>();
                }
            }
        }

        public void Save<T>(List<T> users)
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, users);
            }
        }
    }
}
