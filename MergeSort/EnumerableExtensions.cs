using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass
{
    public static class EnumerableExtensions
    {
        static readonly Random Random = new Random();
        public static T[] AsShuffledArray<T>(this IEnumerable<T> input)
        {
            return input.Select(item => new KeyValuePair<int, T>(Random.Next(), item))
                        .OrderBy(pair => pair.Key)
                        .Select(pair => pair.Value)
                        .ToArray();
        }

        public static void ForEach<T>(this IEnumerable<T> input, Action<T> action)
        {
            foreach (T item in input)
            {
                action(item);
            }
        }
    }
}
