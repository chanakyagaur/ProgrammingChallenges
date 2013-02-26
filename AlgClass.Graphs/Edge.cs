using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass.Graphs
{
    public class Edge
    {
        public Edge(uint head, uint tail)
        {
            Head = head;
            Tail = tail;
        }

        public uint Head { get; private set; }
        public uint Tail { get; private set; }
    }
}
