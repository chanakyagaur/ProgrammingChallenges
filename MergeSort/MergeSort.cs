using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    public class MergeSort
    {
        public static int[] SortAndCount(ICollection<int> unsortedArray, out long inversionCount)
        {
            if (unsortedArray.Count <= 1)
            {
                inversionCount = 0;
                return unsortedArray.ToArray();
            }

            int length = unsortedArray.Count;
            int half = length/2;

            long leftInversionCount, rightInversionCount, splitInversionCount;
            var left = SortAndCount(unsortedArray.Take(half).ToArray(), out leftInversionCount);
            var right = SortAndCount(unsortedArray.Skip(half).Take(length - half).ToArray(), out rightInversionCount);
            var sortedArray = MergeAndCount(length, left, right, out splitInversionCount);
            inversionCount = leftInversionCount + rightInversionCount + splitInversionCount;

            return sortedArray;
        }

        private static int[] MergeAndCount(int length, int[] left, int[] right, out long inversionCount)
        {
            int leftIndex = 0;
            int rigthIndex = 0;
            inversionCount = 0;
            var sortedArray = new int[length];
            for (int index = 0; index < length; index++)
            {
                if (leftIndex == left.Length)
                {
                    sortedArray[index] = right[rigthIndex];
                    rigthIndex++;
                    continue;
                }
                
                if (rigthIndex == right.Length || left[leftIndex] < right[rigthIndex])
                {
                    sortedArray[index] = left[leftIndex];
                    leftIndex++;
                    inversionCount += rigthIndex;
                }
                else
                {
                    sortedArray[index] = right[rigthIndex];                    
                    rigthIndex++;
                }
            }

            return sortedArray;
        }
    }
}
