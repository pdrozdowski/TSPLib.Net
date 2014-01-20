namespace TspLibNet.Graph.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Provides nodes by extracting them directly from a list of graph nodes
    /// </summary>
    public class NodeListBasedNodeProvider : INodeProvider
    {
        /// <summary>
        /// Creates new instance of NodeListBasedNodeProvider
        /// </summary>
        /// <param name="nodes">list of nodes initializing provider</param>
        public NodeListBasedNodeProvider(IEnumerable<INode> nodes)
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
        /// Get all nodes in graph
        /// </summary>
        /// <returns>List of nodes</returns>
        public List<INode> GetNodes()
        {
            return new List<INode>(this.Nodes);
        }

        /// <summary>
        /// Get node with a given id
        /// </summary>
        /// <param name="id">node id</param>
        /// <returns>Node with a given id or null</returns>
        public INode GetNode(int id)
        {
            return this.Nodes.FindById(id);
        }

        /// <summary>
        /// Get total number of nodes
        /// </summary>
        /// <returns>Total number of nodes</returns>
        public int CountNodes()
        {
            return this.Nodes.Count;
        }
    }
}
