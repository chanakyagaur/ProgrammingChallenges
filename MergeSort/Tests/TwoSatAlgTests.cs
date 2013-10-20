using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlgClass.Tests
{
    [TestFixture]
    public class TwoSatAlgTests
    {
        [Test]
        public void IsSatisfiable_FourVariables4Clauses_Satisfiable()
        {
            var clauses = new Tuple<int, int>[]
                {
                    new Tuple<int, int>(1, 2),
                    new Tuple<int, int>(3, 4),
                    new Tuple<int, int>(-1, -3),
                    new Tuple<int, int>(-2, -4),
                };

            var alg = new TwoSetAlg();
            Assert.True(alg.IsSatisfiable(4, clauses));
        }

        [Test]
        public void IsSatisfiable_EightVariables8Clauses_Satisfiable()
        {
            var clauses = new Tuple<int, int>[]
                {
                    new Tuple<int, int>(1, 4),
                    new Tuple<int, int>(-2, 5),
                    new Tuple<int, int>(3, 7),
                    new Tuple<int, int>(-8, -2),
                    new Tuple<int, int>(4, -3),
                    new Tuple<int, int>(5, -4),
                    new Tuple<int, int>(6, 7),
                    new Tuple<int, int>(-7, -1),
                };

            var alg = new TwoSetAlg();
            Assert.True(alg.IsSatisfiable(8, clauses));
        }

        [Test]
        public void IsSatisfiable_FiveVariables5Clauses_NotSatisfiable()
        {
            var clauses = new Tuple<int, int>[]
                {
                    new Tuple<int, int>(-1, -2),
                    new Tuple<int, int>(2, -1),
                    new Tuple<int, int>(1, -3),
                    new Tuple<int, int>(3, 1),
                    new Tuple<int, int>(4, 5),
                };

            var alg = new TwoSetAlg();
            Assert.False(alg.IsSatisfiable(5, clauses));
        }
    }
}
