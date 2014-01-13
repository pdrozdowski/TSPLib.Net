namespace TspLibNet.Graphs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Nodes;

    /// <summary>
    /// Node and its adjecenct nodes
    /// </summary>
    public class NodeAdjacency
    {
        /// <summary>
        /// Creates new instance of NodeAdjacency
        /// </summary>
        /// <param name="node">Node for which to add adjacencies</param>
        /// <param name="adjecenctNodes">Node adjacencies</param>
        public NodeAdjacency(INode node, IEnumerable<INode> adjecenctNodes)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            if (adjecenctNodes == null)
            {
                throw new ArgumentNullException("adjecenctNodes");
            }

            this.Node = node;
            this.AdjacenctNodes = new List<INode>(adjecenctNodes);
        }

        /// <summary>
        /// Gets a node
        /// </summary>
        public INode Node { get; protected set; }

        /// <summary>
        /// Gets a node adjecent nodes
        /// </summary>
        public List<INode> AdjacenctNodes { get; protected set; }
    }
}
