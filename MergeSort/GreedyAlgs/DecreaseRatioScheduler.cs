using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass.GreedyAlgs
{
    public class DecreaseRatioScheduler : OrderSchedulerBase
    {       
        protected override decimal GetRank(Job job)
        {
            return job.Weight / job.Length;
        }
    }
}
