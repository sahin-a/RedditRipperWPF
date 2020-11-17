using System;
using System.IO;

namespace RedditRipperWPF.Web.utils
{
    public class Utils
    {
        private static readonly Lazy<Utils> lazy =
            new Lazy<Utils>(() => new Utils());

        private char[] invalidChars;

        public static Utils Instance { get { return lazy.Value; } }

        private Utils()
        {
            char[] invalidFileNameCars = Path.GetInvalidFileNameChars();
            char[] invalidPathChars = Path.GetInvalidPathChars();
            char[] additionalChars = new char[] { '\"', '\'', ' ' };

            invalidChars = new char[invalidFileNameCars.Length + invalidPathChars.Length + additionalChars.Length];

            Array.Copy(invalidFileNameCars, this.invalidChars, invalidFileNameCars.Length);
            Array.Copy(invalidPathChars, this.invalidChars, invalidPathChars.Length);
            Array.Copy(additionalChars, this.invalidChars, additionalChars.Length);
        }

        public string ReplaceInvalidCharsAsync(string value)
        {
            foreach (char invalidChar in invalidChars)
            {
                value = value.Replace(invalidChar, '_');
            }

            return value;
        }
    }
}
