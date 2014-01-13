namespace TspLibNet.Graphs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Nodes;

    /// <summary>
    /// Edge representation as an adjecency list 
    /// </summary>
    public class NodeAdjacencyList : IGraph
    {        
        /// <summary>
        /// Gets a nodes and their adjecencies
        /// </summary>
        public List<NodeAdjacency> NodeAdjacencies { get; protected set; }

        /// <summary>
        /// Add node adjacency to graph
        /// </summary>
        /// <param name="nodeAdjacency">node adjacency to add</param>
        public void Add(NodeAdjacency nodeAdjacency)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add range of node adjacencies to graph
        /// </summary>
        /// <param name="nodeAdjacency">node adjacencies to add</param>
        public void AddRange(IEnumerable<NodeAdjacency> nodeAdjacency)
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
