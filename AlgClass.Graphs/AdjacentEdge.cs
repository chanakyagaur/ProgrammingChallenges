using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass.Graphs
{
    public class AdjacentEdge
    {
        public AdjacentEdge(int vertex, int weight)
        {
            Vertex = vertex;
            Weigth = weight;
        }
        public int Vertex { get; private set; }
        public int Weigth { get; private set; }
    }
}
