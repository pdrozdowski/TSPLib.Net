/* The MIT License (MIT)
*
* Copyright (c) 2014 Pawel Drozdowski
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
    using System;
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
            double q3 = Math.Cos(aGeo.Latitude + bGeo.Latitude);
            double q1q2 = (1.0 + q1) * q2;
            double q1q3 = (1.0 - q1) * q3;
            double d2 = (q1q2 - q1q3) / 2;
            return (int)(Geographical.EarthSphereRadius * Math.Acos(d2)) + 1;
        }
    }
}
