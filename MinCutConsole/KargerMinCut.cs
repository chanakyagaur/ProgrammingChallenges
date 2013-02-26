using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;

namespace MinCutConsole
{
    public class KargerMinCut
    {
        private readonly Edge[] _edges;
        private static readonly Random Random = new Random();
        private readonly Vertex[] _vertices;

        public KargerMinCut(Vertex[] vertices)
        {
            _vertices = vertices;
            _edges = vertices.SelectMany(v => v.AdjacentVertices.Select(adjV => new Edge(v.Id, adjV))).ToArray();
        }
        public int CalculateMinCut()
        {
            Array.ForEach(_vertices, v =>
            {
                v.Parent = v;
                v.Rank = 0;
            });

            int mergedVertices = 0;
            int randomRange = _edges.Length - 1;
            while(randomRange >= 0)
            {
                int randomEdgeIndex = Random.Next(0, randomRange);
                Edge selectedEdge = _edges[randomEdgeIndex];
                Vertex mergedHead = _vertices[selectedEdge.Head - 1];
                Vertex mergedTail = _vertices[selectedEdge.Tail - 1];
                //skip if self loop  
                if (FindRoot(mergedHead).Id == FindRoot(mergedTail).Id)
                {
                    Swap(_edges, randomEdgeIndex, randomRange);
                    randomRange--;
                    continue;
                }

                //merge adjacent vertices
                MergeVertices(mergedHead, mergedTail);
                mergedVertices++;
                if (mergedVertices == _vertices.Length - 2)
                {
                    break;
                }

                Swap(_edges, randomEdgeIndex, randomRange);
                randomRange--;
            }
            // calculate min cut for vertice list            
            uint firstVerticeRootId = FindRoot(_vertices.First()).Id;
            var hashSet = new HashSet<uint>(_vertices.Where(v => FindRoot(v).Id == firstVerticeRootId).Select(v => v.Id));
            var minCut = _edges.Count(e => hashSet.Contains(e.Head) && !hashSet.Contains(e.Tail));
            return minCut;
        }

        #region UnionFind implementation: http://www.algorithmist.com/index.php/Union_Find

        private static Vertex FindRoot(Vertex start)
        {
            var element = start;
            while (element.Parent != element)
            {
                element = element.Parent;
            }
            return element;
        }

        private static void Union(Vertex left, Vertex right)
        {
            var leftRoot = FindRoot(left);
            var rightRoot = FindRoot(right);
            if (leftRoot.Id != rightRoot.Id)
            {
                int compare = leftRoot.Rank.CompareTo(rightRoot.Rank);
                if (compare < 0)
                {
                    leftRoot.Parent = rightRoot;
                }
                else if (compare > 0)
                {
                    rightRoot.Parent = leftRoot;
                }
                else
                {
                    if (Random.Next(0, 1) == 0)
                    {
                        leftRoot.Parent = rightRoot;
                        rightRoot.Rank++;
                    }
                    else
                    {
                        rightRoot.Parent = leftRoot;
                        leftRoot.Rank++;
                    }
                }
            }
        }

        #endregion

        private static void Swap<T>(T[] edges, int leftIndex, int rightIndex)
        {
            var temp = edges[leftIndex];
            edges[leftIndex] = edges[rightIndex];
            edges[rightIndex] = temp;
        }

        private void MergeVertices(Vertex mergedHead, Vertex mergedTail)
        {
            Union(mergedHead, mergedTail);
        }
    }
}
