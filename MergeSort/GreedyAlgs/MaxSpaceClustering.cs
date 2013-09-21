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
