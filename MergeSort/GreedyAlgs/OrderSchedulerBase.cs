using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass.GreedyAlgs
{
    public abstract class OrderSchedulerBase : IComparer<Job>
    {
        public decimal CalcWeightedSum(Job[] jobs)
        {
            if (jobs == null) throw new ArgumentNullException("jobs");

            Array.Sort(jobs, this);
            var sum = CalcWeightedSumInOrder(jobs);

            return sum;
        }

        private decimal CalcWeightedSumInOrder(IEnumerable<Job> orderBy)
        {
            decimal currentLength = 0;
            decimal result = 0;
            foreach (var job in orderBy)
            {
                currentLength += job.Length;
                result += currentLength * job.Weight;
            }

            return result;
        }

        public int Compare(Job x, Job y)
        {
            if (GetRank(x) == GetRank(y))
            {
                return x.Weight > y.Weight ? -1 : 1;
            }

            if (GetRank(x) > GetRank(y))
                return -1;

            return 1;
        }

        protected abstract decimal GetRank(Job job);
    }
}
