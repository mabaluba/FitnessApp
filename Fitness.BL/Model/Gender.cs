using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Gender
    /// </summary>
    //[Serializable]
    public class Gender
    {
        /// <summary>
        /// Type of gender
        /// </summary>
        public string GenderType { get;}
        /// <summary>
        /// Create new gender.
        /// </summary>
        public Gender(string genderType) => GenderType = ExceptionHelper.NullOrWhiteSpaceCheck(genderType);
        public override string ToString()
        {
            return GenderType;
        }
    }
}
