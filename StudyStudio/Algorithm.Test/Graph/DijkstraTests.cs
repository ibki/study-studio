using Algorithm.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Algorithm.Test.Graph
{
    [TestClass]
    public class DijkstraTests
    {
        private readonly DataStructure.Graph.Graph<int> graph = new DataStructure.Graph.Graph<int>();
        
        public DijkstraTests()
        {
            for (int i = 0; i <= 7; i++)
            {
                graph.AddVertex(i);
            }

            graph.AddEdge(0, 1, 2);
            graph.AddEdge(0, 2, 2);
            graph.AddEdge(0, 3, 5);

            graph.AddEdge(1, 3, 2);
            graph.AddEdge(1, 4, 5);

            graph.AddEdge(2, 3, 1);
            graph.AddEdge(2, 5, 5);

            graph.AddEdge(3, 4, 2);
            graph.AddEdge(3, 5, 1);

            graph.AddEdge(4, 5, 1);
            graph.AddEdge(4, 6, 2);

            graph.AddEdge(5, 4, 1);
            graph.AddEdge(5, 6, 1);
        }

        [TestMethod]
        public void HasPathTo_NoPath_ReturnFalse()
        {
            // Arrage
            var dijkstra = new Dijkstra<DataStructure.Graph.Graph<int>, int>(graph, 0);

            // Act
            bool hasPath = dijkstra.HasPathTo(graph.VerticesCount - 1);

            // Assert
            Assert.IsFalse(hasPath);
        }

        [TestMethod]
        public void HasPathTo_NoVertex_ThrowArgumentException()
        {
            // Arrage
            var dijkstra = new Dijkstra<DataStructure.Graph.Graph<int>, int>(graph, 0);

            // Act => Assert
            Assert.ThrowsException<ArgumentException>(() => dijkstra.HasPathTo(graph.VerticesCount));
        }

        [TestMethod]
        public void ShortestPathTo_NormalPath_ReturnShortestPath()
        {
            // Arrage
            var dijkstra = new Dijkstra<DataStructure.Graph.Graph<int>, int>(graph, 0);

            // Act
            var paths = dijkstra.ShortestPathTo(graph.VerticesCount - 2).ToArray();

            // Assert
            Assert.AreEqual(0, paths[0]);
            Assert.AreEqual(2, paths[1]);
            Assert.AreEqual(3, paths[2]);
            Assert.AreEqual(4, paths[3]);
            Assert.AreEqual(5, paths[4]);
        }
    }
}
