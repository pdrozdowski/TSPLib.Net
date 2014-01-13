namespace TspLibNet.Weights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graphs;

    /// <summary>
    /// Weight provider based on weight matrix
    /// </summary>
    public class MatrixBasedProvider : IWeightProvider
    {
        /// <summary>
        /// Creates new instance of matrix based weight provider
        /// </summary>
        /// <param name="weights">matrix with weights</param>
        public MatrixBasedProvider(double[,] weights)
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
        /// <param name="edge">edge to check</param>
        /// <returns>Weight of a given edge</returns>
        public double Weight(IEdge edge)
        {
            return this.Weights[edge.First.Id, edge.Second.Id];
        }
    }
}
