using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass
{
    static class ArrayExtensions
    {
        public static string ToCustomString<T>(this T[] values)
        {
            return string.Join(",", values);
        }
    }
}
