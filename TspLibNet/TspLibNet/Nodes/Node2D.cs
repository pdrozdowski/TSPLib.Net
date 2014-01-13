namespace TspLibNet.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Represents graph 2D node
    /// </summary>
    public class Node2D : INode
    {
        /// <summary>
        /// Creates a new instance of graph node
        /// </summary>
        /// <param name="id">node id</param>
        /// <param name="x">node x coordinate</param>
        /// <param name="y">node y coordinate</param>
        public Node2D(int id, double x, double y)
        {
            this.Id = id;
            this.X = x;
            this.Y = y;
        }
        
        /// <summary>
        /// Gets node Id
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Gets node X coordinate
        /// </summary>
        public double X { get; protected set; }

        /// <summary>
        /// Gets node Y coordinate
        /// </summary>
        public double Y { get; protected set; }
    }
}
