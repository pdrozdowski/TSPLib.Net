namespace TspLibNet.DistanceFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Extensions;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Manhattan distance function
    /// </summary>
    public class Manhattan : DistanceFunctionBase
    {
        /// <summary>
        /// Gets distance from node A to node B
        /// </summary>
        /// <param name="a">node A</param>
        /// <param name="b">node B</param>
        /// <returns>Distance between node A and node B</returns>
        public override double Distance(Node2D a, Node2D b)
        {
            double xd = Math.Abs(a.X - b.X);
            double yd = Math.Abs(a.Y - b.Y);
            return MathExtensions.NearestInt(xd + yd);
        }

        /// <summary>
        /// Gets distance from node A to node B
        /// </summary>
        /// <param name="a">node A</param>
        /// <param name="b">node B</param>
        /// <returns>Distance between node A and node B</returns>
        public override double Distance(Node3D a, Node3D b)
        {
            double xd = Math.Abs(a.X - b.X);
            double yd = Math.Abs(a.Y - b.Y);
            double zd = Math.Abs(a.Z - b.Z);
            return MathExtensions.NearestInt(xd + yd + zd);
        }
    }
}
