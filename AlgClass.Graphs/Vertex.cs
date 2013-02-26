using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass.Graphs
{
    public class Vertex : IComparable<Vertex>
    {
        public int CompareTo(Vertex other)
        {
            return Id.CompareTo(other.Id);
        }

        private readonly uint[] _adjacentVertices;

        public Vertex(uint id, uint[] adjacentVertices)
        {
            Id = id;
            _adjacentVertices = adjacentVertices;
            Parent = this;
            Rank = 0;
        }

        public uint[] AdjacentVertices
        {
            get { return _adjacentVertices; }
        }

        public Vertex Parent { get; set; }
        
        public uint Rank { get; set; }

        public uint Id { get; private set; }
    }
}
