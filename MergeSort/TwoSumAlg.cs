using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgClass
{
    public class TwoSumAlg
    {
        public static int Calculate(int start, int finish, HashSet<int> numbers)
        {
            int result = 0;
            for (int sum = start; sum <= finish; sum++)
            {
                int lowBound = (sum%2 == 0) ? sum/2 - 1 : (int)Math.Floor((double)sum/2);
                for (int x = 1; x <= lowBound; x++)
                {
                    if (numbers.Contains(x) && numbers.Contains(sum - x))
                    {
                        result++;
                        break;
                    }
                }
            }

            return result;
        }
    }
}
