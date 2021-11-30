namespace Fitness.BL.Model
{
    /// <summary>
    /// Gender
    /// </summary>
    //[Serializable]
    public sealed class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Type of gender
        /// </summary>
        public string GenderType { get; set; }
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
