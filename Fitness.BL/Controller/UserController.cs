using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Serialization;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// User Controller
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Collection of users
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Create new Controller
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User cannot be NULL.", nameof(userName));
            }
            Users = GetUsers();
            CurrentUser = Users.SingleOrDefault(u => u.Name==userName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                //Save();

                SaveUsers();
                
            }

            /*var gender = new Gender(genderType);
            User = new User(userName, gender, birthDate, weight, height);*/
            //User = user ?? throw new ArgumentNullException(nameof(user), "User cannot be NULL.");
        }
        /// <summary>
        /// Get users collection
        /// </summary>
        /// <returns></returns>
        public void SetNewUserData(string genderType, DateTime birthDate, double weight=1, double height=1)
        {
            CurrentUser.Gender = new Gender(genderType);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            SaveUsers();
        }
       /* public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream("users.dat", FileMode.Open))
            {
                if(formatter.Deserialize(fileStream) is User user)
                {
                    User = user;
                }
            }
        }*/
        private List<User> GetUsers()
        {
            var formatter = new BinaryFormatter();
            using (var fileStream = new FileStream("users.dat", FileMode.Open))
            {
                if(formatter.Deserialize(fileStream) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        } 
        private void SaveUsers()
        {
            ISerialization a = new JsonSerialization();
            a.Save(Users);
        }
    }
}
