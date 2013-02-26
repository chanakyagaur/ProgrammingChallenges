using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;

namespace SCCConsole
{
    public class ExtendedVertex: Vertex 
    {
        private readonly List<uint> _reversedAdjacentVertices;
        private readonly List<uint> _adjacentVertices;

        public ExtendedVertex(uint id): base(id, null)
        {
            _reversedAdjacentVertices = new List<uint>();
            _adjacentVertices = new List<uint>();
        }

        public ExtendedVertex(uint id, IEnumerable<uint> adjacentVertices, IEnumerable<uint> reversedAdjVertices)
            : base(id, null)
        {
            _reversedAdjacentVertices = new List<uint>(adjacentVertices);
            _adjacentVertices = new List<uint>(reversedAdjVertices);
        }

        public ExtendedVertex FinishTimeVertex { get; set; }

        public bool Explored { get; set; }

        public List<uint> ReversedAdjacentVertices
        {
            get { return _reversedAdjacentVertices; }
        }

        public new List<uint> AdjacentVertices
        {
            get { return _adjacentVertices; }
        }
    }
}
