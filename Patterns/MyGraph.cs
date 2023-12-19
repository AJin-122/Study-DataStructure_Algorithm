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
    }
}
