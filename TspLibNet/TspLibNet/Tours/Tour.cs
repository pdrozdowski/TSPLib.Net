namespace TspLibNet.Tours
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Tour class represents problem solution as a sequence of nodes to visit
    /// </summary>
    public class Tour : ITour
    {
        /// <summary>
        /// Gets file name - Identifies the data file.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Gets file comment - additional comments from problem author
        /// </summary>
        public string Comment { get; protected set; }

        /// <summary>
        /// Gets problem dimension
        /// </summary>
        public int Dimension { get; protected set; }

        /// <summary>
        /// Gets list of node id's to visit
        /// </summary>
        public List<int> Nodes { get; protected set; }
    }
}
