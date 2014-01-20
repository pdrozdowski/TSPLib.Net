namespace TspLibNet.Graph.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Strongly typed nodes collection
    /// </summary>
    public class NodesCollection : List<INode>
    {
        /// <summary>
        /// Creates new instance of NodesCollection
        /// </summary>
        public NodesCollection()
        {
        }

        /// <summary>
        /// Creates new instance of NodesCollection
        /// </summary>
        /// <param name="nodes">range of nodes to add initially</param>
        public NodesCollection(IEnumerable<INode> nodes)
            : base(nodes)
        {
        }

        /// <summary>
        /// Find node by id
        /// </summary>
        /// <param name="id">node id</param>
        /// <returns>node with given id or null</returns>
        public INode FindById(int id)
        {
            foreach (INode node in this)
            {
                if (node.Id == id)
                {
                    return node;
                }
            }

            return null;
        }
    }
}
