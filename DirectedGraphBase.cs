using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    abstract public class DirectedGraphBase : IDirectedGraph
    {
        public abstract void AddEdge(uint u, uint v);
        public abstract void AddVertex();
        public abstract uint GetNumberOfVertices();
        public abstract bool hasEdge(uint u, uint v);

        public void Print()
        {
            uint nNodes = this.GetNumberOfVertices();
            Console.WriteLine("Vertices:");
            for (int i = 0; i < nNodes; i++)
            {
                Console.Write($"{i},");
            }

            Console.WriteLine("\nEdges:");
            for (uint i = 0; i < nNodes; i++)
            {
                for (uint j = 0; j < nNodes; j++)
                {
                    if (hasEdge(i, j))
                    {
                        Console.WriteLine($"{i} -> {j}");
                    }
                }
            }
        }

        public abstract void RemoveEdge(uint u, uint v);
    }
}