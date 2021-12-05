using Fitness.BL.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.DataRepository
{
    class DatabaseRepository : ISerialization
    {
        public IEnumerable<T> GetData<T>() where T: class
        {
            //IEnumerable<T> data;
            using (var db = new FitnessContext())
            {
                //data = db.Set<T>().Local.Count == 0 ? new List<T>() : db.Set<T>();
                var data = db.Set<T>().Where(t=> true).ToList();
                return data;
            }
            
        }

        public void SaveData<T>(IEnumerable<T> items) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().Add(items.Last());
                db.SaveChanges();
            }
        }
    }
}
