using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;

namespace AlgClass.GreedyAlgs
{
    public class MaxSpaceClustering
    {
        public int CalcMaxSpacing(ExtendedVertex[] vertices, int clustersCount)
        {
            Array.ForEach(vertices, v =>
            {
                v.Parent = v;
                v.Rank = 0;
            });

            int mergeCount = 0;

            while (mergeCount < vertices.Length - clustersCount)
            {
                var minEdge = GetNextMinEdge(vertices);
                UnionFind.Union(vertices[minEdge.Item1 - 1], vertices[minEdge.Item2 - 1]);
                mergeCount++;
            }

            return CalcMaxSpacing(vertices);
        }

        public int CalcClusterings(Dictionary<string, Vertex> vertices)
        {
            foreach (var extendedVertex in vertices)
            {
                extendedVertex.Value.Parent = extendedVertex.Value;
                extendedVertex.Value.Rank = 0;
            }

            int mergeCount = vertices.Count;

            foreach(var vertex in vertices)
            {
                mergeCount = MergeAdjacentVertices(GetEdgeByOne(vertex.Key), vertices, vertex, mergeCount);
                mergeCount = MergeAdjacentVertices(GetEdgeByTwo(vertex.Key), vertices, vertex, mergeCount);
            }

            return mergeCount;
        }

        public static IEnumerable<string> GetEdgeByTwo(string key)
        {
            for (int i = 0; i < key.Length - 1; i++)
            {
                for (int j = i + 1; j < key.Length; j++)
                {
                    yield return key.ReplaceAt(i, ReverseValue(key[i])).ReplaceAt(j, ReverseValue(key[j]));  
                }                
            }
        }

        public static IEnumerable<string> GetEdgeByOne(string key)
        {
            for (int i = 0; i < key.Length; i++)
            {                
                yield return key.ReplaceAt(i, ReverseValue(key[i]));
            }
        }

        private static char ReverseValue(char value)
        {
            return (value == '0') ? '1' : '0';
        }

        private static int MergeAdjacentVertices(IEnumerable<string> verticeKeys, Dictionary<string, Vertex> vertices, KeyValuePair<string, Vertex> vertex, int mergeCount)
        {
            foreach (var verticeKey in verticeKeys)
            {
                Vertex adjacentVertex;
                if (vertices.TryGetValue(verticeKey, out adjacentVertex))
                {
                    if (UnionFind.FindRoot(vertices[vertex.Key]) != UnionFind.FindRoot(adjacentVertex))
                    {
                        UnionFind.Union(vertices[vertex.Key], adjacentVertex);
                        mergeCount--;
                    }
                }
            }
            return mergeCount;
        }

        private int CalcMaxSpacing(ExtendedVertex[] vertices)
        {
            var minEdge = GetNextMinEdge(vertices);

            return vertices[minEdge.Item1 - 1].AdjacentVertices.Single(x => x.Vertex == minEdge.Item2).Weigth;
        }

        private Tuple<uint, uint> GetNextMinEdge(ExtendedVertex[] vertices)
        {
            decimal minWeight = decimal.MaxValue;
            Tuple<uint, uint> nextMinEdge = null;
            foreach (var vertex in vertices)
            {
                foreach (AdjacentEdge edge in vertex.AdjacentVertices)
                {
                    if (UnionFind.FindRoot(vertex) != UnionFind.FindRoot(vertices[edge.Vertex - 1]))
                    {
                        if (edge.Weigth < minWeight)
                        {
                            minWeight = edge.Weigth;
                            nextMinEdge = new Tuple<uint, uint>(vertex.Id, edge.Vertex);
                        }
                    }
                }
            }
            return nextMinEdge;
        }
    }
}
