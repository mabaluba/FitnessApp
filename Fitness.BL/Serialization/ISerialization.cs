using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Serialization
{
    interface ISerialization
    {
        public void Save<T>(List<T> users);
        //public List<T> GetData<T>();
    }
}
