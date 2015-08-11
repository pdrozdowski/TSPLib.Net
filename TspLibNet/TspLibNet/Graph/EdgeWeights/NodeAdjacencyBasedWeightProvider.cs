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
    using TspLibNet.Graph.Edges;
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Hamiltonian Cycle Weight Provider
    /// </summary>
    public class NodeAdjacencyBasedWeightProvider : IEdgeWeightsProvider
    {
        /// <summary>
        /// Creates new instance of a node adjacency based weight provider
        /// </summary>
        /// <param name="edgeProvider">distance function to be used</param>
        /// <param name="adjacentWeight">weight for adjacent nodes</param>
        /// <param name="nonAdjacentWeight">weight for non-adjacent nodes</param>
        public NodeAdjacencyBasedWeightProvider(IEdgeProvider edgeProvider, double adjacentWeight, double nonAdjacentWeight)
        {
            if (edgeProvider == null)
            {
                throw new ArgumentNullException("edgeProvider");
            }

            this.EdgeProvider = edgeProvider;
            this.AdjacentWeight = adjacentWeight;
            this.NotAdjacentWeight = nonAdjacentWeight;
        }

        /// <summary>
        /// Gets or sets distance function in use
        /// </summary>
        protected IEdgeProvider EdgeProvider { get; set; }

        /// <summary>
        /// Gets or sets weight when nodes are adjacent
        /// </summary>
        protected double AdjacentWeight { get; set; }

        /// <summary>
        /// Gets or sets weight when nodes are not adjacent
        /// </summary>
        protected double NotAdjacentWeight { get; set; }

        /// <summary>
        /// Get weight for given edge
        /// </summary>
        /// <param name="first">first node of edge</param>
        /// <param name="second">second node of edge</param>
        /// <returns>Weight of a given edge</returns>
        public double GetWeight(INode first, INode second)
        {
            // adjacent cities has a distance of 1, all other have distance of 2
            return this.EdgeProvider.HasEdge(first, second) ? this.AdjacentWeight : this.NotAdjacentWeight;
        }
    }
}