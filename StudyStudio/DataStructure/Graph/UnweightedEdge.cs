using System;

namespace DataStructure.Graph
{
    public class UnweightedEdge<TVertex> : IEdge<TVertex>
        where TVertex : IComparable<TVertex>
    {
        public bool IsWeighted => false;

        public TVertex Source { get; set; }

        public TVertex Destination { get; set; }

        public double Weight
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException();
        }

        public UnweightedEdge(TVertex source, TVertex destination)
        {
            Source = source;
            Destination = destination;
        }
    }
}
