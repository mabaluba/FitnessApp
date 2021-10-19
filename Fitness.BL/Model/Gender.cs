using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Gender
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Name
        /// </summary>
        public string GenderType { get; }
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
