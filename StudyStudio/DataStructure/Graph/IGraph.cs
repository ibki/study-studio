using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Graph
{
    public interface IGraph<TVertex>
        where TVertex : IComparable<TVertex>
    {
        bool IsDirected { get; }

        bool IsWeighted { get; }

        int VerticesCount { get; }

        IEnumerable<TVertex> Vertices { get; }
        IEnumerable<IEdge<TVertex>> Edges { get; }

        IEnumerable<TVertex> Neighbours(TVertex vertex);

        /// <summary>
        /// 해당 버텍스가 Destination인 엣지를 가져온다.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        IEnumerable<IEdge<TVertex>> IncomingEdges(TVertex vertex);

        /// <summary>
        /// 해당 버텍스가 Source인 엣지를 가져온다.
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        IEnumerable<IEdge<TVertex>> OutgoingEdges(TVertex vertex);

        bool AddEdge(TVertex source, TVertex destination, double weight);

        bool RemoveEdge(TVertex source, TVertex destination);

        bool AddVertex(TVertex vertex);

        bool RemoveVertex(TVertex vertex);

        bool HasEdge(TVertex source, TVertex destination);

        bool HasVertex(TVertex vertex);

        int Degree(TVertex vertex);

        /// <summary>
        /// 깊이 우선 탐색(DFS)
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        IEnumerable<TVertex> DepthFirstSearch(TVertex vertex);

        /// <summary>
        /// 너비 우선 탐색(BFS)
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        IEnumerable<TVertex> BreadthFirstSearch(TVertex vertex);

        void Clear();
    }
}
