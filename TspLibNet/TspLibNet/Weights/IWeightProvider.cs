namespace TspLibNet.Weights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graphs;

    /// <summary>
    /// Interface for providing an edge weight 
    /// </summary>
    public interface IWeightProvider
    {
        /// <summary>
        /// Get weight for given edge
        /// </summary>
        /// <param name="edge">edge to check</param>
        /// <returns>Weight of a given edge</returns>
        double Weight(IEdge edge);
    }
}
