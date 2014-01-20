namespace TspLibNet.Graph.Edges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Strongly typed edges collection
    /// </summary>
    public class EdgesCollection : List<IEdge>
    {
        /// <summary>
        /// Creates new instance of EdgesCollection
        /// </summary>
        public EdgesCollection()
        {
        }

        /// <summary>
        /// Creates new instance of EdgesCollection
        /// </summary>
        /// <param name="edges">range of edges to add initially</param>
        public EdgesCollection(IEnumerable<IEdge> edges)
            : base(edges)
        {
        }

        /// <summary>
        /// Find edge by given pair of nodes
        /// </summary>
        /// <param name="first">edge first node</param>
        /// <param name="second">edge second node</param>
        /// <returns>edge on given pair of nodes or null</returns>
        public IEdge FindEdge(INode first, INode second)
        {
            EdgesCollection edges = this.FilterByNode(first).FilterByNode(second);
            if (edges.Count > 0)
            {
                return edges[0];
            }

            return null;
        }

        /// <summary>
        /// Find edge with given node
        /// </summary>
        /// <param name="id">node id</param>
        /// <returns>node with given id or null</returns>
        public EdgesCollection FilterByNode(INode node)
        {
            EdgesCollection result = new EdgesCollection();
            foreach (IEdge edge in this)
            {
                if (edge.First.Id == node.Id || edge.Second.Id == node.Id)
                {
                    result.Add(edge);
                }
            }

            return result;
        }
    }
}
