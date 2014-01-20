namespace TspLibNet.Graph.Demand
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Interface for providing graph nodes demands
    /// </summary>
    public interface IDemandProvider
    {
        /// <summary>
        /// Get demand for given node
        /// </summary>
        /// <returns>Value of demand on a given node</returns>
        int GetDemand(INode node);
    }
}
