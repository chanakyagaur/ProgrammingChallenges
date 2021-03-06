﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.DynamicProgramming;
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

                if (string.Equals(alg, "hamming", StringComparison.OrdinalIgnoreCase))
                {
                    CalcClusterings(args[1]);
                }

                if (string.Equals(alg, "tsp", StringComparison.OrdinalIgnoreCase))
                {
                    CalcTSP(args[1]);
                }

                if (string.Equals(alg, "knapsack", StringComparison.OrdinalIgnoreCase))
                {
                    CalcKnapsack(args[1]);
                }
            }

            Console.WriteLine("press any key");
            Console.ReadKey();
        }

        private static void CalcKnapsack(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var firstLine = lines[0].Split(' ');
            int capacity = int.Parse(firstLine.First());
            int inputCount = int.Parse(firstLine.Skip(1).First());
            var input = new List<Tuple<int, int>>(inputCount);
            input.AddRange(lines.Skip(1).Select(
                line => line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries))
                    .Select(node => new Tuple<int, int>(
                        int.Parse(node.First()), 
                        int.Parse(node.Skip(1).First()))));

            var knapsackAlg = new KnapsackAlg();

            Console.WriteLine("knapsack: {0}", knapsackAlg.CalcOptimalValue(input.ToArray(), capacity));
        }

        private static void CalcTSP(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            int verticesCount = int.Parse(lines[0].Split(' ').First());
            var input = new List<Tuple<float, float>>(verticesCount);
            foreach (var line in lines.Skip(1))
            {
                var node = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                input.Add(new Tuple<float, float>(float.Parse(node.First()), float.Parse(node.Skip(1).First())));
            }

            var tsp = new TSPAlg();

            Console.WriteLine("tsp: {0}", tsp.CalcMinCostTour(input.ToArray()));
        }

        private static void PrimMST(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            int verticesCount = int.Parse(lines[0].Split(' ').First());
            var vertices = Enumerable.Range(1, verticesCount).Select(x => new ExtendedVertex(x)).ToArray();
            
            foreach (var line in lines.Skip(1))
            {
                var node = line.Split(new[] {' ', '\t', ','}, StringSplitOptions.RemoveEmptyEntries);
                var left = int.Parse(node[0]);
                var right = int.Parse(node[1]);
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
            var vertices = Enumerable.Range(1, verticesCount).Select(x => new ExtendedVertex(x)).ToArray();

            foreach (var line in lines.Skip(1))
            {
                var node = line.Split(new[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var left = int.Parse(node[0]);
                var right = int.Parse(node[1]);
                var weight = int.Parse(node[2]);
                vertices[left - 1].AddAdjacenEdge(new AdjacentEdge(right, weight));
                vertices[right - 1].AddAdjacenEdge(new AdjacentEdge(left, weight));
            }

            var maxSpaceClustering = new MaxSpaceClustering();

            Console.WriteLine("maximum spacing of a 4-clustering: {0}", maxSpaceClustering.CalcMaxSpacing(vertices, 4));
        }

        private static void CalcClusterings(string filePath)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var lines = File.ReadAllLines(filePath);
            int verticesCount = int.Parse(lines[0].Split(' ').First());
            var vertices = new Dictionary<string, Vertex>(verticesCount);
            
            foreach (var line in lines.Skip(1))
            {
                AddDictionaryEdge(vertices, line);
            }

            var maxSpaceClustering = new MaxSpaceClustering();

            var result = maxSpaceClustering.CalcClusterings(vertices);

            stopWatch.Stop();

            Console.WriteLine("the largest value of k such that there is a k-clustering with spacing at least 3: {0}, elapsed: {1} ms", result, stopWatch.ElapsedMilliseconds);
        }

        private static void AddDictionaryEdge(Dictionary<string, Vertex> vertices, string key)
        {
            vertices[key.Replace(" ", string.Empty)] = new Vertex(vertices.Count + 1);
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
