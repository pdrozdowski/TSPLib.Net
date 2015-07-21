/* The MIT License (MIT)
*
* Original Work Copyright (c) 2014 Pawel Drozdowski
* Modified Work Copyright (c) 2015 William Hallatt
*
* Permission is hereby granted, free of charge, to any person obtaining a copy of
* this software and associated documentation files (the "Software"), to deal in
* the Software without restriction, including without limitation the rights to
* use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
* the Software, and to permit persons to whom the Software is furnished to do so,
* subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
* FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
* COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
* IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
* CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace TspLibNet.DistanceFunctions
{
    using Graph.Nodes;
    using System;

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
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Creates a new instance of geographical location from 2D node
        /// </summary>
        /// <param name="node">node to convert to geo location</param>
        public GeoLocation(Node2D node)
        {
            Latitude = CalcGeoValue(node.X);
            Longitude = CalcGeoValue(node.Y);
        }

        /// <summary>
        /// Gets location latitude
        /// </summary>
        public double Latitude { get; protected set; }

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
            var min = value - deg;
            var rad = deg + (5.0 * min) / 3.0;
            return (Math.PI * rad) / 180.0;
        }
    }
}