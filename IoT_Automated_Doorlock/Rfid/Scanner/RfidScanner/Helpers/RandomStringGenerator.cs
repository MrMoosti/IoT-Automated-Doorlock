using System;

namespace RfidScanner.Helpers
{

    public static class RandomStringGenerator
    {

        /// <summary>
        /// Get a random generated string.
        /// </summary>
        /// <param name="length">The length of the string that will be generated.</param>
        /// <returns>
        /// A random string
        /// </returns>
        public static string GenerateRandomString(int length)
        {
            var chars = new char[length];
            for (var i = 0; i < length; i++)
            {
                chars[i] = RandomChar();
            }
            return new string(chars);
        }


        /// <summary>
        /// Generate a random <see cref="char"/> from the list of <see cref="Chars"/>
        /// </summary>
        /// <returns>
        /// A random <see cref="char"/>.
        /// </returns>
        private static char RandomChar() => Chars[new Random().Next(0, Chars.Length)];


        /// <summary>
        /// An array of all available <see cref="char"/>s.
        /// </summary>
        private static readonly char[] Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*()".ToCharArray();
    }
}