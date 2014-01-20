namespace TspLibNet.DistanceFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Extensions;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Pseudo Euclidean distance function
    /// </summary>
    public class PseudoEuclidean : DistanceFunctionBase
    {
        /// <summary>
        /// Gets distance from node A to node B
        /// </summary>
        /// <param name="a">node A</param>
        /// <param name="b">node B</param>
        /// <returns>Distance between node A and node B</returns>
        public override double Distance(Node2D a, Node2D b)
        {
            double xd = a.X - b.X;
            double yd = a.Y - b.Y;
            double r = Math.Sqrt((xd * xd + yd * yd) / 10.0);
            double t = MathExtensions.NearestInt(r);
            if (t < r)
            {
                return t + 1;
            }

            return t;
        }
    }
}
