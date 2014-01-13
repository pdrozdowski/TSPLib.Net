namespace TspLibNet.Graphs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Nodes;

    /// <summary>
    /// Pair of nodes
    /// </summary>
    public class NodePair
    {
        /// <summary>
        /// Creates new instance of NodePair
        /// </summary>
        /// <param name="firstNode">first node</param>
        /// <param name="secondNode">second node</param>
        public NodePair(INode firstNode, INode secondNode)
        {
            if (firstNode == null)
            {
                throw new NotImplementedException("firstNode");
            }

            if (secondNode == null)
            {
                throw new NotImplementedException("secondNode");
            }

            this.FirstNode = firstNode;
            this.SecondNode = secondNode;
        }

        /// <summary>
        /// Gets a first node
        /// </summary>
        public INode FirstNode { get; protected set; }

        /// <summary>
        /// Gets a second node
        /// </summary>
        public INode SecondNode { get; protected set; }
    }
}
