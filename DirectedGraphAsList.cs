using System;
using System.Collections.Generic;

namespace Graph
{
    /// <summary>
    /// Graphs can be undirected or directed.
    /// Graphs are used in network and social media sites like Facebook.
    /// Here it is implemented an an array of list. In C#, list is implemented using an array.
    /// It could have been implemented as array of linked lists or linked lists with better performance for add/remove.
    /// For V vertices, there is an array of size V.
    /// Each edge is added to each vertex list as needed.
    /// 
    /// Pros: Uses as much space as needed for edges. Useful for sparse graphs.
    /// Cons: O(n) for most operations.
    /// 
    /// This class can be enhanced such that a vertex is added
    /// using an object (e.g. Facebook person)
    /// and ids are assigned and tracked internally.
    /// </summary>
    public class DirectedGraphAsList : DirectedGraphBase, IDirectedGraph
    {
        // Array of vertices. Each vertex holds a linked list of vertices which are linked to it i.e. edges.
        private List<uint>[] _network;
        private uint _nNodes;

        /// <summary>
        /// Create a graph with n vertices
        /// </summary>
        /// <param name="n"></param>
        public DirectedGraphAsList(uint n)
        {
            if (n == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            _network = new List<uint>[n];
            for (int i = 0; i < n; i++)
            {
                _network[i] = new List<uint>();
            }

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

            var vertex = _network[u]; // If undirected, check for v as well
            return vertex.FindIndex(x => x == v) >= 0 ? true : false;
        }

        /// <summary>
        /// Add an edge from vertex u to v.
        /// This can be set to a weight or cost when applicable
        /// Performance: Worst: O(n) to resize; O(1) otherwise.
        /// </summary>
        public override void AddEdge(uint u, uint v)
        {
            if (u > _nNodes-1)
            {
                throw new ArgumentOutOfRangeException(nameof(u));
            }

            if (v > _nNodes - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(v));
            }

            var vertex = _network[u]; // If undirected, check for v as well
            vertex.Add(v); // If undirected, add u to v as well
        }

        /// <summary>
        /// Removes an edge from vertex u to  v.
        /// Performance: O(n)
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

            if (hasEdge(u, v))
            {
                var vertex = _network[u]; // If undirected, check for v as well
                vertex.Remove(v);
            }
        }

        /// <summary>
        /// Adds a new vertex to the graph
        /// Performance: O(n)
        /// </summary>
        public override void AddVertex()
        {
            var newNNodes = _nNodes + 1;
            var newVertices = new List<uint>[newNNodes];
            for (int i = 0; i < _nNodes; i++)
            {
                newVertices[i] = _network[i];  // No need to copy lists. Point to original lists.
            }
            newVertices[_nNodes] = new List<uint>();

            _network = newVertices;
            _nNodes = newNNodes;
        }

        public override uint GetNumberOfVertices()
        {
            return _nNodes;
        }
    }
}
