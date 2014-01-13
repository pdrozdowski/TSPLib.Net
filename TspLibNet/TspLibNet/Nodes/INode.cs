namespace TspLibNet.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Interface for a graph node
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Gets node Id
        /// </summary>
        int Id { get; }
    }
}
