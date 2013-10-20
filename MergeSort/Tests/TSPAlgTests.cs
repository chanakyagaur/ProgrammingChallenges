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
    public class TSPAlgTests
    {
        [Test]
        public void TestCase1()
        {
            var input = new[]
                {
                    new Tuple<float, float>(38.24f, 20.42f),
                    new Tuple<float, float>(39.57f, 26.15f),
                    new Tuple<float, float>(40.56f, 25.32f),
                    new Tuple<float, float>(36.26f, 23.12f),
                    new Tuple<float, float>(33.48f, 10.54f),
                    new Tuple<float, float>(37.56f, 12.19f),
                    new Tuple<float, float>(38.42f, 13.11f),
                    new Tuple<float, float>(37.52f, 20.44f),
                };

            var alg = new TSPAlg();
            Assert.AreEqual(37, alg.CalcMinCostTour(input));
        }
    }
}
