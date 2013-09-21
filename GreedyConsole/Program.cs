using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgClass.GreedyAlgs;

namespace GreedyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() == 1)
            {
                string fileName = args[0];

                var input = File.ReadAllLines(fileName);
                int jobsCount;
                if (!int.TryParse(input[0], out jobsCount))
                {
                    Console.WriteLine("can't read jobs number");
                    return;
                }
                var jobs = new Job[jobsCount];
                int jobIndex = 0;
                foreach (var jobString in input.Skip(1))
                {
                    var jobParts = jobString.Split(' ');
                    jobs[jobIndex] = new Job(int.Parse(jobParts[0]), int.Parse(jobParts[1]));
                    jobIndex++;
                }

                Console.WriteLine("schedules jobs in decreasing order of the difference (weight - length). Weigthed sum: {0}", new DecreaseOrderScheduler().CalcWeightedSum(jobs));
                Console.WriteLine("schedules jobs in decreasing order of the ratio (weight/length). Weigthed sum: {0}", new DecreaseRatioScheduler().CalcWeightedSum(jobs));
                Console.WriteLine("press any key");
                Console.ReadKey();
            }
        }
    }
}
