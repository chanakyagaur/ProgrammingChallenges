using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;

namespace AlgClass
{
    public class KosarajuAlgorithm 
    {
        private KosarajuVertex[] _vertices;
        private int _exploredVerticesCount;
        private KosarajuVertex _currentSource = null;
        private readonly Stack<KosarajuVertex> _searchStack;

        public KosarajuAlgorithm()
        {            
            _searchStack = new Stack<KosarajuVertex>(); 
        }

        public int[] CountStronglyConnectedComponentes(KosarajuVertex[] vertices)
        {
            _vertices = vertices;
            Func<int, KosarajuVertex> selectByIndex = index => _vertices[index];
            Func<int, KosarajuVertex> selectByFinishingTime = index => _vertices[index].FinishTimeVertex;
            Func<KosarajuVertex, IEnumerable<int>> reversedNodeSelector = v => v.ReversedAdjacentVertices;
            Func<KosarajuVertex, IEnumerable<int>> nodeSelector = v => v.AdjacentVertices;

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


        private void DepthFirstSearchLoop(Func<int, KosarajuVertex> nodeSelector, Func<KosarajuVertex, IEnumerable<int>> adjacentNodesSelector)
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

        private void DepthFirstSearch(Func<KosarajuVertex, IEnumerable<int>> adjacentNodesSelector)
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
