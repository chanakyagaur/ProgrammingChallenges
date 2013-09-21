using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass
{
    public static class StringExtensions
    {
        public static string ReplaceAt(this string input, int index, char newChar)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            var builder = new StringBuilder(input);
            builder[index] = newChar;
            return builder.ToString();
        }
    }
}
