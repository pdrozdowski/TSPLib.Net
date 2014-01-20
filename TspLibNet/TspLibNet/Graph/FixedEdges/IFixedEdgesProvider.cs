namespace TspLibNet.Graph.FixedEdges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Edges;

    /// <summary>
    /// Interface for providing fixed edges, edges that must be a part of a solution
    /// </summary>
    public interface IFixedEdgesProvider
    {
        /// <summary>
        /// Get fixed edges in given graph
        /// </summary>
        /// <returns>List of fixed edges</returns>
        List<IEdge> GetFixedEdges();

        /// <summary>
        /// Get number of fixed edges in given graph
        /// </summary>
        /// <returns>Number of fixed edges</returns>
        int CountFixedEdges();
    }
}
