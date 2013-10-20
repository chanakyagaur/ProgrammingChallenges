using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;

namespace AlgClass.GreedyAlgs
{
    public class PrimMST
    {
        public decimal CalcMSTLength(ExtendedVertex[] vertices)
        {
            var startVertex = new Random().Next(1, vertices.Length);
            var mst = new HashSet<int> {startVertex};
            decimal mstLength = 0;
            while (mst.Count < vertices.Length)
            {
                //select min edge
                //foreach edge with one vertex in mst and another not select min
                decimal minWeight = decimal.MaxValue;
                int mstVetrexIndex = int.MaxValue;
                foreach (int vertexIndex in mst)
                {
                    foreach (AdjacentEdge edge in vertices[vertexIndex - 1].AdjacentVertices)
                    {
                        if (!mst.Contains(edge.Vertex))
                        {
                            if (edge.Weigth < minWeight)
                            {
                                minWeight = edge.Weigth;
                                mstVetrexIndex = edge.Vertex;
                            }
                        }
                    }
                }

                //add vertex to mst
                mst.Add(mstVetrexIndex);
                // updated mstLength
                mstLength += minWeight;
            }
            return mstLength;
        }
    }
}
