namespace TspLibNet.Graphs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Nodes;

    /// <summary>
    /// Interface for a graph representation
    /// </summary>
    public interface IGraph
    {
        /// <summary>
        /// Find node by id
        /// </summary>
        /// <param name="id">node identifier</param>
        /// <returns>node with a specified identifier</returns>
        INode FindNode(int id);

        /// <summary>
        /// Find edges related to node
        /// </summary>
        /// <param name="node">node for which to get edges</param>
        /// <returns>edges connected to node</returns>
        List<IEdge> FindEdges(INode node);

        /// <summary>
        /// Gets all nodes
        /// </summary>
        List<INode> Nodes { get; }
        
        /// <summary>
        /// Gets node neighbour nodes
        /// </summary>
        /// <param name="node">node for which to get neighbour nodes</param>
        /// <returns>neighbour nodes to given node</returns>
        List<INode> FindNeighbours(INode node);
    }
}
