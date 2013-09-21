using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;
using NUnit.Framework;

namespace MinPathConsole
{
    [TestFixture]
    class DijkstraAlgorithmTests
    {
        [Test]
        public void TestCase1()
        {
            var vertices = new ExtendedVertex[]
                {
                    new ExtendedVertex(1, new AdjacentEdge[]
                        {
                            new AdjacentEdge(2,10), 
                            new AdjacentEdge(4,30), 
                            new AdjacentEdge(5,100), 
                        }), 
                    new ExtendedVertex(2, new AdjacentEdge[]
                    {
                        new AdjacentEdge(3,50), 
                    }), 
                    new ExtendedVertex(3, new AdjacentEdge[]
                        {
                            new AdjacentEdge(5,10), 
                        }), 
                    new ExtendedVertex(4, new AdjacentEdge[]
                    {
                        new AdjacentEdge(3,20), 
                        new AdjacentEdge(5,50), 
                    }), 
                    new ExtendedVertex(5, new AdjacentEdge[0]), 
                };

            var alg = new DijkstraAlgorithm(vertices);
            var minPaths = alg.CalculateMinPath();
            Assert.AreEqual(5, minPaths.Length);
            Assert.AreEqual("0,10,50,30,60", string.Join(",", minPaths));
        }

        [Test]
        public void TestCase2()
        {
            var vertices = new ExtendedVertex[]
                {
                    new ExtendedVertex(1, new AdjacentEdge[]
                        {
                            new AdjacentEdge(2,50), 
                            new AdjacentEdge(3,10), 
                            new AdjacentEdge(5,45), 
                        }), 
                    new ExtendedVertex(2, new AdjacentEdge[]
                    {
                        new AdjacentEdge(5,10), 
                    }), 
                    new ExtendedVertex(3, new AdjacentEdge[]
                        {
                            new AdjacentEdge(1,20), 
                            new AdjacentEdge(4,15), 
                        }), 
                    new ExtendedVertex(4, new AdjacentEdge[]
                    {
                        new AdjacentEdge(2,20), 
                        new AdjacentEdge(5,35), 
                    }), 
                    new ExtendedVertex(5, new AdjacentEdge[]
                        {
                            new AdjacentEdge(4,30), 
                        }), 
                    new ExtendedVertex(6, new AdjacentEdge[]
                        {
                            new AdjacentEdge(4,3), 
                        }), 
                };

            var alg = new DijkstraAlgorithm(vertices);
            Assert.AreEqual("0,45,10,25,45,1000000", string.Join(",", alg.CalculateMinPath()));
            Assert.AreEqual("1000000,50,1000000,30,0,1000000", string.Join(",", alg.CalculateMinPath(5)));
            Assert.AreEqual("1000000,23,1000000,3,33,0", string.Join(",", alg.CalculateMinPath(6)));
        }
    }
}
