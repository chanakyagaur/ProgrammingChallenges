using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass
{
    public class MedianMaintenenceAlg
    {
        public static int CalculateMedianSum(int[] numbers)
        {
            int medianSum = 0;
            var lowHeap = new SortedDictionary<int, int>();
            var highHeap = new SortedDictionary<int, int>();
            lowHeap.Add(numbers[0],0);
            medianSum += numbers[0];
            for (int index = 1; index < numbers.Length; index++)
            {
                int lowHeapMax = lowHeap.Last().Key;
                int current = numbers[index];
                // update heaps
                if (current < lowHeapMax)
                {
                    lowHeap.Add(current,0);
                }
                else
                {
                    highHeap.Add(current, 0);
                }

                bool mayRequireBalancing = (index + 1)%2 == 0;
                // balancing
                if (mayRequireBalancing && lowHeap.Count != highHeap.Count)
                {
                    if (lowHeap.Count > highHeap.Count)
                    {
                        lowHeapMax = lowHeap.Last().Key;
                        lowHeap.Remove(lowHeapMax);
                        highHeap.Add(lowHeapMax, 0);
                    }
                    else
                    {
                        int highHeapMin = highHeap.First().Key;
                        highHeap.Remove(highHeapMin);
                        lowHeap.Add(highHeapMin, 0);
                    }
                }    
           
                // calculate median
                if (lowHeap.Count >= highHeap.Count)
                {
                    medianSum += lowHeap.Last().Key;
                }
                else
                {
                    medianSum += highHeap.First().Key;
                }                
            }

            return medianSum;
        }

    }
}
