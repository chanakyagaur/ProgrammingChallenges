using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlgClass
{
    [TestFixture]
    public class MedianMaintenenceAlgTests
    {
        [Test]
        public void Test()
        {
            Assert.AreEqual(50, MedianMaintenenceAlg.CalculateMedianSum(new int[] {9,6,14,19,8,4}));
        }
    }
}
