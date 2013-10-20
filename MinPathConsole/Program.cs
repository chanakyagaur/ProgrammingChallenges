using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass;
using AlgClass.Graphs;

namespace MinPathConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = args[0];
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var nodesEnumerable = File.ReadLines(filePath);
            var vertices = nodesEnumerable.Select(node => node.Split(new[] { ' ', '\t', ',' }, StringSplitOptions.RemoveEmptyEntries))
                               .Select(nodeArray =>
                                   {
                                       int nodeId = int.Parse(nodeArray[0]);
                                       var adjacentList = new List<AdjacentEdge>();
                                       for (int i = 1; i < nodeArray.Length; i +=2)
                                       {
                                           adjacentList.Add(new AdjacentEdge(int.Parse(nodeArray[i]), int.Parse(nodeArray[i+1])));
                                       }
                                       return new ExtendedVertex(nodeId, adjacentList.ToArray());
                                   })            
                               .ToArray();

            stopWatch.Stop();
            var initTime = stopWatch.ElapsedMilliseconds;
            Console.WriteLine("read and init time={0}", initTime);
            stopWatch.Restart();
            var alg = new DijkstraAlgorithm(vertices);
            var result = alg.CalculateMinPath();
            stopWatch.Stop();
            Console.WriteLine("running time = {0}, result={1}", stopWatch.ElapsedMilliseconds, string.Join(
                ",", 
                result[6], 
                result[36], 
                result[58], 
                result[81], 
                result[98], 
                result[114],
                result[132],
                result[164],
                result[187],
                result[196]));
            Console.WriteLine("press any key");
            Console.ReadLine();
        }
    }
}
