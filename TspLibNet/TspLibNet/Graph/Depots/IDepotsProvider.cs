namespace TspLibNet.Graph.Depots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Interface for providing graph depot nodes
    /// </summary>
    public interface IDepotsProvider
    {
        /// <summary>
        /// Get all depot nodes in graph
        /// </summary>
        /// <returns>List of nodes</returns>
        List<INode> GetDepots();

        /// <summary>
        /// Get total number of depots
        /// </summary>
        /// <returns>Total number of depots</returns>
        int CountDepots();
    }
}
