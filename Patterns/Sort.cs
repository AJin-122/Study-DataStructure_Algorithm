using System;
using System.Collections.Generic;
using System.Linq;

namespace Patterns
{
    internal class Sort
    {
        public static List<int> BubbleSort(List<int> list)
        {
            bool noSwaps = false;
            int count = 0;

            for(int i = list.Count; i > 0; i--)
            {
                noSwaps = true;
                count++;
                for(int j = 0; j < i-1; j++)
                {
                    if (list[j] > list[j+1])
                    {
                        Swap(list,j,j+1);
                        noSwaps = false;
                    }
                }
                if (noSwaps == true) break;
            }
            Console.WriteLine(count + "");
            return list;
        }

        public static List<int> SelectionSort(List<int> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                int min = i;

                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[min])
                    {
                        min = j;
                    }
                }

                if(i != min) Swap(list, i, min);
            }

            return list;
        }

        public static List<int> InsertionSort(List<int> list)
        {

            for(int i = 1; i < list.Count; i++)
            {
                int currentVal = list[i];
                int cur = i;
                
                for(int j = i-1; j >= 0 && list[j] > currentVal; j--)
                {
                    list[j+1] = list[j];
                    cur = j;
                }

                Console.WriteLine(cur);

                list[cur] = currentVal;

                Program.PrintList(list);
            }

            return list;
        }

        public static List<int> MergingArrays(List<int> list1, List<int> list2)
        {
            List<int> result = new List<int>();

            int i = 0;
            int j = 0;

            while(i < list1.Count && j < list2.Count)
            {
                if (list1[i] < list2[j])
                {
                    result.Add(list1[i]);
                    i++;
                }
                else
                {
                    result.Add(list2[j]);
                    j++;
                }
            }

            while(i < list1.Count)
            {
                result.Add(list1[i]);
                i++;
            }

            while (j < list2.Count)
            {
                result.Add(list2[j]);
                j++;
            }

            return result;
        }

        public static List<int> MergeSort(List<int> list)
        {
            if(list.Count <= 1) return list;
            
            int mid = list.Count/2;

            List<int> left = MergeSort(list.GetRange(0, mid));
            List<int> right = MergeSort(list.GetRange(mid, list.Count - mid));

            PrintList(left);
            PrintList(right);

            return MergingArrays(left,right);
        }

        public static int PivotHelper(List<int> list, int start, int end)
        {
            int pivot = list[start];
            int swapIdx = start;

            for(int i = start+1; i <= end; i++)
            {
                if (list[i] < pivot)
                {
                    swapIdx++;
                    Swap(list, swapIdx, i);
                    PrintList(list);
                }
            }

            Swap(list, start, swapIdx);

            PrintList(list);

            return swapIdx;
        }

        public static List<int> QuickSort(List<int> list, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = PivotHelper(list, left, right);

                QuickSort(list, left, pivotIndex - 1);
                QuickSort(list, pivotIndex + 1, right);
            }

            return list;
        }

        public static List<int> QuickSort(List<int> list)
        {
            int left = 0;
            int right = list.Count-1;

            return QuickSort(list, left, right);
        }

        public static List<int> RadixSort(List<int> array)
        {
            var memory = new Queue<int>[10];
            var max = MostDigits(array);

            for (int p = 0; p < memory.Length; p++)
            {
                memory[p] = new Queue<int>();
            }

            //var num = Math.Pow(10, max);

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < array.Count(); j++)
                {
                    var k = Sort.GetDigit(array[j], i);

                    memory[k].Enqueue(array[j]);
                }

                array.Clear();

                for (int p = 0; p < memory.Count(); p++)
                {
                    while (memory[p].Count() != 0)
                    {
                        array.Add(memory[p].Dequeue());
                    }
                }
            }

            return array;
        }


        public static int GetDigit(int digit, int num)
        {
            return (Math.Abs(digit) / PowInt(10, num)) % 10;
        }

        public static int DigitCount(int digit)
        {
            if (digit == 0) return 1;
            return (int)Math.Log10(Math.Abs(digit)) + 1;
        }

        public static int MostDigits(List<int> nums)
        {
            int maxDigits = 0;
            for(int i = 0; i < nums.Count; i++)
            {
                maxDigits = Math.Max(maxDigits, DigitCount(nums[i]));
            }
            return maxDigits;
        }

        public static void Swap(List<int> list, int i,int j)
        {
            int temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }

        public static void PrintList(List<int> list)
        {
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public static int PowInt(int bas, int exp)
        {
            return Enumerable
                  .Repeat(bas, exp)
                  .Aggregate(1, (a, b) => a * b);
        }
    }
}
