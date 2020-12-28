using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Directed Graph implemented with matrix");
            var graph1 = new DirectedGraphAsMatrix(5);
            graph1.AddEdge(0, 1);
            graph1.AddEdge(1, 2);
            graph1.AddEdge(2, 3);
            graph1.AddEdge(1, 3);
            graph1.AddEdge(3, 4);
            graph1.AddEdge(1, 4);
            graph1.AddEdge(0, 4);

            graph1.Print();

            graph1.AddVertex();
            graph1.AddEdge(0, 5);
            graph1.AddEdge(4, 5);
            graph1.AddEdge(2, 5);

            var alg = new DijkstraAlgorithm();
            uint startVertex = 0;
            var dist = alg.ComputeMinDistances(graph1, startVertex);
            alg.Print(dist, startVertex);

            graph1.Print();

            graph1.RemoveEdge(0, 5);
            graph1.RemoveEdge(4, 5);
            graph1.RemoveEdge(2, 5);

            graph1.Print();
            
            Console.WriteLine("Directed Graph implemented as Array of Lists");

            var graph2 = new DirectedGraphAsList(5);
            graph2.AddEdge(0, 1);
            graph2.AddEdge(1, 2);
            graph2.AddEdge(2, 3);
            graph2.AddEdge(1, 3);
            graph2.AddEdge(3, 4);
            graph2.AddEdge(1, 4);
            graph2.AddEdge(0, 4);

            graph2.Print();

            graph2.AddVertex();
            graph2.AddEdge(0, 5);
            graph2.AddEdge(4, 5);
            graph2.AddEdge(2, 5);

            graph2.Print();

            startVertex = 2;
            dist = alg.ComputeMinDistances(graph2, startVertex);
            alg.Print(dist, startVertex);

            graph2.RemoveEdge(0, 5);
            graph2.RemoveEdge(4, 5);
            graph2.RemoveEdge(2, 5);

            graph2.Print();
        }
    }
}
