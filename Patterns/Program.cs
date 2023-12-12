using System;
using System.Collections.Generic;

namespace Patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool result = false;

            //result = FrequencyCounters.SameNaive(new List<int> { 1, 2,3,2 }, new List<int> { 9,1,4,4 });
            //result = FrequencyCounters.SameRefactor(new List<int> { 1, 2, 3, 1 }, new List<int> { 9, 1, 4, 4 });
            //result = FrequencyCounters.ValidAnagram("aasdbcd", "bcdaaad");

            //Console.WriteLine("결과 " + result);

            //List<int> resultList = new List<int>();

            //resultList = MultiplePointers.SumZero(new List<int> { 1, 2, 3, -4, -5, 0, -7, -6 });

            //int resultint = MultiplePointers.CountUniqueValues(new List<int> { 1, 2, 3, 4, 5, 4, 4, 7 });

            //Console.WriteLine(resultint);
            /*
                        if (resultList == null )
                        {
                            Console.WriteLine("없음");
                        }
                        else
                        {
                            foreach ( int i in resultList)
                            {
                                Console.Write("[{0}] ",i);
                            }
                        }
            */
            //int? result = SlidingWindow.MaxSubarraySum(new List<int> { 2, 6, 9, 2, 1, 8, 5, 6, 3 }, 3);

            //int result = Search.NaiveSearch("lorie loled", "lo");

            //List<int> list = new List<int>() {37,45,29,8 };

            //List<int> list = new List<int>() { 8, 1, 2, 3, 4, 6,7,};

            //List<int> result = Sort.BubbleSort(list);

            //List<int> list = new List<int>() { 0, 2, 34, 22, 10, 19, 17 };

            //List<int> result = Sort.SelectionSort(list);

            //List<int> list = new List<int>() { 2, 1, 9, 76, 10, 19, 17 };

            //List<int> result = Sort.InsertionSort(list);

            //List<int> list1 = new List<int>() { 1, 10, 50 };
            //List<int> list1 = new List<int>() { 101};
            //List<int> list2 = new List<int>() { 2, 14, 99, 100 };

            //List<int> result = Sort.MergingArrays(list1, list2);

            //List<int> list = new List<int>();

            //for (int i = 0; i < 10; i++)
            //{
            //    Random rand = new Random();

            //    list.Add(rand.Next(0, 999));
            //}

            //PrintList(list);

            //Console.WriteLine("----------------------");

            //List<int> result = Sort.MergeSort(list);

            //List<int> result = Sort.QuickSort(list);

            //PrintList(result);

            //Console.WriteLine(result);

            //int result = Sort.GetDigit(12345, 4);

            //int result = Sort.DigitCount(1);

            //Console.WriteLine(Sort.MostDigits(list));

            //PrintList(Sort.RadixSort(list));

            //단일 연결 리스트

            //Node<string> first = new Node<string>("Hi");
            //first.next = new Node<string>(" there");
            //first.next.next = new Node<string>(" how");
            //first.next.next.next = new Node<string>(" are");
            //first.next.next.next.next = new Node<string>(" you");

            //Console.WriteLine(first.val + first.next.val);

            //SinglyLinkedLists<string> listT = new SinglyLinkedLists<string>();

            //listT.push("Hi");
            //listT.push("Goodbye");
            //listT.push("!");
            //listT.push("C#DR");
            //listT.push(":)");
            //listT.traverse();

            //Console.WriteLine("-------------");

            //Console.WriteLine(listT.head.val + listT.tail.val + " " + listT.length);
            //Console.WriteLine(listT.pop().val + " " + listT.length);
            //Console.WriteLine(listT.shift().val + " " + listT.length);

            //listT.unshift("First");
            //listT.traverse();

            //Console.WriteLine(listT.get(3).val);
            //listT.set(3, "!!!!");
            //listT.traverse();

            //listT.insert(0, "asdas");
            //listT.insert(listT.length, "qwer");
            //listT.insert(1, "@#%@");
            //listT.traverse();

            //listT.remove(2);
            //listT.reverse();
            //listT.traverse();

            //양방향 연결 리스트

            //DoublyLinkedLists<string> dlist = new DoublyLinkedLists<string>();

            //dlist.push("1");
            //dlist.push("2");
            //dlist.push("3");
            //dlist.push("4");
            //dlist.push("5");
            //dlist.traverse();

            //dlist.pop();
            //dlist.pop();
            //dlist.pop();
            //dlist.pop();
            //dlist.pop();
            //dlist.pop();
            //dlist.traverse();

            //dlist.push("1");
            //dlist.push("2");
            //dlist.push("3");
            //dlist.push("4");
            //dlist.push("5");
            //dlist.traverse();

            //dlist.shift();
            //dlist.traverse();

            //dlist.unshift("7");
            //dlist.traverse();

            //Console.WriteLine(dlist.get(1).val);
            //Console.WriteLine(dlist.get(3).val);

            //dlist.insert(2, "!!!!");
            //dlist.traverse();

            //dlist.remove(1);
            //dlist.traverse();

            //스택
            //MyStack<string> myStack = new MyStack<string>();

            //myStack.push("1");
            //myStack.push("2");
            //myStack.push("3");
            //myStack.push("4");

            //Console.WriteLine(myStack.pop());
            //Console.WriteLine(myStack.pop());
            //Console.WriteLine(myStack.pop());
            //Console.WriteLine(myStack.pop());
            //Console.WriteLine(myStack.pop());
            //Console.WriteLine(myStack.pop() == null ? "yes" : "no");

            //큐
            MyQueue<string> myQueue = new MyQueue<string>();

            myQueue.enqueue("1");
            myQueue.enqueue("2");
            myQueue.enqueue("3");
            myQueue.enqueue("4");

            Console.WriteLine(myQueue.dequeue());
            Console.WriteLine(myQueue.dequeue());
            Console.WriteLine(myQueue.dequeue());
            Console.WriteLine(myQueue.dequeue());
            Console.WriteLine(myQueue.dequeue());
            Console.WriteLine(myQueue.dequeue() == null ? "yes" : "no");
        }

        public static void PrintList(List<int> list)
        {
            foreach (int item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}