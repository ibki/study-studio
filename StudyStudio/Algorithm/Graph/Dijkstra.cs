using DataStructure.Graph;
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

        private double[] _distances;
        private int[] _predecessors;

        private Dictionary<TVertex, int> nodesToIndices;
        private Dictionary<int, TVertex> indicesToNodes;

        private Queue<(TVertex, double)> _priorityQueue;

        private readonly TGraph _graph;
        private readonly TVertex _source;

        public Dijkstra(TGraph graph, TVertex source)
        {
            _graph = graph;
            _source = source;

            Initialize();
            DijkstraAlgorithm();
        }

        private void Initialize()
        {
            int verticesCount = _graph.VerticesCount;

            _distances = new double[verticesCount];
            _predecessors = new int[verticesCount];

            int i = 0;
            foreach (var vertex in _graph.Vertices)
            {
                // Set distance to infinity value for all nodes except start node
                if (_source.Equals(vertex))
                {
                    _distances[i] = 0;
                    _predecessors[i] = 0;
                }
                else
                {
                    _distances[i] = Infinity;
                    _predecessors[i] = NilPredecessor;
                }

                _priorityQueue.Enqueue((vertex, _distances[i]));

                nodesToIndices.Add(vertex, i);
                indicesToNodes.Add(i, vertex);
                i++;
            }
        }

        private void DijkstraAlgorithm()
        {
            while (_priorityQueue.Count != 0)
            {
                var a = _priorityQueue.Min(m => m.Item2);
                _priorityQueue.Dequeue();

                //_graph.OutgoingEdges()
            }
        }
    }
}
