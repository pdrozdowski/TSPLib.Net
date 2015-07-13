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
    using TspLibNet.Graph.Nodes;

    /// <summary>
    /// Weight provider based on weight matrix
    /// </summary>
    public class MatrixBasedWeightProvider : IEdgeWeightsProvider
    {
        /// <summary>
        /// Creates new instance of matrix based weight provider
        /// </summary>
        /// <param name="weights">matrix with weights</param>
        public MatrixBasedWeightProvider(double[,] weights)
        {
            if (weights == null)
            {
                throw new ArgumentNullException("weights");
            }

            if (weights.GetLength(0) != weights.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("weights");
            }

            this.Weights = weights;
        }

        /// <summary>
        /// Gets or sets weights matrix
        /// </summary>
        protected double[,] Weights { get; set; }

        /// <summary>
        /// Get weight for given edge
        /// </summary>
        /// <param name="first">first node of edge</param>
        /// <param name="second">second node of edge</param>
        /// <returns>Weight of a given edge</returns>
        public double GetWeight(INode first, INode second)
        {
            return this.Weights[first.Id - 1, second.Id - 1];
        }
    }
}
