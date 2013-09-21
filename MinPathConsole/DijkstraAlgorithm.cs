using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;

namespace MinPathConsole
{
    class DijkstraAlgorithm
    {
        private readonly ExtendedVertex[] _vertices;
        private uint[] _minPath;
        private List<ExtendedVertex> _processedVertices;
        private const uint UnreachableDestination = 1000000;

        public DijkstraAlgorithm(ExtendedVertex[] vertices )
        {
            _vertices = vertices;
        }

        public uint[] CalculateMinPath(int sourceNodeId = 1)
        {
            Initialize(sourceNodeId);

            for (int k = 0; k < _minPath.Length - 1; k++)
            {
                uint minPath = UnreachableDestination;
                ExtendedVertex nextSelectedNode = null;
                foreach (var processedNode in _processedVertices)
                {
                    foreach (var adjacentNodeInfo in processedNode.AdjacentVertices)
                    {
                        var adjacentNode = _vertices[adjacentNodeInfo.Vertex - 1];
                        if (!_processedVertices.Contains(adjacentNode))
                        {
                            if (minPath > _minPath[processedNode.Id - 1] + adjacentNodeInfo.Weigth)
                            {
                                minPath = _minPath[processedNode.Id - 1] + (uint)adjacentNodeInfo.Weigth;
                                nextSelectedNode = _vertices[adjacentNodeInfo.Vertex - 1];
                            }
                        }
                    }
                }
                if (nextSelectedNode == null)
                {
                    // remaining node are unreachable
                    break;
                }
                _processedVertices.Add(nextSelectedNode);
                _minPath[nextSelectedNode.Id - 1] = minPath;
            }

            return _minPath;
        }

        private void Initialize(int sourceNodeId)
        {
            _minPath = new uint[_vertices.Length];
            for (int i = 0; i < _minPath.Length; i++)
            {
                _minPath[i] = UnreachableDestination;
            }
            _minPath[sourceNodeId - 1] = 0;
            _processedVertices = new List<ExtendedVertex> {_vertices[sourceNodeId - 1]};
        }
    }
}
