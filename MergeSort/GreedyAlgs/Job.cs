using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass.GreedyAlgs
{
    public class Job
    {
        public Job(decimal weight, decimal length)
        {
            Weight = weight;
            Length = length;
        }

        public decimal Weight { get; private set; }
        public decimal Length { get; private set; }
    }
}
