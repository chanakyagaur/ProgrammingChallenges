using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    public static class QuickSort
    {
        public static int SortAndCountComparisons(
            int[] input,
            PivotStrategy pivotStrategy)
        {
            int comparisonsCount = 0;
            Sort(input, 0, input.Length - 1, pivotStrategy, ref comparisonsCount);
            return comparisonsCount;
        }

        private static void Sort(
            int[] input, 
            int startIndex, 
            int endIndex, 
            PivotStrategy pivotStrategy,
            ref int comparisonsCount)
        {
            if (endIndex - startIndex <= 0)
            {
                return;
            }

            comparisonsCount += endIndex - startIndex;

            int partitionIndex;
            Partition(input, startIndex, endIndex, pivotStrategy, out partitionIndex);
            Sort(input, startIndex, partitionIndex - 1, pivotStrategy, ref comparisonsCount);
            Sort(input, partitionIndex + 1, endIndex, pivotStrategy, ref comparisonsCount);
        }

        private static void Partition(
            int[] input, 
            int startIndex, 
            int endIndex, 
            PivotStrategy pivotStrategy, 
            out int pivotIndex)
        {
            pivotIndex = GetPivotIndex(input, startIndex, endIndex, pivotStrategy);
            Swap(input, startIndex, pivotIndex);
            pivotIndex = startIndex;

            int lastLessValueIndex = startIndex + 1;
            int pivot = input[pivotIndex];
            for (int index = startIndex + 1; index <= endIndex; index++)
            {
                if (input[index] < pivot)
                {
                    Swap(input, index, lastLessValueIndex);
                    lastLessValueIndex++;
                }
            }
            Swap(input, pivotIndex, lastLessValueIndex - 1);
            pivotIndex = lastLessValueIndex - 1;
        }

        public static int GetPivotIndex(int[] input, int startIndex, int endIndex, PivotStrategy pivotStrategy)
        {
            switch (pivotStrategy)
            {
                case PivotStrategy.First:
                    return startIndex;
                case PivotStrategy.Last:
                    return endIndex;
                case PivotStrategy.MedianOfTrhee:
                    {
                        int arrayLength = endIndex - startIndex + 1;
                        int mediumIndex = arrayLength%2 == 0 ? arrayLength/2 - 1 : arrayLength/2;
                        mediumIndex += startIndex;
                        if (input[startIndex] >= input[mediumIndex])
                        {
                            if (input[startIndex] <= input[endIndex])
                            {
                                return startIndex;
                            }
                            if (input[mediumIndex] >= input[endIndex])
                            {
                                return mediumIndex;
                            }
                            return endIndex;
                        }
                        if (input[startIndex] >= input[endIndex])
                        {
                            return startIndex;
                        }
                        if (input[mediumIndex] < input[endIndex])
                        {
                            return mediumIndex;
                        }
                        return endIndex;
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        private static void Swap(int[] input, int left, int right)
        {
            if (left == right)
                return; 

            input[left] += input[right];
            input[right] = input[left] - input[right];
            input[left] -= input[right];
        }
    }
}
