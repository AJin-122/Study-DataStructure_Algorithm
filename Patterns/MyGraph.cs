using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class MyGraph<T> where T : IComparable
    {
        Dictionary<T, List<T>> adjacencyList;

        public MyGraph()
        {
            this.adjacencyList = new Dictionary<T, List<T>>();
        }

        public void addVertex(T vertex)
        {
            if(adjacencyList.ContainsKey(vertex) == false)
                adjacencyList.Add(vertex, new List<T>());
        }

        public void addEdge(T v1, T v2)
        {
            if (!adjacencyList.ContainsKey(v1) || !adjacencyList.ContainsKey(v2)) return;

            adjacencyList[v1].Add(v2);
            adjacencyList[v2].Add(v1);
        }

        public void removeEdge(T v1, T v2)
        {
            if (!adjacencyList.ContainsKey(v1) || !adjacencyList.ContainsKey(v2)) return;

            adjacencyList[v1].Remove(v2);
            adjacencyList[v2].Remove(v1);
        }

        public void removeVertex(T vertex)
        {
            if (adjacencyList.ContainsKey(vertex) == false) return;

            while (this.adjacencyList[vertex].Count > 0)
            {
                var adjacentVertex = this.adjacencyList[vertex][adjacencyList[vertex].Count - 1];
                this.adjacencyList[vertex].RemoveAt(adjacencyList[vertex].Count - 1);
                this.removeEdge(vertex, adjacentVertex);
            }

            this.adjacencyList.Remove(vertex);
        }

        public List<T>? DFS_Recursive(T start)
        {
            List<T>? result = new List<T>();
            Dictionary<T,bool> visited = new Dictionary<T,bool>();
            return dfsHelper(start,result,visited);
        }

        public List<T>? dfsHelper(T vertex,List<T> result, Dictionary<T,bool> visited)
        {
            if (this.adjacencyList.ContainsKey(vertex) == false) return null;
            visited.Add(vertex, true );
            result.Add(vertex);

            foreach(var neighbor in this.adjacencyList[vertex])
            {
                if(visited.ContainsKey(neighbor) == false)
                {
                    dfsHelper(neighbor, result, visited);
                }
            }

            return result;
        }

        public List<T> DFS_Iterative(T start)
        {
            var stack = new Stack<T>();
            var result = new List<T>();
            var visited = new Dictionary<T, bool>();

            stack.Push(start);
            visited.Add(start, true );

            while(stack.Count > 0)
            {
                var currentVertex = stack.Pop();
                result.Add(currentVertex);

                foreach(var neighbor in this.adjacencyList[currentVertex])
                {
                    if( visited.ContainsKey(neighbor) == false)
                    {
                        visited.Add(neighbor, true );
                        stack.Push(neighbor);
                    }
                }
            }

            return result;
        }

        public List<T> BFS(T start)
        {
            var queue = new Queue<T>();
            var result = new List<T>();
            var visited = new Dictionary<T, bool>();

            queue.Enqueue(start);
            visited.Add(start, true);

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();
                result.Add(currentVertex);

                //this.adjacencyList[currentVertex].Reverse();

                foreach (var neighbor in this.adjacencyList[currentVertex])
                {
                    if (visited.ContainsKey(neighbor) == false)
                    {
                        visited.Add(neighbor, true);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return result;
        }
    }
}
