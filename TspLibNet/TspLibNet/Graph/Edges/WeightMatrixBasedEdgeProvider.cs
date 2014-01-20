namespace TspLibNet.Graph.Edges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TspLibNet.Graph.Nodes;
    using TspLibNet.Exceptions;

    /// <summary>
    /// Provides edges by looking up edge weight matrix
    /// </summary>
    public class WeightMatrixBasedEdgeProvider : WeightMatrixBasedEdgeProviderWithExclusions
    {
        /// <summary>
        /// Creates a new instance of a WeightMatrixBasedEdgeProvider class
        /// </summary>
        /// <param name="matrix">weight matrix initializing edge provider</param>
        public WeightMatrixBasedEdgeProvider(double[,] matrix)
            : base(matrix, new double[] {})
        {
        }
    }
}
