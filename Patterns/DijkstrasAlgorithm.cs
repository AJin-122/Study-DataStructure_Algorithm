using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    public class WeightedGraph<T> where T : IComparable
    {
        public Dictionary<T, Dictionary<T, int>> adjacencyList;

        public WeightedGraph()
        {
            this.adjacencyList = new Dictionary<T, Dictionary<T, int>>();
        }

        public void addVertex(T vertex)
        {
            if (adjacencyList.ContainsKey(vertex) == false)
                adjacencyList.Add(vertex, new Dictionary<T, int>());
        }

        public void addEdge(T v1, T v2, int weight)
        {
            if (!adjacencyList.ContainsKey(v1) || !adjacencyList.ContainsKey(v2)) return;

            adjacencyList[v1].Add(v2, weight);
            adjacencyList[v2].Add(v1, weight);
        }
    }

    public class DijkstrasAlgorithm<T> where T : IComparable
    {
        Dictionary<T, Dictionary<T, int>> adjacencyList;

        public DijkstrasAlgorithm(WeightedGraph<T> graph)
        {
            this.adjacencyList = graph.adjacencyList;
        }

        public List<T> Dijkstra(T start, T finish)
        {
            //노드들의 가장 낮은 거리 기준으로 우선순위
            var nodes = new PriorityQueue<T,int>();
            // 출발점에서 해당 정점 까지의 거리를 저장
            var distances = new Dictionary<T, int>();
            // 가장 최소 거리의 지나온 지점을 저장
            var previous = new Dictionary<T,T?>();
            // 최종 루트
            var path = new List<T>();

            //데이터 구조 초기화
            foreach(var vertex in this.adjacencyList)
            {
                if (vertex.Key.CompareTo(start) == 0)
                {
                    distances.Add(vertex.Key, 0);
                    nodes.Enqueue(vertex.Key, 0);
                }
                else
                {
                    distances.Add(vertex.Key, int.MaxValue);
                    nodes.Enqueue(vertex.Key, int.MaxValue);
                }
                previous.Add(vertex.Key, default(T));
            }

            //방문 할 것이 남아 있는 한 반복
            while(nodes.Count > 0)
            {
                var smallest = nodes.Dequeue();

                //가장 낮은 우선순위가 도착지점이면
                if(smallest.CompareTo(finish) == 0)
                {
                    //알고리즘을 끝낸다.
                    //path 입력
                    while (previous[smallest] != null)
                    {
                        path.Insert(0, smallest);
                        smallest = previous[smallest];
                    }
                    path.Insert(0, smallest);
                    break;
                }

                if (distances[smallest].CompareTo(int.MaxValue) != 0)
                {
                    foreach(var neighbor in this.adjacencyList[smallest])
                    {
                        //인접점을 찾아라
                        //출발점에서 인접점 까지의 거리를 구해라
                        int candidate = distances[smallest] + neighbor.Value;
                        var nextNeighbor = neighbor.Key;
                        if(candidate < distances[nextNeighbor])
                        {
                            //인접점으로 가는 거리를 최소 값으로 변경
                            distances[nextNeighbor] = candidate;
                            //이전 경로를 최소 경로로 변경
                            previous[nextNeighbor] = smallest;
                            //새로운 우선 순위를 부여
                            nodes.Enqueue(nextNeighbor, candidate);
                        }
                    }
                }
            }

            return path;
        }
    }
}
