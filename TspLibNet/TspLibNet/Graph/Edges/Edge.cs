namespace TspLibNet.Graph.Edges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Graph edge class, first node have always lower id than the second node
    /// </summary>
    public class Edge : IEdge
    {
        /// <summary>
        /// Creates new instance of graph edge
        /// </summary>
        /// <param name="first">Edge first node</param>
        /// <param name="second">Edge second node</param>
        public Edge(INode first, INode second)
        {
            if (first == null)
            {
                throw new ArgumentNullException("first");
            }

            if (second == null)
            {
                throw new ArgumentNullException("second");
            }

            if (first.Id <= second.Id)
            {
                this.First = first;
                this.Second = second;
            }
            else
            {
                this.First = second;
                this.Second = first;
            }
        }

        /// <summary>
        /// Gets first edge node
        /// </summary>
        public INode First { get; protected set; }

        /// <summary>
        /// Gets second edge node
        /// </summary>
        public INode Second { get; protected set; }
    }
}
