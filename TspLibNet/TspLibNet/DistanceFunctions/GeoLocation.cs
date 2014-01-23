namespace TspLibNet.DistanceFunctions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Extensions;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Geographical location representation
    /// </summary>
    public class GeoLocation
    {
        /// <summary>
        /// Creates a new instance of geographical location
        /// </summary>
        /// <param name="latitude">location latitude</param>
        /// <param name="longitude">location longitude</param>
        public GeoLocation(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Creates a new instance of geographical locationfrom 2D node
        /// </summary>
        /// <param name="node">node to convert to geo location</param>
        public GeoLocation(Node2D node)
        {
            this.Latitude = this.CalcGeoValue(node.X);
            this.Longitude = this.CalcGeoValue(node.Y);
        }

        /// <summary>
        /// Gets location latitude
        /// </summary>
        public double Latitude { get; protected set;}

        /// <summary>
        /// Gets location longitude
        /// </summary>
        public double Longitude { get; protected set; }

        /// <summary>
        /// Converts 2D space value into geographical location value
        /// </summary>
        /// <param name="value">value to convert</param>
        /// <returns>converted value</returns>
        protected double CalcGeoValue(double value)
        {
            double deg = (int)(value);
            double min = value - deg;
            double rad = deg + (5.0 * min) / 3.0;
            return (Math.PI * rad) / 180.0;
        }
    }
}
