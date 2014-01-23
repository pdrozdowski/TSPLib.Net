namespace TspLibNet.Graph.EdgeWeights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
