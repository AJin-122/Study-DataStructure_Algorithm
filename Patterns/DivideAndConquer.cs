using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    internal class DivideAndConquer
    {
        public static int Search(List<int> arr, int val)
        {
            int min = 0;
            int max = arr.Count - 1;

            while (min <= max)
            {
                int middle = (min + max) / 2;

                int currentElement = arr[middle];

                if (arr[middle] < val)
                {
                    min = middle + 1;
                }
                else if (arr[middle] > val)
                {
                    max = middle - 1;
                }
                else
                {
                    return middle;
                }
            }

            return -1;
        }
    }
}
