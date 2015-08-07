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
namespace TspLibNet.Graph.Edges
{
    using System;
    using System.Collections.Generic;
    using TspLibNet.Graph.Nodes;
    using TspLibNet.Exceptions;

    /// <summary>
    /// Provides edges by looking up edge weight matrix, weights from exclusion list are treated as a lack of edge
    /// </summary>
    public class WeightMatrixBasedEdgeProviderWithExclusions : IEdgeProvider
    {
        /// <summary>
        /// Creates a new instance of a WeightMatrixBasedEdgeProviderWithExclusions class
        /// </summary>
        /// <param name="matrix">weight matrix initializing edge provider</param>
        /// <param name="exclusions">weights exclusions</param>
        public WeightMatrixBasedEdgeProviderWithExclusions(double[,] matrix, IEnumerable<double> exclusions)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("matrix");
            }

            if (matrix.GetLength(0) != matrix.GetLength(1))
            {
                throw new ArgumentOutOfRangeException("weights");
            }

            if (exclusions == null)
            {
                throw new ArgumentNullException("exclusions");
            }

            this.WeightsMatrix = matrix;
            this.Exclusions = new List<double>(exclusions);
        }

        /// <summary>
        /// Gets or sets collection of fixed edges
        /// </summary>
        public double[,] WeightsMatrix { get; protected set; }

        /// <summary>
        /// Gets or sets list of weight exclusions
        /// </summary>
        public List<double> Exclusions { get; protected set; }

        /// <summary>
        /// Get edge between given nodes
        /// </summary>
        /// <param name="first">first node to check</param>
        /// <param name="second">second node to check</param>
        /// <returns>Edge between given nodes or null</returns>
        public IEdge GetEdge(INode first, INode second)
        {
            if (this.HasEdge(first, second))
            {
                return new Edge(first, second);
            }

            return null;
        }

        /// <summary>
        /// Checks if there is edge between given nodes
        /// </summary>
        /// <param name="first">first node to check</param>
        /// <param name="second">second node to check</param>
        /// <returns>Indicates if there is an edge between given nodes</returns>
        public bool HasEdge(INode first, INode second)
        {
            int dimension = this.WeightsMatrix.GetLength(0);
            if (first.Id < 1 || first.Id > dimension)
            {
                throw new GraphException("First node seems not to be a part of a graph");
            }

            if (second.Id < 1 || second.Id > dimension)
            {
                throw new GraphException("First node seems not to be a part of a graph");
            }

            double weight = this.WeightsMatrix[first.Id - 1, second.Id - 1];
            return !this.Exclusions.Contains(weight);
        }

        /// <summary>
        /// Get total number of edges
        /// </summary>
        /// <returns>Total number of edges</returns>
        public int CountEdges()
        {
            int count = 0;
            for (int x = 0; x < this.WeightsMatrix.GetLength(0); x++)
            {
                for (int y = x; y < this.WeightsMatrix.GetLength(0); y++)
                {
                    double weight = this.WeightsMatrix[x, y];
                    if (!this.Exclusions.Contains(weight))
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
