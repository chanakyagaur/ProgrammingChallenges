using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;

namespace MinPathConsole
{
    class ExtendedVertex: Vertex
    {
        private readonly AdjacentVertexInfo[] _adjacentVertices;

        public ExtendedVertex(uint id, AdjacentVertexInfo[] adjacentVertices)
            : base(id, null)
        {
            _adjacentVertices = adjacentVertices;
        }

        public new AdjacentVertexInfo[] AdjacentVertices
        {
            get { return _adjacentVertices; }
        }
    }
}
