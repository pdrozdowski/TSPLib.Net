namespace TspLibNet.Graph.EdgeWeights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Interface for providing an edge weights
    /// </summary>
    public interface IEdgeWeightsProvider
    {
        /// <summary>
        /// Get weight for given edge
        /// </summary>
        /// <param name="first">first node of edge</param>
        /// <param name="second">second node of edge</param>
        /// <returns>Weight of a given edge</returns>
        double GetWeight(INode first, INode second);
    }
}
