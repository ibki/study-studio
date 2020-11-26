using System;

namespace DataStructure.Graph
{
    public class WeightedEdge<TVertex> : IEdge<TVertex>
        where TVertex : IComparable<TVertex>
    {
        public bool IsWeighted => true;

        public TVertex Source { get; set; }

        public TVertex Destination { get; set; }

        public double Weight { get; set; }

        public WeightedEdge(TVertex source, TVertex destination, double weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }
    }
}
