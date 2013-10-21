using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.DynamicProgramming;
using NUnit.Framework;

namespace AlgClass.Tests
{
    [TestFixture]
    public class KnapsackAlgTests
    {
        [Test]
        public void Case1()
        {
            var data = new[]
                {
                    new Tuple<int, int>(8, 4),                    
                    new Tuple<int, int>(15, 8),
                    new Tuple<int, int>(4, 3),
                    new Tuple<int, int>(10, 5),
                };
            var alg = new KnapsackAlg();
            Assert.AreEqual(19, alg.CalcOptimalValue(data, 11));
        }

        [Test]
        public void Case2()
        {
            var data = new[]
                {
                    new Tuple<int, int>(3, 4),
                    new Tuple<int, int>(2, 3),
                    new Tuple<int, int>(4, 2),
                    new Tuple<int, int>(4, 3),
                };

            var alg = new KnapsackAlg();
            Assert.AreEqual(8, alg.CalcOptimalValue(data, 6));
        }
    }
}
