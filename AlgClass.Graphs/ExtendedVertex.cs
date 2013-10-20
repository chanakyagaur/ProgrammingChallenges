using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass.Graphs
{
    public class KosarajuVertex: Vertex 
    {
        private readonly List<int> _reversedAdjacentVertices;
        private readonly List<int> _adjacentVertices;

        public KosarajuVertex(int id): base(id, null)
        {
            _reversedAdjacentVertices = new List<int>();
            _adjacentVertices = new List<int>();
        }

        public KosarajuVertex(int id, IEnumerable<int> adjacentVertices, IEnumerable<int> reversedAdjVertices)
            : base(id, null)
        {
            _reversedAdjacentVertices = new List<int>(adjacentVertices);
            _adjacentVertices = new List<int>(reversedAdjVertices);
        }

        public KosarajuVertex FinishTimeVertex { get; set; }

        public bool Explored { get; set; }

        public List<int> ReversedAdjacentVertices
        {
            get { return _reversedAdjacentVertices; }
        }

        public new List<int> AdjacentVertices
        {
            get { return _adjacentVertices; }
        }


    }
}
