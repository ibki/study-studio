using DataStructure.Graph;
using DataStructure.Heap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.Graph
{
    public class Dijkstra<TGraph, TVertex>
        where TGraph : IGraph<TVertex>
        where TVertex : IComparable<TVertex>
    {
        private const double Infinity = double.MaxValue;
        private const int NilPredecessor = -1;

        private double[] distances;
        private int[] predecessors;

        private Dictionary<TVertex, int> nodesToIndices;
        private Dictionary<int, TVertex> indicesToNodes;

        private PriorityQueue<TVertex, double> priorityQueue;

        private readonly TGraph graph;
        private readonly TVertex source;

        public Dijkstra(TGraph graph, TVertex source)
        {
            this.graph = graph;
            this.source = source;

            Initialize();
            DijkstraAlgorithm();
        }

        private void Initialize()
        {
            int verticesCount = graph.VerticesCount;

            distances = new double[verticesCount];
            predecessors = new int[verticesCount];

            nodesToIndices = new Dictionary<TVertex, int>();
            indicesToNodes = new Dictionary<int, TVertex>();

            priorityQueue = new PriorityQueue<TVertex, double>();

            int i = 0;
            foreach (var vertex in graph.Vertices)
            {
                // Set distance to infinity value for all nodes except start node
                if (source.Equals(vertex))
                {
                    distances[i] = 0;
                    predecessors[i] = 0;
                }
                else
                {
                    distances[i] = Infinity;
                    predecessors[i] = NilPredecessor;
                }

                priorityQueue.Enqueue(vertex, distances[i]);

                nodesToIndices.Add(vertex, i);
                indicesToNodes.Add(i, vertex);
                i++;
            }
        }

        private void DijkstraAlgorithm()
        {
            while (!priorityQueue.IsEmpty)
            {
                var currentVertex = priorityQueue.Dequeue();
                var currentVertexIndex = nodesToIndices[currentVertex];

                var outgoingEdges = graph.OutgoingEdges(currentVertex);
                foreach (var outgoingEdge in outgoingEdges)
                {
                    var adjacentIndex = nodesToIndices[outgoingEdge.Destination];
                    var delta = distances[currentVertexIndex] != Infinity ?
                        distances[currentVertexIndex] + outgoingEdge.Weight :
                        Infinity;

                    if (delta < distances[adjacentIndex])
                    {
                        distances[adjacentIndex] = delta;
                        predecessors[adjacentIndex] = currentVertexIndex;

                        priorityQueue.UpdatePriority(outgoingEdge.Destination, delta);
                    }
                }
            }
        }

        public bool HasPathTo(TVertex destination)
        {
            if (!nodesToIndices.ContainsKey(destination))
                throw new ArgumentException("Graph doesn't have the specified vertex.");

            var index = nodesToIndices[destination];
            return distances[index] != Infinity;
        }

        public IEnumerable<TVertex> ShortestPathTo(TVertex destination)
        {
            if (!nodesToIndices.ContainsKey(destination))
                throw new ArgumentException("Graph doesn't have the specified vertex.");

            if (!HasPathTo(destination))
                return null;

            var dstIndex = nodesToIndices[destination];
            var stack = new Stack<TVertex>();

            int index;
            for (index = dstIndex; distances[index] != 0; index = predecessors[index])
            {
                stack.Push(indicesToNodes[index]);
            }
            stack.Push(indicesToNodes[index]);

            return stack;
        }
    }
}
