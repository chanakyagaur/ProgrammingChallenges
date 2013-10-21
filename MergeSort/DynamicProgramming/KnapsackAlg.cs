using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass.DynamicProgramming
{
    public class KnapsackAlg
    {
        public int CalcOptimalValue(Tuple<int, int>[] data, int capacity)
        {
            var table = new int[2][];
            table[0] = new int[capacity + 1];
            table[1] = new int[capacity + 1];

            Enumerable.Range(0, capacity + 1).ForEach(i => table[0][i] = 0);

            for (int i = 1; i <= data.Length; i++)
            {
                var currentIndex = i % 2;
                var prevIndex = (i - 1) % 2;
                var vi = data[i - 1].Item1;
                var wi = data[i - 1].Item2;
                for (int x = 0; x <= capacity; x++)
                {
                    table[currentIndex][x] = Math.Max(table[prevIndex][x], (x >= wi) ? table[prevIndex][x - wi] + vi
                                                                                    : 0);    
                }                
            }

            return table[data.Length % 2][capacity];
        }
    }
}
