using Fitness.BL.Model;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Type User for checking and saving new user
        /// </summary>
        public User CurrentUser { get; }
        /// <summary>
        /// Prop for checking if user is new
        /// </summary>
        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Create new Controller for:
        /// - getting user name
        /// - checking is it exists
        /// - creating new user with name
        /// </summary>
        /// <param name="userName"></param>
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
                IsNewUser = true;
            }
        }
        /// <summary>
        /// Set to new user others params and save it 
        /// </summary>
        /// <param name="genderType"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public void SetNewUserData(string genderType, DateTime birthDate, double weight=1, double height=1)
        {
            CurrentUser.Gender = new Gender(genderType);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Users.Add(CurrentUser);
            SaveUsers();
        }
        /// <summary>
        /// Get users collection
        /// </summary>
        /// <returns></returns>
        private List<User> GetUsers()
        {
            ISerialization a = new JsonSerialization();
            return a.GetData<User>();
        }
        /// <summary>
        /// Save users collection
        /// </summary>
        private void SaveUsers()
        {
            ISerialization a = new JsonSerialization();
            a.SaveData(Users);
        }
    }
}
