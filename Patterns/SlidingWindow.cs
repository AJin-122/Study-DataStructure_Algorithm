using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    internal class SlidingWindow
    {
        public static int? MaxSubarraySum(List<int> arr, int num)
        {
            int maxSum = 0;
            int tempSum = 0;

            if (arr.Count < num) return null;

            for(int i = 0; i < num; i++)
            {
                maxSum += arr[i];
            }

            tempSum = maxSum;

            for(int i = num; i < arr.Count; i++)
            {
                tempSum = tempSum - arr[i-num] + arr[i];
                maxSum = Math.Max(maxSum, tempSum);
            }

            return maxSum;
        }

    }
}
