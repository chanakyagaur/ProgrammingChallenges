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
                if (UnionFind.FindRoot(mergedHead).Id == UnionFind.FindRoot(mergedTail).Id)
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
            int firstVerticeRootId = UnionFind.FindRoot(_vertices.First()).Id;
            var hashSet = new HashSet<int>(_vertices.Where(v => UnionFind.FindRoot(v).Id == firstVerticeRootId).Select(v => v.Id));
            var minCut = _edges.Count(e => hashSet.Contains(e.Head) && !hashSet.Contains(e.Tail));
            return minCut;
        }        

        private static void Swap<T>(T[] edges, int leftIndex, int rightIndex)
        {
            var temp = edges[leftIndex];
            edges[leftIndex] = edges[rightIndex];
            edges[rightIndex] = temp;
        }

        private void MergeVertices(Vertex mergedHead, Vertex mergedTail)
        {
            UnionFind.Union(mergedHead, mergedTail);
        }
    }
}
