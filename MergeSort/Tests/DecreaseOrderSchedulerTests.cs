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
    public class DecreaseOrderSchedulerTests
    {
        [Test]
        public void Schedule_DifferentLengthAdnWeigth_23WeightedSum()
        {
            var jobs = new Job[]
                {
                    new Job(1, 2),
                    new Job(3, 5),
                };
            var scheduler = new DecreaseOrderScheduler();
            
            // act
            var result = scheduler.CalcWeightedSum(jobs);

            Assert.AreEqual(23, result);
        }

        [Test]
        public void Schedule_EqualDifference_12WeightedSum()
        {
            var jobs = new Job[]
                {
                    new Job(1, 2),
                    new Job(2, 3),
                };

            var scheduler = new DecreaseOrderScheduler();

            // act
            Assert.AreEqual(11, scheduler.CalcWeightedSum(jobs));
            Assert.AreEqual(11, scheduler.CalcWeightedSum(jobs.Reverse().ToArray()));
        }
    }
}
