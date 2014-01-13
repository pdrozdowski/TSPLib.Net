namespace TspLibNet.Graphs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Nodes;

    /// <summary>
    /// Interface for edge representation
    /// </summary>
    public interface IEdge
    {
        /// <summary>
        /// Gets first edge node
        /// </summary>
        INode First { get; }

        /// <summary>
        /// Gets second edge node
        /// </summary>
        INode Second { get; }
    }
}
