namespace TspLibNet.Tours
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Tour interface represents problem solution as a sequence of nodes to visit
    /// </summary>
    public interface ITour
    {
        /// <summary>
        /// Gets file name - Identifies the data file.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets file comment - additional comments from problem author
        /// </summary>
        string Comment { get; }

        /// <summary>
        /// Gets problem dimension
        /// </summary>
        int Dimension { get; }

        /// <summary>
        /// Gets list of node id's to visit
        /// </summary>
        List<int> Nodes { get; }
    }
}
