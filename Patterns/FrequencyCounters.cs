using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    internal class FrequencyCounters
    {
        public static bool SameNaive(List<int> arr1, List<int> arr2)
        {
            if (arr1.Count != arr2.Count)
            {
                return false;
            }
            
            for (int i = 0; i < arr1.Count; i++)
            {
                //루프 안에 루프가 중첩 되어 O(n^2)
                //IndexOf 가 O(n)
                int correctIndex = arr2.IndexOf(PowInt(arr1[i], 2));

                //Console.WriteLine(correctIndex);

                if (correctIndex == -1)
                {
                    return false;
                }
                arr2.RemoveAt(correctIndex);
                
                foreach(int j in arr2)
                    Console.Write(j + " ");
                Console.WriteLine("");
            }
            return true;
        }

        public static int PowInt(int bas, int exp)
        {
            return Enumerable
                  .Repeat(bas, exp)
                  .Aggregate(1, (a, b) => a * b);
        }

        public static bool SameRefactor(List<int> arr1, List<int> arr2)
        {
            if (arr1.Count != arr2.Count)
            {
                return false;
            }

            Dictionary<int,int> freCounter1 = new Dictionary<int,int>();
            Dictionary<int,int> freCounter2 = new Dictionary<int,int>();

            foreach(int i in arr1)
            {
                if (freCounter1.ContainsKey(i))
                {
                    freCounter1[i]++;
                }
                else
                {
                    freCounter1.Add(i, 0);   
                }
            }

            foreach (int i in arr2)
            {
                if (freCounter2.ContainsKey(i))
                {
                    freCounter2[i]++;
                }
                else
                {
                    freCounter2.Add(i, 0);
                }
            }

            foreach(int key in freCounter1.Keys)
            {
                //ContainsKey 함수는 O(logN) O(1) 에 가깝다.
                if(!freCounter2.ContainsKey(PowInt(key,2)))
                {
                    return false;
                }

                if (freCounter2[PowInt(key,2)] != freCounter1[key])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidAnagram(string str1, string str2)
        {
            if(str1.Length != str2.Length)
            {
                return false;
            }

            Dictionary<char,int> lookup = new Dictionary<char,int>();

            for(int i = 0; i < str1.Length; i++)
            {
                char c = str1[i];

                if (lookup.ContainsKey(c))
                {
                    lookup[c]++;
                }
                else
                {
                    lookup.Add(c, 1);
                }
            }

            foreach(char c in lookup.Keys)
            {
                Console.Write(lookup[c] + " ");
            }
            Console.WriteLine("");

            for(int i = 0; i < str2.Length; i++)
            {
                char c = str2[i];

                if(!lookup.ContainsKey(c) || lookup[c] == 0)
                {
                    return false;
                }
                else
                {
                    lookup[c]--;
                }
            }

            return true;
        }

    }

    public static class SpliceExtension
    {
        public static List<T> Splice<T>(this List<T> list, int offset, int count)
        {
            return list.Skip(offset).Take(count).ToList();
        }
    }
}
