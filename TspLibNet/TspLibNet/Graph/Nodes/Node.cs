namespace TspLibNet.Graph.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents graph node without any coordinates
    /// </summary>
    public class Node : INode
    {
        /// <summary>
        /// Creates a new instance of graph node
        /// </summary>
        /// <param name="id">node id</param>
        public Node(int id)
        {
            this.Id = id;
        }
        
        /// <summary>
        /// Gets node Id
        /// </summary>
        public int Id { get; protected set; }
    }
}
