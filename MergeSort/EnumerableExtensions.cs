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

        /// <summary>
        /// http://stackoverflow.com/a/1898744/540802
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elements"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } :
              elements.SelectMany((e, i) =>
                elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }

    }
}
