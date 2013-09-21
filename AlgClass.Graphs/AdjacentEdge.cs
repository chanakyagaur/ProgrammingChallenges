using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass.Graphs
{
    public class AdjacentEdge
    {
        public AdjacentEdge(uint vertex, int weight)
        {
            Vertex = vertex;
            Weigth = weight;
        }
        public uint Vertex { get; private set; }
        public int Weigth { get; private set; }
    }
}
