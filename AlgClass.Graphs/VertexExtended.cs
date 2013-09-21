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
        private readonly AdjacentEdge[] _adjacentVertices;

        public ExtendedVertex(uint id, AdjacentEdge[] adjacentVertices)
            : base(id, null)
        {
            _adjacentVertices = adjacentVertices;
        }

        public new AdjacentEdge[] AdjacentVertices
        {
            get { return _adjacentVertices; }
        }
    }
}
