using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Gender
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Type of gender
        /// </summary>
        public string GenderType { get; set; }
        /// <summary>
        /// Create new gender.
        /// </summary>
        public Gender(string genderType)
        {
            if (string.IsNullOrWhiteSpace(genderType))
            {
                throw new ArgumentNullException("Name can not be EMPTY or NULL", nameof(genderType));
            }
            GenderType = genderType;
        }
        public override string ToString()
        {
            return GenderType;
        }
    }
}
