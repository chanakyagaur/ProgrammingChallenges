using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MergeSort;

namespace InversionCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() == 2)
            {
                string filePath = args[0];
                int arrayLength;
                int.TryParse(args[1], out arrayLength);
                var list = new List<int>(arrayLength > 0 ? arrayLength : 32);
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        int element;
                        if (int.TryParse(reader.ReadLine(), out element))
                        {
                            list.Add(element);
                        }
                    }
                }
                Console.WriteLine("Data reading complete, element count={0}", list.Count);
                long inversionCount;
                var timer = new Stopwatch();
                timer.Start();
                int medianComparison = QuickSort.SortAndCountComparisons(list.ToArray(), PivotStrategy.MedianOfTrhee);                
                timer.Stop();
                long mergeSortElapsed = timer.ElapsedMilliseconds;
                timer.Restart();
                //int firstComparison = QuickSort.SortAndCountComparisons(list.ToArray(), PivotStrategy.First);
                MergeSort.MergeSort.SortAndCount(list.ToArray(), out inversionCount);
                timer.Stop();
                long quickSortElapsed = timer.ElapsedMilliseconds;
                //int lastComparison = QuickSort.SortAndCountComparisons(list.ToArray(), PivotStrategy.Last);

                Console.WriteLine("time elapsed: {0}, inversion count={1}", mergeSortElapsed, inversionCount);
                Console.WriteLine("time elapsed: {0}, medium count={1}", quickSortElapsed, medianComparison);
                //Console.WriteLine("time elapsed: {0}, first count={1}, medium count={2}, last count={3}", timer.ElapsedMilliseconds, firstComparison, medianComparison, lastComparison);
                Console.WriteLine("press any key");
                Console.ReadLine();
            }
        }
    }
}
