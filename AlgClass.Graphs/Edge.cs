using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass.Graphs
{
    public class Edge
    {
        public Edge(int head, int tail)
        {
            Head = head;
            Tail = tail;
        }

        public int Head { get; private set; }
        public int Tail { get; private set; }
    }
}
