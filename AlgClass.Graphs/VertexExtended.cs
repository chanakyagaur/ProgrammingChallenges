using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;

namespace AlgClass.Graphs
{
    public class ExtendedVertex: Vertex
    {
        private readonly List<AdjacentEdge> _adjacentVertices;

        public ExtendedVertex(uint id, IEnumerable<AdjacentEdge> adjacentVertices)
            : base(id, null)
        {
            _adjacentVertices = adjacentVertices.ToList();
        }

        public ExtendedVertex(uint id):base(id, null)
        {  
            _adjacentVertices = new List<AdjacentEdge>();
        }

        public void AddAdjacenEdge(AdjacentEdge edge)
        {
            _adjacentVertices.Add(edge);
        }

        public new IEnumerable<AdjacentEdge> AdjacentVertices
        {
            get { return _adjacentVertices; }
        }
    }
}
