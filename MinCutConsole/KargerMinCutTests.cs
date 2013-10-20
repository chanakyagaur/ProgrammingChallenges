using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;
using MinCutConsole;
using NUnit.Framework;

namespace MinCutConsole
{
    [TestFixture]
    class KargerMinCutTests
    {
        [Test]
        public void FourVertices()
        {
            var vertices = new Vertex[]
                {
                    new Vertex(1, new [] {2, 4, 3}),
                    new Vertex(2, new [] {1, 3}),
                    new Vertex(3, new [] {1, 2}),
                    new Vertex(4, new [] {1})
                };
            var alg = new KargerMinCut(vertices);
            var minCut = Enumerable.Range(1, 32).Select(i => alg.CalculateMinCut()).Min();
            Assert.AreEqual(1, minCut);
        }

        [Test]
        public void EigthVertices()
        {
            var vertices = new Vertex[]
            {
                    new Vertex(1, new [] {5, 2, 6}),
                    new Vertex(2, new [] {1, 5, 6, 3}),
                    new Vertex(3, new [] {2, 7, 4, 8}),
                    new Vertex(4, new [] {3, 7, 8}),
                    new Vertex(5, new [] {1, 2, 6}),
                    new Vertex(6, new [] {1, 2, 5, 7}),
                    new Vertex(7, new [] {6, 3, 4, 8}),
                    new Vertex(8, new [] {3, 4, 7}),
                };

            var alg = new KargerMinCut(vertices);
            var minCut = Enumerable.Range(1, 200).Select(i => alg.CalculateMinCut()).Min();
            Assert.AreEqual(2, minCut);
        }
    }
}
