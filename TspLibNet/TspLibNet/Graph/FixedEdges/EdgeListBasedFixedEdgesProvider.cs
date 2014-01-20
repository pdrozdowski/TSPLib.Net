namespace TspLibNet.Graph.FixedEdges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Edges;

    /// <summary>
    /// Provides fixed edges basing on a given list of edges
    /// </summary>
    public class EdgeListBasedFixedEdgesProvider : IFixedEdgesProvider
    {
        /// <summary>
        /// Creates new instance of a EdgeListBasedFixedEdgesProvider class.
        /// </summary>
        /// <param name="fixedEdges">list of fixed edges</param>
        public EdgeListBasedFixedEdgesProvider(IEnumerable<IEdge> fixedEdges)
        {
            if (fixedEdges == null)
            {
                throw new ArgumentNullException("fixedEdges");
            }

            this.FixedEdges = new EdgesCollection(fixedEdges);
        }

        /// <summary>
        /// Gets or sets collection of fixed edges
        /// </summary>
        public EdgesCollection FixedEdges { get; protected set; }

        /// <summary>
        /// Get fixed edges in given graph
        /// </summary>
        /// <returns>List of fixed edges</returns>
        public List<IEdge> GetFixedEdges()
        {
            return new List<IEdge>(this.FixedEdges);
        }

        /// <summary>
        /// Get number of fixed edges in given graph
        /// </summary>
        /// <returns>Number of fixed edges</returns>
        public int CountFixedEdges()
        {
            return this.FixedEdges.Count;
        }
    }
}
