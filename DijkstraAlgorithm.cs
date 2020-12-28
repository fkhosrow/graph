using System;

namespace Graph
{
    public class DijkstraAlgorithm
    {
        /// <summary>
        /// Compute min distances from the source vertex to all other vertices in the graph
        /// </summary>
        /// <param name="src"></param>
        public int[] ComputeMinDistances(IDirectedGraph graph, uint startVertex)
        {
            if (graph == null)
            {
                throw new ArgumentNullException(nameof(graph));
            }

            var nNodes = graph.GetNumberOfVertices();
            if (startVertex > nNodes)
            {
                throw new ArgumentOutOfRangeException(nameof(startVertex));
            }

            var dist = new int[nNodes]; // Holds the min distance to all nodes.
            var nodeVisited = new bool[nNodes]; // Determines if a starting node is visited once

            // Initialize
            for (int i = 0; i < nNodes; i++)
            {
                dist[i] = int.MaxValue;
                nodeVisited[i] = false; 
            }

            dist[startVertex] = 0;

            for (uint i = 0; i < nNodes; i++)
            {
                nodeVisited[i] = true;
                for (uint j = 0; j < nNodes; j++)
                {
                    // The check  dist[i] != int.MaxValue ensures starting vertex is where we start from
                    if (dist[i] != int.MaxValue && !nodeVisited[j] && graph.hasEdge(i, j))
                    {
                        var cost = 1; // 1 can be replaced with a cost etc. This support also needs to be added to graph
                        var tmp = dist[i] + cost;
                        if (tmp < dist[j])
                        {
                            dist[j] = tmp;
                        }
                    }
                }
            }

            return dist;
        }

        public void Print(int[] dist, uint sourceVertex)
        {
            Console.WriteLine("Dijkstra Algorithm");
            Console.WriteLine($"Compute distances from vertex {sourceVertex} to all other vertices");
            for (int i = 0; i < dist.Length; i++)
            {
                Console.WriteLine($"{sourceVertex} -> {i} = {dist[i]}");
            }
        }
    }
}
