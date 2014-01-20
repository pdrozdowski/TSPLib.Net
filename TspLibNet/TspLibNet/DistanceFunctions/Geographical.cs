namespace TspLibNet.DistanceFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Geographical distance function
    /// </summary>
    public class Geographical : DistanceFunctionBase
    {
        /// <summary>
        /// Approximate earth sphere radius in kilometers
        /// </summary>
        public const double EarthSphereRadius = 6378.388;

        /// <summary>
        /// Gets distance from node A to node B
        /// </summary>
        /// <param name="a">node A</param>
        /// <param name="b">node B</param>
        /// <returns>Distance between node A and node B</returns>
        public override double Distance(Node2D a, Node2D b)
        {
            GeoLocation aGeo = new GeoLocation(a);
            GeoLocation bGeo = new GeoLocation(b);

            double q1 = Math.Cos(aGeo.Longitude - bGeo.Longitude);
            double q2 = Math.Cos(aGeo.Latitude - bGeo.Latitude);
            double q3 = Math.Cos(aGeo.Latitude + aGeo.Latitude);

            return (int)(Geographical.EarthSphereRadius * Math.Acos(0.5 * ((1.0 + q1) * q2 - (1.0 - q1) * q3)) + 1.0);
        }
    }
}
