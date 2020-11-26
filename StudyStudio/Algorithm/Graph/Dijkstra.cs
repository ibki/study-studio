using DataStructure.Graph;
using System;
using System.Collections.Generic;
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

        private  MinPriorityQueue<TVertex, long> _minPriorityQueue;

        private readonly TGraph _graph;
        private readonly TVertex _source;

        public Dijkstra(TGraph graph, TVertex source)
        {
            _graph = graph;
            _source = source;

            Initialize();
        }

        private void Initialize()
        {


            foreach (var i in _graph.Vertices)
            {

            }
        }
    }
}
