using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;

namespace SCCConsole
{
    class KosarajuAlgorithm
    {
        private readonly ExtendedVertex[] _vertices;
        private int _exploredVerticesCount;
        private ExtendedVertex _currentSource = null;
        private readonly Stack<ExtendedVertex> _searchStack; 

        public KosarajuAlgorithm(ExtendedVertex[] vertices)
        {
            _vertices = vertices;
            _searchStack = new Stack<ExtendedVertex>(); 
        }

        public int[] CountStronglyConnectedComponentes()
        {
            Func<int, ExtendedVertex> selectByIndex = index => _vertices[index];
            Func<int, ExtendedVertex> selectByFinishingTime = index => _vertices[index].FinishTimeVertex;
            Func<ExtendedVertex, IEnumerable<uint>> reversedNodeSelector = v => v.ReversedAdjacentVertices;
            Func<ExtendedVertex, IEnumerable<uint>> nodeSelector = v => v.AdjacentVertices;

            _exploredVerticesCount = 0;
            DepthFirstSearchLoop(selectByIndex, reversedNodeSelector);
            _exploredVerticesCount = -1;
            DepthFirstSearchLoop(selectByFinishingTime, nodeSelector);

            int[] sccCounter = _vertices.GroupBy(v => v.Parent.Id)
                .Select(grouping => grouping.Count())
                .OrderByDescending(count => count)
                .Take(5)
                .ToArray();
            
            return sccCounter;
        }


        private void DepthFirstSearchLoop(Func<int, ExtendedVertex> nodeSelector, Func<ExtendedVertex, IEnumerable<uint>> adjacentNodesSelector)
        {
            Array.ForEach(_vertices, v =>
                {
                    v.Explored = false;
                    v.Parent = v;
                });            

            for (int nodeIndex = _vertices.Length - 1; nodeIndex >= 0; nodeIndex--)
            {
                var node = nodeSelector(nodeIndex);
                if (!node.Explored)
                {
                    _currentSource = node;
                    _searchStack.Push(node);
                    DepthFirstSearch(adjacentNodesSelector);
                }
            }
        }

        private void DepthFirstSearch(Func<ExtendedVertex, IEnumerable<uint>> adjacentNodesSelector)
        {
            while (_searchStack.Any())
            {
                var node = _searchStack.Peek();
                node.Explored = true;
                node.Parent = _currentSource;
                bool backtracked = true;
                var adjacentNodes = adjacentNodesSelector(node);
                foreach (int adjacentNodeIndex in adjacentNodes)
                {
                    var adjacentNode = _vertices[adjacentNodeIndex - 1];
                    if (!adjacentNode.Explored)
                    {
                        backtracked = false;
                        _searchStack.Push(adjacentNode);
                        break;
                    }
                }
                if (backtracked)
                {
                    if (_exploredVerticesCount >= 0)
                    {
                        _exploredVerticesCount++;
                        // filling this way we remove necessity to sort vertices by finish time
                        _vertices[_exploredVerticesCount - 1].FinishTimeVertex = node;
                    }
                    _searchStack.Pop();
                }
            }
        }
    }
}
