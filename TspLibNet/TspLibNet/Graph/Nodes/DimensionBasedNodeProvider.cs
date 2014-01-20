namespace TspLibNet.Graph.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Provides nodes by generating them accordingly to a problem dimension
    /// </summary>
    public class DimensionBasedNodeProvider : INodeProvider
    {
        /// <summary>
        /// Creates new instance of DimensionBasedNodeProvider
        /// </summary>
        /// <param name="dimension">dimension of problem initializing provider</param>
        public DimensionBasedNodeProvider(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentOutOfRangeException("dimension");
            }

            this.Nodes = new NodesCollection();
            for (int i = 0; i < dimension; i++)
            {
                this.Nodes.Add(new Node(i + 1));
            }
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
