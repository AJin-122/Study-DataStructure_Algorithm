using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    internal class MultiplePointers
    {
        public static List<int> SumZero(List<int> list)
        {
            list.Sort();

            int left = 0;
            int right = list.Count-1;
            
            while (left < right)
            {
                int sum = list[left] + list[right];
                if(sum == 0)
                {
                    return new List<int>() { list[left], list[right] };
                }
                else if(sum > 0)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }

            return null;
        }

        public static int CountUniqueValues(List<int> list)
        {
            list.Sort();

            int indexUnique = 0;
            int indexValues = 0;

            while(indexValues < list.Count)
            {
                if (list[indexUnique] == list[indexValues])
                {
                    indexValues++;
                }
                else
                {
                    indexUnique++;
                    list[indexUnique] = list[indexValues];
                }
            }

            //PrintList<int>(list);

            return ++indexUnique;
        }

        public static void PrintList<T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("");
        }
    }
}
