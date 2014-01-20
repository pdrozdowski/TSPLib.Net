namespace TspLibNet.Graph.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Edges;

    /// <summary>
    /// Provides nodes by extracting them from given list of graph edges
    /// </summary>
    public class EdgeListBasedNodeProvider : INodeProvider
    {
        /// <summary>
        /// Creates new instance of EdgeListBasedNodeProvider
        /// </summary>
        /// <param name="edges">edge list initializing provider</param>
        public EdgeListBasedNodeProvider(IEnumerable<IEdge> edges)
        {
            if (edges == null)
            {
                throw new ArgumentNullException("matrix");
            }

            this.Nodes = new NodesCollection();
            HashSet<int> nodesToCreate = new HashSet<int>();
            foreach (IEdge edge in edges)
            {
                if (!nodesToCreate.Contains(edge.First.Id))
                {
                    nodesToCreate.Add(edge.First.Id);
                }

                if (!nodesToCreate.Contains(edge.Second.Id))
                {
                    nodesToCreate.Add(edge.Second.Id);
                }
            }

            foreach(int id in nodesToCreate)
            {
                this.Nodes.Add(new Node(id));
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
