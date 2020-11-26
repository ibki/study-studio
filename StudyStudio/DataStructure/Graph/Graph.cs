using DataStructure.List;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Graph
{
    public class Graph<TVertex> : IGraph<TVertex>
        where TVertex : IComparable<TVertex>
    {
        public bool IsDirected => true;

        public bool IsWeighted => true;

        #region Vertext

        public int VerticesCount => adjacencyList.Count;

        protected virtual Dictionary<TVertex, List<IEdge<TVertex>>> adjacencyList { get; set; }
            = new Dictionary<TVertex, List<IEdge<TVertex>>>();

        public IEnumerable<TVertex> Vertices => adjacencyList.Select(adjacent => adjacent.Key);

        public bool AddVertex(TVertex vertex)
        {
            if (HasVertex(vertex))
                return false;

            adjacencyList.Add(vertex, new List<IEdge<TVertex>>());

            return true;
        }

        public bool HasVertex(TVertex vertex) => adjacencyList.ContainsKey(vertex);

        public bool RemoveVertex(TVertex vertex)
        {
            if (HasVertex(vertex))
                return false;

            adjacencyList.Remove(vertex);

            foreach (var adjacent in adjacencyList)
            {
                for (var i = adjacent.Value.Count - 1; i >= 0; i--)
                {
                    var edge = adjacent.Value[i];
                    if (edge.Source.Equals(vertex) || edge.Destination.Equals(vertex))
                    {
                        adjacent.Value.RemoveAt(i);
                    }

                }
            }

            return true;
        }

        #endregion

        #region Edge

        protected virtual IEdge<TVertex> _tryGetEdge(TVertex source, TVertex destination)
        {
            if (!HasVertex(source) || !HasVertex(destination))
                return null;

            var sourceToDestinationPredicate = new Predicate<IEdge<TVertex>>((item)
                => item.Source.Equals(source) && item.Destination.Equals(destination));

            bool isFind = adjacencyList[source]
                .TryFindFirst(sourceToDestinationPredicate, out IEdge<TVertex> edge);

            if (isFind)
                return null;
            else
                return edge;
        }

        public IEnumerable<IEdge<TVertex>> Edges
        {
            get
            {
                foreach (var adjacent in adjacencyList)
                    foreach (var edge in adjacent.Value)
                        yield return edge;
            }
        }

        public bool HasEdge(TVertex source, TVertex destination) => _tryGetEdge(source, destination) != null;

        public bool AddEdge(TVertex source, TVertex destination, double weight)
        {
            if (!HasVertex(source) || !HasVertex(destination))
                return false;
            if (!HasEdge(source, destination))
                return false;

            var edge = new WeightedEdge<TVertex>(source, destination, weight);
            adjacencyList[source].Add(edge);

            return true;
        }

        public bool RemoveEdge(TVertex source, TVertex destination)
        {
            var edge = _tryGetEdge(source, destination);
            if (edge == null)
            {
                return false;
            }
            else
            {
                adjacencyList[source].Remove(edge);
                return true;
            }   
        }

        public IEnumerable<IEdge<TVertex>> IncomingEdges(TVertex vertex)
        {
            if (!HasVertex(vertex))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            var predicate = new Predicate<IEdge<TVertex>>((edge)
                => edge.Destination.Equals(vertex));

            foreach (var adjacent in adjacencyList.Keys)
            {
                if (adjacencyList[adjacent].TryFindFirst(predicate, out IEdge<TVertex> incomingEdge))
                    yield return incomingEdge;
            }
        }

        public IEnumerable<IEdge<TVertex>> OutgoingEdges(TVertex vertex)
        {
            if (!HasVertex(vertex))
                throw new KeyNotFoundException("Vertex doesn't belong to graph.");

            foreach (var edge in adjacencyList[vertex])
                yield return edge;
        }

        #endregion

        /// <summary>
        /// 너비 우선 탐색(BFS)
        /// <para>
        /// 시작 버텍스
        /// </para>
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public IEnumerable<TVertex> BreadthFirstSearch(TVertex vertex)
        {
            var listOfVertexes = new List<TVertex>();
            var visited = new HashSet<TVertex>();
            var queue = new Queue<TVertex>();

            listOfVertexes.Add(vertex);
            visited.Add(vertex);

            queue.Enqueue(vertex);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                var neighbours = Neighbours(current);

                foreach (var adjacent in neighbours)
                {
                    if (!visited.Contains(adjacent))
                    {
                        listOfVertexes.Add(adjacent);
                        visited.Add(adjacent);
                        queue.Enqueue(adjacent);
                    }
                }
            }

            return listOfVertexes;
        }

        /// <summary>
        /// 깊이 우선 탐색(DFS)
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        public IEnumerable<TVertex> DepthFirstSearch(TVertex vertex)
        {
            var listOfVertexes = new List<TVertex>();
            var visited = new HashSet<TVertex>();
            var stack = new Stack<TVertex>();

            stack.Push(vertex);

            while (stack.Count != 0)
            {
                var current = stack.Pop();

                if (!visited.Contains(current))
                {
                    listOfVertexes.Add(current);
                    visited.Add(current);

                    var neighbours = Neighbours(current);
                    foreach (var adjacent in neighbours)
                    {
                        if (!visited.Contains(adjacent))
                        {
                            stack.Push(adjacent);
                        }
                    }
                }
            }

            return listOfVertexes;
        }

        public void Clear()
        {
            adjacencyList.Clear();
        }

        public int Degree(TVertex vertex)
        {
            if (!HasVertex(vertex))
                throw new KeyNotFoundException();

            return adjacencyList[vertex].Count;
        }

        public IEnumerable<TVertex> Neighbours(TVertex vertex)
        {
            if (!HasVertex(vertex))
                return null;

            return adjacencyList[vertex].Select(m => m.Destination);
        }
    }
}
