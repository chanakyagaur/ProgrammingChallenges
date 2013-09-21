using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;
using AlgClass.GreedyAlgs;
using NUnit.Framework;

namespace AlgClass.Tests
{
    [TestFixture]
    public class PrimMSTTests
    {
        [Test]
        public void Case1()
        {
            var vertices = new ExtendedVertex[]
                {
                    new ExtendedVertex(1, new AdjacentEdge[]
                        {
                            new AdjacentEdge(2,1), 
                            new AdjacentEdge(3,3), 
                            new AdjacentEdge(4,4), 
                        }), 
                    new ExtendedVertex(2, new AdjacentEdge[]
                    {
                        new AdjacentEdge(1,1), 
                        new AdjacentEdge(3,2), 
                    }), 
                    new ExtendedVertex(3, new AdjacentEdge[]
                        {
                            new AdjacentEdge(4,5), 
                            new AdjacentEdge(2,2), 
                        }), 
                    new ExtendedVertex(4, new AdjacentEdge[]
                    {
                        new AdjacentEdge(1,4), 
                        new AdjacentEdge(3,5), 
                    }), 
                };

            var primAlg = new PrimMST();
            Assert.AreEqual(7, primAlg.CalcMSTLength(vertices));
        }

        [Test]
        public void Case2()
        {
            var vertices = new ExtendedVertex[]
                {
                    new ExtendedVertex(1, new AdjacentEdge[]
                        {
                            new AdjacentEdge(2,6), 
                            new AdjacentEdge(3,3), 
                            new AdjacentEdge(4,-14), 
                        }), 
                    new ExtendedVertex(2, new AdjacentEdge[]
                    {
                        new AdjacentEdge(1,6), 
                        new AdjacentEdge(4,8), 
                    }), 
                    new ExtendedVertex(3, new AdjacentEdge[]
                        {
                            new AdjacentEdge(4,12), 
                            new AdjacentEdge(1,3), 
                        }), 
                    new ExtendedVertex(4, new AdjacentEdge[]
                    {
                        new AdjacentEdge(1,-14), 
                        new AdjacentEdge(3,12), 
                        new AdjacentEdge(5,-5), 
                    }), 
                    new ExtendedVertex(5, new AdjacentEdge[]
                    {
                        new AdjacentEdge(4,-5), 
                    }), 
                };

            var primAlg = new PrimMST();
            Assert.AreEqual(-10, primAlg.CalcMSTLength(vertices));
        }
    }
}
