﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass;

namespace TwoSumConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() != 1)
                return;

            string filePath = args[0];

            var numbers = File.ReadAllLines(filePath);
            //CalculateTwoSum(numbers);
            CalculateMedians(numbers);
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }

        private static void CalculateTwoSum(string[] numbers)
        {
            var hashSet = new HashSet<int>();
            Array.ForEach(numbers, x => hashSet.Add(int.Parse(x)));
            Console.WriteLine("result={0}", TwoSumAlg.Calculate(2500, 4000, hashSet));
        }

        private static void CalculateMedians(string[] numbers)
        {
            Console.WriteLine("result={0}", MedianMaintenenceAlg.CalculateMedianSum(numbers.Select(int.Parse).ToArray()) % 10000);
        }
    }
}
