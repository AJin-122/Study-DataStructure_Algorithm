using System;
using System.Collections.Generic;

namespace Patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            //bool result = false;

            //result = FrequencyCounters.SameNaive(new List<int> { 1, 2,3,2 }, new List<int> { 9,1,4,4 });
            //result = FrequencyCounters.SameRefactor(new List<int> { 1, 2, 3, 1 }, new List<int> { 9, 1, 4, 4 });
            //result = FrequencyCounters.ValidAnagram("aasdbcd", "bcdaaad");

            //Console.WriteLine("결과 " + result);

            //List<int> resultList = new List<int>();

            //resultList = MultiplePointers.SumZero(new List<int> { 1, 2, 3, -4, -5, 0, -7, -6 });

            //int resultint = MultiplePointers.CountUniqueValues(new List<int> { 1, 2, 3, 4, 5, 4, 4, 7 });

            //Console.WriteLine(resultint);
            
            //if (resultList == null )
            //{
            //    Console.WriteLine("없음");
            //}
            //else
            //{
            //    foreach ( int i in resultList)
            //    {
            //        Console.Write("[{0}] ",i);
            //    }
            //}
            
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
            //MyQueue<string> myQueue = new MyQueue<string>();

            //myQueue.enqueue("1");
            //myQueue.enqueue("2");
            //myQueue.enqueue("3");
            //myQueue.enqueue("4");

            //Console.WriteLine(myQueue.dequeue());
            //Console.WriteLine(myQueue.dequeue());
            //Console.WriteLine(myQueue.dequeue());
            //Console.WriteLine(myQueue.dequeue());
            //Console.WriteLine(myQueue.dequeue());
            //Console.WriteLine(myQueue.dequeue() == null ? "yes" : "no");

            //이진 탐색 트리
            //MyTrees<int> myTrees = new MyTrees<int>();

            //myTrees.insert(10);
            //myTrees.insert(6);
            //myTrees.insert(15);
            //myTrees.insert(3);
            //myTrees.insert(8);
            //myTrees.insert(20);
            //Console.WriteLine(myTrees.insert(10) == null ? "yes" : "no");

            //Console.WriteLine(myTrees.find(15) != null ? "true" : "false");

            //트리 탐색
            //List<int> result = myTrees.BFS();
            //PrintList(result);

            //List<int> list = myTrees.DFSPreOrder();
            //PrintList(list);

            //List<int> list = myTrees.DFSPostOrder();
            //PrintList(list);

            //List<int> list = myTrees.DFSInOrder();
            //PrintList(list);

            //힙 최대 이진 힙
            //MaxBinaryHeap<int> heap = new MaxBinaryHeap<int>();

            //heap.insert(41);
            //heap.insert(39);
            //heap.insert(33);
            //heap.insert(18);
            //heap.insert(27);
            //heap.insert(12);
            //heap.insert(55);

            //PrintList(heap.values);

            //Console.WriteLine(heap.ExtractMax());

            //PrintList(heap.values);

            //Console.WriteLine(heap.ExtractMax());
            //Console.WriteLine(heap.ExtractMax());
            //Console.WriteLine(heap.ExtractMax());
            //Console.WriteLine(heap.ExtractMax());
            //Console.WriteLine(heap.ExtractMax());
            //Console.WriteLine(heap.ExtractMax());
            //Console.WriteLine(heap.ExtractMax() == default(int) ? "yes" : "no");
            //Console.WriteLine(heap.ExtractMax() == 0 ? "yes" : "no");

            //PrintList(heap.values);

            //우선순위 큐
            //MyPriorityQueue<string> er = new MyPriorityQueue<string>();

            //er.Enqueue("common cold", 1);
            //er.Enqueue("gunshot wound", 5);
            //er.Enqueue("high fever", 4);
            //er.Enqueue("broken arm", 2);
            //er.Enqueue("glass in foot", 3);

            //?? Null 경우의 값 대입
            //var one = er.Dequeue() ?? new PNode<string>("null", 0);
            //var two = er.Dequeue() ?? new PNode<string>("null", 0);
            //var three = er.Dequeue() ?? new PNode<string>("null", 0);
            //var four = er.Dequeue() ?? new PNode<string>("null", 0);
            //var five = er.Dequeue() ?? new PNode<string>("null", 0);
            //var six = er.Dequeue() ?? new PNode<string>("null",0);

            //Console.WriteLine(one.val + " " + one.priority);
            //Console.WriteLine(two.val + " " + two.priority);
            //Console.WriteLine(three.val + " " + three.priority);
            //Console.WriteLine(four.val + " " + four.priority);
            //Console.WriteLine(five.val + " " + five.priority);
            //Console.WriteLine(six.val + " " + six.priority);

            //해쉬 테이블

            //MyHashTables myhash = new MyHashTables();
            //Console.WriteLine(myhash.set("maroon", "#800000"));
            //Console.WriteLine(myhash.set("yellow", "#FFFF00"));
            //Console.WriteLine(myhash.set("olive", "#808000"));
            //Console.WriteLine(myhash.set("salmon", "#FA8072"));
            //Console.WriteLine(myhash.set("lightcoral", "#F08080"));
            //Console.WriteLine(myhash.set("mediumvioletred", "#C71585"));
            //Console.WriteLine(myhash.set("plum", "#DDA0DD"));
            //Console.WriteLine(myhash.set("violet", "#DDA0DD"));

            //PrintList<string>(myhash.getAll("maroon") ?? new List<string> { "null"});
            //PrintList<string>(myhash.getAll("yellow") ?? new List<string> { "null" });
            //PrintList<string>(myhash.getAll("olive") ?? new List<string> { "null" });
            //PrintList<string>(myhash.getAll("salmon") ?? new List<string> { "null" });
            //PrintList<string>(myhash.getAll("lightcoral") ?? new List<string> { "null" });
            //PrintList<string>(myhash.getAll("nasdfuasdll") ?? new List<string> { "null" });

            //Console.WriteLine(myhash.get("maroon") ?? "null");
            //Console.WriteLine(myhash.get("nasdfuasdll") ?? "null");
            //PrintList<string>(myhash.values());
            //PrintList<string>(myhash.keys());

            //Console.WriteLine(myhash.get("maroon"));
            //Console.WriteLine(myhash.set("maroon", "#812341"));
            //Console.WriteLine(myhash.get("maroon"));
            
            */
            //그래프
            //MyGraph<string> graph = new MyGraph<string>();
            //graph.addVertex("Dallas");
            //graph.addVertex("Tokyo");
            //graph.addVertex("Aspen");
            //graph.addVertex("Los Angeles");
            //graph.addVertex("Hong Kong");

            //graph.addEdge("Dallas", "Tokyo");
            //graph.addEdge("Dallas", "Aspen");
            //graph.addEdge("Hong Kong", "Tokyo");
            //graph.addEdge("Hong Kong", "Dallas");
            //graph.addEdge("Los Angeles", "Hong Kong");
            //graph.addEdge("Hong Kong", "Aspen");

            //graph.removeEdge("Dallas", "Aspen");
            //graph.removeVertex("Hong Kong");

            //그래프 순회
            MyGraph<string> g = new MyGraph<string>();

            g.addVertex("A");
            g.addVertex("B");
            g.addVertex("C");
            g.addVertex("D");
            g.addVertex("E");
            g.addVertex("F");
            g.addEdge("A", "B");
            g.addEdge("A", "C");
            g.addEdge("B", "D");
            g.addEdge("C", "E");
            g.addEdge("D", "E");
            g.addEdge("D", "F");
            g.addEdge("E", "F");

            PrintList<string>(g.DFS_Recursive("A") ?? new List<string>() { "null" });
            PrintList<string>(g.DFS_Iterative("A") ?? new List<string>() { "null" });
            PrintList<string>(g.BFS("A") ?? new List<string>() { "null" });
        }

        public static void PrintList<T>(List<T> list)
        {
            foreach (T item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}