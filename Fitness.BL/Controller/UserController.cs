using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fitness.BL.Controller
{
    public class UserController
    {
        public User User { get;}
        public UserController(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user), "User cannot be NULL.");
        }
        public async void Save()
        {
            //var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                //formatter.Serialize(fileStream, User);
                await JsonSerializer.SerializeAsync(fileStream, User);
            }
            
        }
    }
}
