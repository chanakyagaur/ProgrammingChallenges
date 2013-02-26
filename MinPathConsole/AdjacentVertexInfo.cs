using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPathConsole
{
    class AdjacentVertexInfo
    {
        public AdjacentVertexInfo(uint id, uint weight)
        {
            Id = id;
            Weigth = weight;
        }
        public uint Id { get; private set; }
        public uint Weigth { get; private set; }
    }
}
