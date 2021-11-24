using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Customer
    /// </summary>
    //[Serializable]
    public sealed class User
    {
        /// <summary>
        /// Props of User object
        /// </summary>
        #region Properties
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age
        {
            get { return DateTime.Now.Year - BirthDate.Year; }
        }
        /// <summary>
        /// This empty constructor required in net5.0 for correct json serialization
        /// </summary>
        public User() { }
        public User(string name)
        {
            Name = ExceptionHelper.NullOrWhiteSpaceCheck(name);
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
        //public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        //{
        //    #region Conditions check
        //    //if (string.IsNullOrWhiteSpace(name))
        //    //{
        //    //    throw new ArgumentNullException("Name cannot be null or whitespace.", nameof(name));
        //    //}

        //    //if (gender is null)
        //    //{
        //    //    throw new ArgumentNullException("Gender cannot be null.",nameof(gender));//другой вариант, сделать одинаковые у всех
        //    //}

        //    //if (birthDate < DateTime.Parse("01.01.1900") || birthDate > DateTime.Now)
        //    //{
        //    //    throw new ArgumentException("Invalid birth date", nameof(birthDate));
        //    //}

        //    //if (weight <= 0)
        //    //{
        //    //    throw new ArgumentException("Weight cannot be zero or less.", nameof(weight));
        //    //}

        //    //if (height <= 0)
        //    //{
        //    //    throw new ArgumentException("Height cannot be zero or less.", nameof(height));
        //    //}
        //    #endregion

        //    Name = name ?? throw new ArgumentNullException(nameof(name), $"'{nameof(name)}' cannot be null");
        //    Gender = gender ?? throw new ArgumentNullException(nameof(gender), $"'{nameof(gender)}' cannot be null");
        //    BirthDate = (birthDate < DateTime.Parse("01.01.1900") || birthDate > DateTime.Now) ? throw new ArgumentException("Invalid birth date", nameof(birthDate)) : birthDate;
        //    Weight = weight <= 0 ? throw new ArgumentException("Weight cannot be zero or less.", nameof(weight)) :weight;
        //    Height =  height <= 0 ? throw new ArgumentException("Height cannot be zero or less.", nameof(height)) : height;
        //}
        public override string ToString() => "\t" + Name + ", " + Age + " years old";
    }
}
