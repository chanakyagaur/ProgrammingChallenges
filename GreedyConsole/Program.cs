using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;
using AlgClass.GreedyAlgs;

namespace GreedyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() == 2)
            {
                string alg = args[0];

                if (string.Equals(alg, "schedule", StringComparison.OrdinalIgnoreCase))
                {
                    ScheduleProblem(args[1]);
                }
                
                if (string.Equals(alg, "prim", StringComparison.OrdinalIgnoreCase))
                {
                    PrimMST(args[1]);
                }

                if (string.Equals(alg, "clustering", StringComparison.OrdinalIgnoreCase))
                {
                    MaxSpaceClustering(args[1]);
                }
            }

            Console.WriteLine("press any key");
            Console.ReadKey();
        }

        private static void PrimMST(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            int verticesCount = int.Parse(lines[0].Split(' ').First());
            var vertices = Enumerable.Range(1, verticesCount).Select(x => new ExtendedVertex((uint)x)).ToArray();
            
            foreach (var line in lines.Skip(1))
            {
                var node = line.Split(new[] {' ', '\t', ','}, StringSplitOptions.RemoveEmptyEntries);
                var left = uint.Parse(node[0]);
                var right = uint.Parse(node[1]);
                var weight = int.Parse(node[2]);
                vertices[left - 1].AddAdjacenEdge(new AdjacentEdge(right, weight));
                vertices[right - 1].AddAdjacenEdge(new AdjacentEdge(left, weight));
            }

            var primAlg = new PrimMST();

            Console.WriteLine("Prim MST lenght: {0}", primAlg.CalcMSTLength(vertices));
        }

        private static void MaxSpaceClustering(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            int verticesCount = int.Parse(lines[0].Split(' ').First());
            var vertices = Enumerable.Range(1, verticesCount).Select(x => new ExtendedVertex((uint)x)).ToArray();

            foreach (var line in lines.Skip(1))
            {
                var node = line.Split(new[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var left = uint.Parse(node[0]);
                var right = uint.Parse(node[1]);
                var weight = int.Parse(node[2]);
                vertices[left - 1].AddAdjacenEdge(new AdjacentEdge(right, weight));
                vertices[right - 1].AddAdjacenEdge(new AdjacentEdge(left, weight));
            }

            var maxSpaceClustering = new MaxSpaceClustering();

            Console.WriteLine("maximum spacing of a 4-clustering: {0}", maxSpaceClustering.CalcMaxSpacing(vertices, 4));
        }

        private static void ScheduleProblem(string fileName)
        {
            var input = File.ReadAllLines(fileName);
            int jobsCount;
            if (!int.TryParse(input[0], out jobsCount))
            {
                Console.WriteLine("can't read jobs number");
            }
            var jobs = new Job[jobsCount];
            int jobIndex = 0;
            foreach (var jobString in input.Skip(1))
            {
                var jobParts = jobString.Split(' ');
                jobs[jobIndex] = new Job(int.Parse(jobParts[0]), int.Parse(jobParts[1]));
                jobIndex++;
            }

            Console.WriteLine("schedules jobs in decreasing order of the difference (weight - length). Weigthed sum: {0}",
                              new DecreaseOrderScheduler().CalcWeightedSum(jobs));
            Console.WriteLine("schedules jobs in decreasing order of the ratio (weight/length). Weigthed sum: {0}",
                              new DecreaseRatioScheduler().CalcWeightedSum(jobs));
        }
    }
}
