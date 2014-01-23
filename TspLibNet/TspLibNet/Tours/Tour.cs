namespace TspLibNet.Tours
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.TSP;

    /// <summary>
    /// Tour class represents problem solution as a sequence of nodes to visit
    /// </summary>
    public class Tour : ITour
    {
        /// <summary>
        /// Create new instance of Tour class.
        /// </summary>
        /// <param name="name">file name which identifies the data file</param>
        /// <param name="comment">additional comments from problem author</param>
        /// <param name="dimension">problem dimension</param>
        /// <param name="nodes">tour nodes</param>
        public Tour(string name, string comment, int dimension, IEnumerable<int> nodes)
        {
            if (dimension < 0)
            {
                throw new ArgumentOutOfRangeException("dimension");
            }

            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }

            this.Name = name;
            this.Comment = comment; 
            this.Dimension = dimension;
            this.Nodes = new List<int>(nodes);
            if (dimension == 0)
            {
                this.Dimension = this.Nodes.Count;
            }
        }

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

        /// <summary>
        /// Create tour from TSP file
        /// </summary>
        /// <param name="tspFile">tsp file to load from</param>
        /// <returns>Tour read from tsp file</returns>
        public static Tour FromTspFile(TspFile tspFile)
        {
            if (tspFile.Type != TSP.Defines.FileType.TOUR)
            {
                throw new ArgumentOutOfRangeException("tspFile");
            }

            return new Tour(tspFile.Name, tspFile.Comment, tspFile.Dimension, tspFile.Tour);
        }
    }
}
