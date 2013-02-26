using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.Graphs;

namespace MinCutConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Count() == 1)
            {
                string filePath = args[0];
                var vertices = new List<Vertex>();
                using (var reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        var verticeArray = reader.ReadLine().Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                        vertices.Add(new Vertex(uint.Parse(verticeArray[0]),
                                                 verticeArray.Skip(1).Select(uint.Parse).ToArray()));
                    }
                }
                vertices.Sort();
                var stopWatch = new Stopwatch();
                //var repeatCount = (int)(Math.Pow(vertices.Count, 2)*Math.Log(vertices.Count, Math.E));
                var repeatCount = (int)(Math.Pow(vertices.Count, 2));
                stopWatch.Start();
                var kargerAlg = new KargerMinCut(vertices.ToArray());
                var minCut = Enumerable.Range(1, repeatCount)
                              .Select(i => kargerAlg.CalculateMinCut())
                              .Min();

                stopWatch.Stop();
                Console.WriteLine("min cut={0}, repeatCount = {1}, running time = {2} ms", minCut, repeatCount, stopWatch.ElapsedMilliseconds);
                Console.WriteLine("press any key");
                Console.ReadLine();
            }
        }
    }
}
