namespace TspLibNet.Graphs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Nodes;

    /// <summary>
    /// Edge representation as an list of node pairs
    /// </summary>
    public class NodePairsList : IGraph
    {
        /// <summary>
        /// Gets a node pairs
        /// </summary>
        public List<NodePair> NodePairs { get; protected set; }

        /// <summary>
        /// Adds node pair to graph
        /// </summary>
        /// <param name="node">Node pair to add</param>
        public void Add(NodePair nodePair)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds rage of node pairs to graph
        /// </summary>
        /// <param name="nodes">Range of node pairs to add</param>
        public void AddRange(IEnumerable<NodePair> nodePairs)
        {
            throw new NotImplementedException();
        }

        #region IGraph implementation
        /// <summary>
        /// Find node by id
        /// </summary>
        /// <param name="id">node identifier</param>
        /// <returns>node with a specified identifier</returns>
        public INode FindNode(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Find edges related to node
        /// </summary>
        /// <param name="node">node for which to get edges</param>
        /// <returns>edges connected to node</returns>
        public List<IEdge> FindEdges(INode node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all nodes
        /// </summary>
        public List<INode> Nodes { get; protected set; }

        /// <summary>
        /// Gets node neighbour nodes
        /// </summary>
        /// <param name="node">node for which to get neighbour nodes</param>
        /// <returns>neighbour nodes to given node</returns>
        public List<INode> FindNeighbours(INode node)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
