namespace Graph
{
    public interface IDirectedGraph
    {
        void AddEdge(uint u, uint v);
        void RemoveEdge(uint u, uint v);
        void AddVertex();
        bool hasEdge(uint u, uint v);
        uint GetNumberOfVertices();
        void Print();
    }
}