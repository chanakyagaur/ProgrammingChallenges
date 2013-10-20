using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass;
using AlgClass.Graphs;

namespace SCCConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Count() == 2)
            {
                if (args[0] == "scc")
                    KosarajuRun(args[1]);

                if (args[0] == "2sat")
                    TwoSetRun(args[1]);
            }
        }

        private static void KosarajuRun(string filePath)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var edgesEnumerable = File.ReadLines(filePath);
            var edges = edgesEnumerable.Select(edge => edge.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries))
                                       .Select(edgePair => new Tuple<int, int>(int.Parse(edgePair[1]), (int.Parse(edgePair[0]))))
                                       .ToArray();

            int verticesCount = Math.Max(edges.Max(e => e.Item1), edges.Max(e => e.Item2));
            var vertices = Enumerable.Range(1, verticesCount).Select(nodeId => new KosarajuVertex(nodeId)).ToArray();

            edges.ForEach(edge =>
                {
                    vertices[edge.Item1 - 1].AdjacentVertices.Add(edge.Item2);
                    vertices[edge.Item2 - 1].ReversedAdjacentVertices.Add(edge.Item1);
                });

            stopWatch.Stop();
            var initTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("read and init time={0}", initTime);
            stopWatch.Restart();
            var alg = new KosarajuAlgorithm();
            var result = alg.CountStronglyConnectedComponentes(vertices);
            stopWatch.Stop();
            Console.WriteLine("running time = {0}, result={1}", stopWatch.ElapsedMilliseconds, string.Join(",", result.Take(10)));
            Console.WriteLine("press any key");
            Console.ReadLine();
        }

        private static void TwoSetRun(string filePath)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var clausesEnumerable = File.ReadLines(filePath).ToArray();
            var clauses = clausesEnumerable.Skip(1).Select(edge => edge.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                                       .Select(edgePair => new Tuple<int, int>(int.Parse(edgePair[1]), (int.Parse(edgePair[0]))))
                                       .ToArray();

            stopWatch.Stop();
            var initTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("read and init time={0}", initTime);
            stopWatch.Restart();
            var alg = new TwoSetAlg();
            var result = alg.IsSatisfiable(int.Parse(clausesEnumerable.First()), clauses);
            stopWatch.Stop();
            Console.WriteLine("running time = {0}, IsSatisfiable={1}", stopWatch.ElapsedMilliseconds, result);
            Console.WriteLine("press any key");
            Console.ReadLine();
        }
    }
}
