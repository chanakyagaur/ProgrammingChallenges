using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SCCConsole
{
    [TestFixture]
    class KosarajuAlgorithmTests
    {
        [Test]
        public void ThreeNodeTest()
        {
            var vertices = new ExtendedVertex[]
                {
                    new ExtendedVertex(1, new uint[]{2}, new uint[]{3} ), 
                    new ExtendedVertex(2, new uint[]{3}, new uint[]{1} ), 
                    new ExtendedVertex(3, new uint[]{1}, new uint[]{2} ), 
                };
            var alg = new KosarajuAlgorithm(vertices);
            var result = alg.CountStronglyConnectedComponentes();
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(3, result[0]);
        }

        [Test]
        public void TestCaseFromLecture()
        {
            var vertices = new ExtendedVertex[]
                {
                    new ExtendedVertex(1, new uint[]{4}, new uint[]{7} ), 
                    new ExtendedVertex(2, new uint[]{8}, new uint[]{5} ), 
                    new ExtendedVertex(3, new uint[]{6}, new uint[]{9} ), 
                    new ExtendedVertex(4, new uint[]{7}, new uint[]{1} ), 
                    new ExtendedVertex(5, new uint[]{2}, new uint[]{8} ), 
                    new ExtendedVertex(6, new uint[]{9}, new uint[]{3,8} ), 
                    new ExtendedVertex(7, new uint[]{1}, new uint[]{4,9} ), 
                    new ExtendedVertex(8, new uint[]{5,6}, new uint[]{2} ), 
                    new ExtendedVertex(9, new uint[]{3,7}, new uint[]{6} ), 
                };
            var alg = new KosarajuAlgorithm(vertices);
            var result = alg.CountStronglyConnectedComponentes();
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(3, result[0]);
            Assert.AreEqual(3, result[1]);
            Assert.AreEqual(3, result[2]);
        }
    }
}
