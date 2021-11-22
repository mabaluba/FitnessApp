using System;

namespace Fitness.BL
{
    internal static class ExceptionHelper
    {
        public static string NullOrWhiteSpaceCheck(string argument)
        {
            return string.IsNullOrWhiteSpace(argument) ? throw new ArgumentException($"'{nameof(argument)}' cannot be null or whitespace.", nameof(argument)) : argument;
        }

        public static double NegativeDoubleNumberCheck(double number)
        {
            return number < 0 ? throw new ArgumentException("The number cannot be less than 0.") : number;
        }
    }
}
