namespace TspLibNet.Graph.Edges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Provides edge basing on a list of edges
    /// </summary>
    public class EdgeListBasedEdgeProvider : IEdgeProvider
    {
        /// <summary>
        /// Creates new instance of a EdgeListBasedEdgeProvider class.
        /// </summary>
        /// <param name="fixedEdges">list of edges</param>
        public EdgeListBasedEdgeProvider(IEnumerable<IEdge> edges)
        {
            if (edges == null)
            {
                throw new ArgumentNullException("edges");
            }

            this.Edges = new EdgesCollection(edges);
        }

        /// <summary>
        /// Gets or sets collection of fixed edges
        /// </summary>
        public EdgesCollection Edges { get; protected set; }

        /// <summary>
        /// Get edge between given nodes
        /// </summary>
        /// <param name="first">first node to check</param>
        /// <param name="second">second node to check</param>
        /// <returns>Edge between given nodes or null</returns>
        public IEdge GetEdge(INode first, INode second)
        {
            return this.Edges.FindEdge(first, second);
        }

        /// <summary>
        /// Checks if there is edge between given nodes
        /// </summary>
        /// <param name="first">first node to check</param>
        /// <param name="second">second node to check</param>
        /// <returns>Indicates if there is an edge between given nodes</returns>
        public bool HasEdge(INode first, INode second)
        {
            return this.Edges.FindEdge(first, second) != null;
        }

        /// <summary>
        /// Get total number of edges
        /// </summary>
        /// <returns>Total number of edges</returns>
        public int CountEdges()
        {
            return this.Edges.Count;
        }
    }
}
