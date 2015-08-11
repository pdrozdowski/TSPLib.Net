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

namespace TspLibNet.Graph.EdgeWeights
{
    using System;
    using System.Collections.Generic;
    using TspLibNet.DistanceFunctions;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Weight provider based on distance function that is able to cache deistances get from distance function for reuse
    /// </summary>
    public class FunctionBasedWeightProviderWithCaching : IEdgeWeightsProvider
    {
        /// <summary>
        /// Creates new instance of a function based weight provider
        /// </summary>
        /// <param name="distanceFunction">distance function to be used</param>
        public FunctionBasedWeightProviderWithCaching(IDistanceFunction distanceFunction)
        {
            if (distanceFunction == null)
            {
                throw new ArgumentNullException("distanceFunction");
            }

            this.DistanceFunction = distanceFunction;
            this.DistancesCache = new Dictionary<string, double>();
        }

        /// <summary>
        /// Gets or sets distances cache
        /// </summary>
        public Dictionary<string, double> DistancesCache { get; protected set; }

        /// <summary>
        /// Gets or sets distance function in use
        /// </summary>
        protected IDistanceFunction DistanceFunction { get; set; }

        /// <summary>
        /// Get weight for given edge
        /// </summary>
        /// <param name="first">first node of edge</param>
        /// <param name="second">second node of edge</param>
        /// <returns>Weight of a given edge</returns>
        public double GetWeight(INode first, INode second)
        {
            string key = first + ":" + second;
            if (!this.DistancesCache.ContainsKey(key))
            {
                this.DistancesCache.Add(key, this.DistanceFunction.Distance(first, second));
            }

            return this.DistancesCache[key];
        }
    }
}