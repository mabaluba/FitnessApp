using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// User Controller
    /// </summary>
    public class UserController: Repository
    {
        private const string UsersFileName = "users.json";

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
            userName = ExceptionHelper.NullOrWhiteSpaceCheck(userName);
            Users = GetData<User>(UsersFileName).ToList();
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
        public void SetNewUserData(string genderType, DateTime birthDate, double weight, double height)
        {
            CurrentUser.Gender = new Gender(genderType);
            CurrentUser.BirthDate = (birthDate < DateTime.Parse("01.01.1900") || birthDate > DateTime.Now) ? throw new ArgumentException("Invalid birth date", nameof(birthDate)) : birthDate;
            CurrentUser.Weight = weight <= 0 ? throw new ArgumentException("Weight cannot be zero or less.", nameof(weight)) : weight;
            CurrentUser.Height = height <= 0 ? throw new ArgumentException("Height cannot be zero or less.", nameof(height)) : height;
            Users.Add(CurrentUser);
            SaveData(Users,UsersFileName);
        }
    }
}
