namespace TspLibNet.Graph.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Interface for providing graph nodes
    /// </summary>
    public interface INodeProvider
    {
        /// <summary>
        /// Get all nodes in graph
        /// </summary>
        /// <returns>List of nodes</returns>
        List<INode> GetNodes();

        /// <summary>
        /// Get node with a given id
        /// </summary>
        /// <param name="id">node id</param>
        /// <returns>Node with a given id or null</returns>
        INode GetNode(int id);

        /// <summary>
        /// Get total number of nodes
        /// </summary>
        /// <returns>Total number of nodes</returns>
        int CountNodes();
    }
}
