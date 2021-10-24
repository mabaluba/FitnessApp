using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Customer
    /// </summary>
    [Serializable]
    public class User
    {
        public User()
        {

        }
        #region Properties
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }//поробовать с init
        public double Height { get; set; }
        public int Age 
        { 
            get { return (DateTime.Now.Year - BirthDate.Year); } 
        }
        #endregion
        /// <summary>
        /// Create new Customer
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="birthDate"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region Conditions check
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be null or whitespace.", nameof(name));
            }

            if (gender is null)
            {
                throw new ArgumentNullException("Gender cannot be null.",nameof(gender));//другой вариант, сделать одинаковые у всех
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate > DateTime.Now)
            {
                throw new ArgumentException("Invalid birth date", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Weight cannot be zero or less.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height cannot be zero or less.", nameof(Height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public User (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be null or whitespace.", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name+" "+Age+" "+BirthDate;//возможно стоит включить остальные свойства
        }
    }
}
