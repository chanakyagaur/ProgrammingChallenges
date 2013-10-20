using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass.DynamicProgramming
{
    public class TSPAlg
    {
        private float[][] Graph;
        private Dictionary<string, float>[] A;

        public int CalcMinCostTour(Tuple<float, float>[] input)
        {
            if (input == null)
                throw new ArgumentNullException("input");
            
            int n = input.Length;

            FulfillGraph(input, n);

            A = new Dictionary<string, float>[n + 1];
            for (int i = 1; i <= n; i++)
            {
                A[i] = new Dictionary<string, float>();
                A[1][i.ToString()] = float.MaxValue;
                A[i][""] = float.MaxValue;
            }

            A[1][""] = 0;

            for (int m = 2; m <= n; m++)
            {
                Console.WriteLine("subproblem size of {0} started", m);
                var subsets = Enumerable.Range(2, n - 1).Combinations(m - 1);
                foreach (IEnumerable<int> subset in subsets)
                {
                    string s = string.Concat(subset.Select(x => x.ToString()));
                    for (int j = 2; j <= n; j++)
                    {
                        float minValue = float.MaxValue;
                        var subsetWithoutJ = s.Replace(j.ToString(), "");
                        for (int k = 1; k <= n; k++)
                        {
                            if (k == j)
                                continue;

                            float value; // = A[k][subsetWithoutJ];
                            if (!A[k].TryGetValue(subsetWithoutJ, out value))
                                continue;

                            if (minValue > (value + Graph[j - 1][k - 1]))
                            {
                                minValue = value + Graph[j - 1][k - 1];
                            }                            
                        }

                        A[j][s] = minValue;

                    }
                }

            }

            float result = float.MaxValue;
            string set = string.Concat(Enumerable.Range(2, n - 1).Select(x => x.ToString()));
            for (int j = 2; j <= n; j++)
            {
                if (result > (A[j][set] + Graph[j - 1][0]))
                {
                    result = A[j][set] + Graph[j - 1][0];
                }
            }

            return (int)result;
        }

        private void FulfillGraph(Tuple<float, float>[] input, int n)
        {
            Graph = new float[n][];
            for (int i = 0; i < n; i++)
            {
                Graph[i] = new float[n];
                for (int j = 0; j < n; j++)
                {
                    Graph[i][j] = (i == j) ? 0 : CalcEuclideanDistance(input[i], input[j]);
                }
            }
        }
        
        private float CalcEuclideanDistance(Tuple<float, float> x, Tuple<float, float> y)
        {
            return (float)(Math.Sqrt(Math.Pow((x.Item1 - y.Item1), 2) + Math.Pow(x.Item2 - y.Item2, 2)));
        }
    }
}
