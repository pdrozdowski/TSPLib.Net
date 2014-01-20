namespace TspLibNet.Graph.Depots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Provides depot nodes by extracting them directly from a list of depot nodes
    /// </summary>
    public class NodeListBasedDepotProvider : IDepotsProvider
    {
        /// <summary>
        /// Creates new instance of NodeListBasedDepotProvider
        /// </summary>
        /// <param name="nodes">list of depot nodes initializing provider</param>
        public NodeListBasedDepotProvider(IEnumerable<INode> nodes)
        {
            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }

            this.Nodes = new NodesCollection(nodes);
        }

        /// <summary>
        /// Gets or sets providers nodes
        /// </summary>
        public NodesCollection Nodes { get; protected set; }

        /// <summary>
        /// Get all depot nodes in graph
        /// </summary>
        /// <returns>List of nodes</returns>
        public List<INode> GetDepots()
        {
            return new List<INode>(this.Nodes);
        }

        /// <summary>
        /// Get total number of depots
        /// </summary>
        /// <returns>Total number of depots</returns>
        public int CountDepots()
        {
            return this.Nodes.Count;
        }
    }
}
