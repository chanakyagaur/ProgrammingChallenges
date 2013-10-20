using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;

namespace AlgClass
{
    public class TwoSetAlg
    {
        private readonly KosarajuAlgorithm kosarajuSCC;
        private int _verticesCount;
        public TwoSetAlg()
        {
                kosarajuSCC = new KosarajuAlgorithm();
        }

        public bool IsSatisfiable(int verticesCount, Tuple<int, int>[] clauses)
        {
            _verticesCount = verticesCount;

            var vertices = Enumerable.Range(0, 2 * verticesCount).Select(nodeId => new KosarajuVertex(nodeId)).ToArray();

            clauses.ForEach(edge =>
                {
                    AddEdge(vertices, -edge.Item1, edge.Item2);
                    AddEdge(vertices, -edge.Item2, edge.Item1);
                });

            kosarajuSCC.CountStronglyConnectedComponentes(vertices);

            for (int i = 1; i <= verticesCount; i++)
            {
                if (vertices[GetIndexById(i)].Parent.Id.Equals(vertices[GetIndexById(-i)].Parent.Id))
                    return false;
            }
                
            return true;
        }

        private void AddEdge(KosarajuVertex[] vertices, int firstVertexId, int secondVertexId)
        {
            vertices[GetIndexById(firstVertexId)].AdjacentVertices.Add(GetIndexById(secondVertexId) + 1);
            vertices[GetIndexById(secondVertexId)].ReversedAdjacentVertices.Add(GetIndexById(firstVertexId) + 1);
        }

        private int GetIndexById(int vertexId)
        {
            if (vertexId < 0)
            {
                return _verticesCount - vertexId - 1;
            }

            return vertexId - 1;
        }
    }
}
