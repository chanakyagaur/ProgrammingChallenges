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
    public class MaxSpaceClusteringTests
    {
        [Test]
        public void Assignment1_Case1()
        {
            var vertices = new ExtendedVertex[]
                {
                   new ExtendedVertex(1, new AdjacentEdge[]
                        {
                            new AdjacentEdge(2,1), 
                            new AdjacentEdge(3,1), 
                            new AdjacentEdge(4,2), 
                            new AdjacentEdge(5,2), 
                            new AdjacentEdge(6,2), 
                        }), 
                    new ExtendedVertex(2, new AdjacentEdge[]
                    {
                        new AdjacentEdge(1,1), 
                        new AdjacentEdge(3,1), 
                        new AdjacentEdge(4,2), 
                        new AdjacentEdge(5,2), 
                        new AdjacentEdge(6,2), 
                    }), 
                    new ExtendedVertex(3, new AdjacentEdge[]
                        {
                            new AdjacentEdge(1,1), 
                            new AdjacentEdge(2,1), 
                            new AdjacentEdge(4,2), 
                            new AdjacentEdge(5,2), 
                            new AdjacentEdge(6,2), 
                        }), 
                    new ExtendedVertex(4, new AdjacentEdge[]
                    {
                        new AdjacentEdge(1,2), 
                        new AdjacentEdge(2,2), 
                        new AdjacentEdge(3,2), 
                        new AdjacentEdge(5,2), 
                        new AdjacentEdge(6,2), 
                    }), 
                     new ExtendedVertex(5, new AdjacentEdge[]
                    {
                        new AdjacentEdge(1,2), 
                        new AdjacentEdge(2,2), 
                        new AdjacentEdge(3,2), 
                        new AdjacentEdge(4,2), 
                        new AdjacentEdge(6,2), 
                    }),
                     new ExtendedVertex(6, new AdjacentEdge[]
                    {
                        new AdjacentEdge(1,2), 
                        new AdjacentEdge(2,2), 
                        new AdjacentEdge(3,2), 
                        new AdjacentEdge(4,2), 
                        new AdjacentEdge(5,2), 
                    }),
                };

            var maxSpaceClustering = new MaxSpaceClustering();
            Assert.AreEqual(2, maxSpaceClustering.CalcMaxSpacing(vertices, 4));
        }

        [Test]
        public void Assignment1_Case2()
        {
            var vertices = Enumerable.Range(1, 10).Select(x => new ExtendedVertex(x)).ToArray();

            AddEdge(vertices, 1, 2, 91);
            AddEdge(vertices, 1, 3, 6);
            AddEdge(vertices, 1, 4, 31);
            AddEdge(vertices, 1, 5, 53);
            AddEdge(vertices, 1, 6, 15);
            AddEdge(vertices, 1, 7, 35);
            AddEdge(vertices, 1, 8, 83);
            AddEdge(vertices, 1, 9, 69);
            AddEdge(vertices, 1, 10, 78);
            AddEdge(vertices, 2, 3, 98);
            AddEdge(vertices, 2, 4, 58);
            AddEdge(vertices, 2, 5, 46);
            AddEdge(vertices, 2, 6, 53);
            AddEdge(vertices, 2, 7, 55);
            AddEdge(vertices, 2, 8, 74);
            AddEdge(vertices, 2, 9, 3);
            AddEdge(vertices, 2, 10, 34);

            AddEdge(vertices, 3, 4, 42);
            AddEdge(vertices, 3, 5, 4);
            AddEdge(vertices, 3, 6, 22);
            AddEdge(vertices, 3, 7, 84);
            AddEdge(vertices, 3, 8, 32);
            AddEdge(vertices, 3, 9, 74);
            AddEdge(vertices, 3, 10, 4);

            AddEdge(vertices, 4, 5, 94);
            AddEdge(vertices, 4, 6, 46);
            AddEdge(vertices, 4, 7, 92);
            AddEdge(vertices, 4, 8, 16);
            AddEdge(vertices, 4, 9, 65);
            AddEdge(vertices, 4, 10, 76);

            AddEdge(vertices, 5, 6, 5);
            AddEdge(vertices, 5, 7, 71);
            AddEdge(vertices, 5, 8, 17);
            AddEdge(vertices, 5, 9, 21);
            AddEdge(vertices, 5, 10, 73);

            AddEdge(vertices, 6, 7, 91);
            AddEdge(vertices, 6, 8, 36);
            AddEdge(vertices, 6, 9, 66);
            AddEdge(vertices, 6, 10, 59);

            AddEdge(vertices, 7, 8, 47);
            AddEdge(vertices, 7, 9, 9);
            AddEdge(vertices, 7, 10, 13);

            AddEdge(vertices, 8, 9, 51);
            AddEdge(vertices, 8, 10, 85);
            AddEdge(vertices, 9, 10, 2);


            var maxSpaceClustering = new MaxSpaceClustering();
            Assert.AreEqual(9, maxSpaceClustering.CalcMaxSpacing(vertices, 4));
        }

        private static void AddEdge(ExtendedVertex[] vertices, int left, int right, int weight)
        {
            vertices[left - 1].AddAdjacenEdge(new AdjacentEdge(right, weight));
            vertices[right - 1].AddAdjacenEdge(new AdjacentEdge(left, weight));
        }

        [Test]
        public void Assignment2_Case1()
        {
            var vertices = new Dictionary<string, Vertex>(10);

            AddDictionaryEdge(vertices, "0 1 1 0 0 1 1 1");
            AddDictionaryEdge(vertices, "1 1 0 0 1 0 1 1");
            AddDictionaryEdge(vertices, "1 0 1 1 1 0 0 1");
            AddDictionaryEdge(vertices, "1 1 1 1 0 0 1 0");
            AddDictionaryEdge(vertices, "0 0 1 1 0 0 1 1");
            AddDictionaryEdge(vertices, "0 0 0 1 1 0 1 1");
            AddDictionaryEdge(vertices, "1 1 0 0 1 1 1 1");
            AddDictionaryEdge(vertices, "1 0 1 1 1 1 1 0");
            AddDictionaryEdge(vertices, "1 0 0 0 0 1 1 0");
            AddDictionaryEdge(vertices, "0 1 0 0 0 0 1 1");

            var maxSpaceClustering = new MaxSpaceClustering();
            Assert.AreEqual(6, maxSpaceClustering.CalcClusterings(vertices));
        }

        private static void AddDictionaryEdge(Dictionary<string, Vertex> vertices, string key)
        {
            vertices.Add(key.Replace(" ", string.Empty), new Vertex(vertices.Count + 1));
        }

        [Test]
        public void GetEdgeByOne_2bits()
        {
            var result = MaxSpaceClustering.GetEdgeByOne("10").ToArray();

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual("00", result[0]);
            Assert.AreEqual("11", result[1]);
        }

        [Test]
        public void GetEdgeByTwo_3bits()
        {
            var result = MaxSpaceClustering.GetEdgeByTwo("100").ToArray();

            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("010", result[0]);
            Assert.AreEqual("001", result[1]);
            Assert.AreEqual("111", result[2]);
        }
    }
}
