using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness.BL.Model
{
    //[Serializable]
    public sealed class User
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age
        {
            get { return DateTime.Now.Year - BirthDate.Year; }
        }
        public User() { }
        public User(string name)
        {
            Name = ExceptionHelper.NullOrWhiteSpaceCheck(name);
        }

        public override string ToString() => "\t" + Name + ", " + Age + " years old";
    }
}
