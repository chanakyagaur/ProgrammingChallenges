using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;
using NUnit.Framework;

namespace AlgClass
{
    [TestFixture]
    class KosarajuAlgorithmTests
    {
        [Test]
        public void ThreeNodeTest()
        {
            var vertices = new KosarajuVertex[]
                {
                    new KosarajuVertex(1, new int[]{2}, new int[]{3} ), 
                    new KosarajuVertex(2, new int[]{3}, new int[]{1} ), 
                    new KosarajuVertex(3, new int[]{1}, new int[]{2} ), 
                };
            var alg = new KosarajuAlgorithm();
            var result = alg.CountStronglyConnectedComponentes(vertices);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(3, result[0]);
        }

        [Test]
        public void TestCaseFromLecture()
        {
            var vertices = new KosarajuVertex[]
                {
                    new KosarajuVertex(1, new int[]{4}, new int[]{7} ), 
                    new KosarajuVertex(2, new int[]{8}, new int[]{5} ), 
                    new KosarajuVertex(3, new int[]{6}, new int[]{9} ), 
                    new KosarajuVertex(4, new int[]{7}, new int[]{1} ), 
                    new KosarajuVertex(5, new int[]{2}, new int[]{8} ), 
                    new KosarajuVertex(6, new int[]{9}, new int[]{3,8} ), 
                    new KosarajuVertex(7, new int[]{1}, new int[]{4,9} ), 
                    new KosarajuVertex(8, new int[]{5,6}, new int[]{2} ), 
                    new KosarajuVertex(9, new int[]{3,7}, new int[]{6} ), 
                };
            var alg = new KosarajuAlgorithm();
            var result = alg.CountStronglyConnectedComponentes(vertices);
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual(3, result[0]);
            Assert.AreEqual(3, result[1]);
            Assert.AreEqual(3, result[2]);
        }
    }
}
