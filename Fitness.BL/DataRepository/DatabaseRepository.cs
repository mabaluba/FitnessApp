using Fitness.BL.Serialization;
using System;
using System.Collections.Generic;

namespace Fitness.BL.DataRepository
{
    class DatabaseRepository : ISerialization
    {
        public IEnumerable<T> GetData<T>() where T: class
        {
            IEnumerable<T> data;
            using (var db = new FitnessContext())
            {
                data = db.Set<T>().Local.Count == 0 ? new List<T>() : db.Set<T>();

            }
            return data;
        }

        public void SaveData<T>(IEnumerable<T> items)
        {
            using (var db = new FitnessContext())
            {
                db.AddRange(items);
                db.SaveChanges();
            }
        }
    }
}
