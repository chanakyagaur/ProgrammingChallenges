using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.GreedyAlgs;
using NUnit.Framework;

namespace AlgClass.Tests
{
    [TestFixture]
    public class DecreaseRatioSchedulerTests
    {
        [Test]
        public void Schedule_DifferentLengthAdnWeigth_22WeightedSum()
        {
            var jobs = new Job[]
                {
                    new Job(1, 2),
                    new Job(3, 5),
                };
            var scheduler = new DecreaseRatioScheduler();

            // act
            var result = scheduler.CalcWeightedSum(jobs);

            Assert.AreEqual(22, result);
        }
    }
}
