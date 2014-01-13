namespace TspLibNet.Defines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Format of edges of a graph
    /// </summary>
    public enum EdgeDataFormat
    {
        /// <summary>
        /// Format is not defined
        /// </summary>
        Undefined,

        /// <summary>
        /// The graph is given by an edge list
        /// </summary>
        EdgeList,

        /// <summary>
        /// The graph is given as an adjacency list
        /// </summary>
        AdjacencyList,


    }
}
