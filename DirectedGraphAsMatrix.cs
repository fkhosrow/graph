using System;

namespace Graph
{
    /// <summary>
    /// Graphs can be undirected or directed.
    /// Graphs are used in network and social media sites like Facebook.
    /// Here it is implemented as a two dimentional array.
    /// Matrix m: V x V where V = number of vertices/nodes
    /// An edge is identified if matrix[u,v] = value where
    /// value represents an edge, weight, cost.
    /// 
    /// Pros: O(1) for most operations.
    /// Cons: It uses V x V space even if the graph is sparse.
    /// 
    /// This class can be enhanced such that a vertex is added
    /// using an object (e.g. Facebook person)
    /// and ids are assigned and tracked internally.
    /// </summary>
    public class DirectedGraphAsMatrix : DirectedGraphBase, IDirectedGraph
    {
        private int[,] _network;
        private uint _nNodes;

        /// <summary>
        /// Create a graph with n vertices
        /// </summary>
        /// <param name="n"></param>
        public DirectedGraphAsMatrix(uint n)
        {
            if (n == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            _network = new int[n, n];
            _nNodes = n;
        }

        /// <summary>
        /// Determines if there an edge between vertices u and v
        /// This can return a weight or cost when applicable
        /// Performance: O(1)
        /// </summary>
        public override bool hasEdge(uint u, uint v)
        {
            if (u > _nNodes - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(u));
            }

            if (v > _nNodes - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(v));
            }

            return _network[u, v] == 1; // If undirected, also check _network[v,u]
        }

        /// <summary>
        /// Add an edge from vertex u to v.
        /// This can be set to a weight or cost when applicable
        /// Performance: O(1)
        /// </summary>
        public override void AddEdge(uint u, uint v)
        {
            if (u > _nNodes - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(u));
            }

            if (v > _nNodes - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(v));
            }

            _network[u, v] = 1;
            // If undirected, also set _network[v,u]=1
        }

        /// <summary>
        /// Removes an edge from vertex u to  v.
        /// Performance: O(1)
        /// </summary>
        public override void RemoveEdge(uint u, uint v)
        {
            if (u > _nNodes - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(u));
            }

            if (v > _nNodes - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(v));
            }

            _network[u, v] = 0;
            // If undirected, also set _network[u,v]=0
        }

        /// <summary>
        /// Adds a new vertex to the graph
        /// Performance: O(n^2)
        /// </summary>
        public override void AddVertex()
        {
            var newNNodes = _nNodes + 1;
            var newNetwork = new int[newNNodes, newNNodes];
            for (int i = 0; i < _nNodes; i++)
            {
                Array.Copy(_network, i * _nNodes, newNetwork, i * newNNodes, _nNodes);
            }
            _network = newNetwork;
            _nNodes = newNNodes;
        }

        public override uint GetNumberOfVertices()
        {
            return _nNodes;
        }
    }
}
