using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    internal class Search
    {
        public static int BinarySearch(List<int> list, int val)
        {
            int left = 0;
            int right = list.Count - 1;
            while (left <= right)
            {
                int middle = (left + right)/2;

                int temp = list[middle];

                if(temp == val)
                {
                    return middle;
                }
                else if (temp < val)
                {
                    left = middle+1;
                }
                else
                {
                    right = middle-1;
                }
            }

            return -1;
        }

        public static int NaiveSearch(String strL, String strS)
        {
            int count = 0;

            for(int i = 0; i < strL.Length; i++)
            {
                for(int j = 0; j < strS.Length; j++)
                {
                    if (strS[j] != strL[i+j])
                    {
                        break;
                    }

                    if(j == strS.Length -1 )
                    {
                        count++;
                    }
                }
            }

            return count;
        }

    }
}
