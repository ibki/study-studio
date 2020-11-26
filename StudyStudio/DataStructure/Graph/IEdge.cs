using System;

namespace DataStructure.Graph
{
    public interface IEdge<TVertex>
        where TVertex : IComparable<TVertex>
    {
        bool IsWeighted { get; }

        TVertex Source { get; set; }

        TVertex Destination { get; set; }

        double Weight { get; set; }
    } 
}
