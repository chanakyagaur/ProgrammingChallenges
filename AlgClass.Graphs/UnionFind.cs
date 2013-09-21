using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass.Graphs
{
    /// <summary>
    /// UnionFind implementation: http://www.algorithmist.com/index.php/Union_Find
    /// </summary>
    public static class UnionFind
    {
        private static readonly Random Random = new Random();

        public static Vertex FindRoot(Vertex start)
        {
            var element = start;
            while (element.Parent != element)
            {
                element = element.Parent;
            }
            return element;
        }

        public static void Union(Vertex left, Vertex right)
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
    }
}
