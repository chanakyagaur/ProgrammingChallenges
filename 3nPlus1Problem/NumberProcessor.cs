using System;
using System.Collections.Generic;
using System.Linq;


namespace _3nPlus1Problem
{
    public class NumberProcessor
    {
        private readonly Dictionary<int, int> _hash = new Dictionary<int, int> { { 1, 1 } };
        private readonly Stack<int> _stack = new Stack<int>();
        private const int MinValue = 1;
        private const int MaxValue = 1000000;

        public int CalculateCycleLength(int start, int finish)
        {
            Validate(start, finish);
            int maxCycle = 0;
            int finishOdd = finish % 2 == 0 ? finish - 1 : finish;
            for (int current = finishOdd; current >= start; current-=2)
            {
                int cycle = ProcessNumberRecursivly(current);
                if (cycle > maxCycle)
                    maxCycle = cycle;
            }

            return maxCycle;
        }

        public int ProcessNumberRecursivly(int number)
        {
            if (number == MinValue)
            {
                return number;
            }

            int cycleNumber;
            if (_hash.TryGetValue(number, out cycleNumber))
            {
                return cycleNumber;
            }

            int next = GetNext(number);
            int cycleNumberForNext = ProcessNumberRecursivly(next);
            _hash.Add(number, cycleNumberForNext + 1);

            return cycleNumberForNext + 1;
        }

        public int ProcessNumber(int number)
        {
            int cycleNumber;
            if (_hash.TryGetValue(number, out cycleNumber))
            {
                return cycleNumber;
            }
            
            _stack.Push(number);           

            while (_stack.Any())
            {
                int current = _stack.Peek();

                if (current == MinValue)
                {
                    _stack.Pop();
                }

                int next = GetNext(current);

                if (_hash.TryGetValue(next, out cycleNumber))
                {
                    _hash.Add(current, cycleNumber + 1);
                    _stack.Pop();
                }
                else
                {
                    _stack.Push(next);
                }
            }

            return _hash[number];
        }

        public int GetNext(int number)
        {           
            if (number % 2 == 0)
            {
                return number/2;
            }
            
            return number * 3 + 1;
        }

        private static void Validate(int start, int finish)
        {
            if (start > finish)
            {
                throw new ArgumentException("start > finish");
            }

            if (start < MinValue)
            {
                throw new ArgumentOutOfRangeException("start");
            }

            if (finish > MaxValue)
            {
                throw new ArgumentOutOfRangeException("finish");
            }
        }
    }
}
